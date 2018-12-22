using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;

namespace SaveTheVid.Models
{
    class DownloadQueue : NotifyBase
    {
        private Downloader Downloader { get; }

        private ObservableCollection<Job> _jobs { get; }
        public ReadOnlyObservableCollection<Job> Jobs { get; }

        private Timer timer { get; }

        public DownloadQueue()
        {
            Downloader = new Downloader();

            _jobs = new ObservableCollection<Job>();
            Jobs = new ReadOnlyObservableCollection<Job>(_jobs);

            Downloader.PropertyChanged += onDownladerPropertyChanged;

            timer = initTimer();
        }

        public bool IsDownloaderAvailable { get { return Downloader.IsAvailable; } }

        public ObservableCollection<string> OutputAsList{ get { return Downloader.Output.AsList; } }

        public void Add(Job job)
        {
            _jobs.Add(job);
        }

        public void UpdateDownloader()
        {
            Downloader.Update();
        }

        public bool IsValidUrl(Job job)
        {
            return Downloader.IsValidUrl(job);
        }

        public void AddLineToOutput(string line)
        {
            Downloader.Output.AddLine(line);
        }

        public bool IsEncoderInstalled()
        {
            return Downloader.isEncoderInstalled();
        }





        private void onDownladerPropertyChanged(Object sender, PropertyChangedEventArgs args)
        {
            NotifyPropertyChanged("IsDownloaderAvailable");
        }

        private Timer initTimer()
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timerTick);
            timer.Interval = 1000;
            timer.Enabled = true;
            return timer;
        }

        private void timerTick(object source, ElapsedEventArgs e)
        {
            if (shouldNotDownload())
                return;
            Job jobToDownload = getFirstIdleJob();
            Downloader.Download(jobToDownload);
        }

        private bool shouldNotDownload()
        {
            return thereAreNoIdleJobs() || IsDownloaderAvailable == false;
        }

        private bool thereAreNoIdleJobs()
        {
            foreach (Job job in Jobs)
            {
                if (job.Status == Job.DownloadStatus.Idle)
                    return false;
            }
            return true;
        }

        private Job getFirstIdleJob()
        {
            foreach (Job job in Jobs)
            {
                if (job.Status == Job.DownloadStatus.Idle)
                    return job;
            }
            return null;
        }

    }
}
