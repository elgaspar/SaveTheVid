using Caliburn.Micro;
using SaveTheVid.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Timers;

namespace SaveTheVid.ViewModels
{
    class JobViewModel : PropertyChangedBase, IDataErrorInfo
    {
        private const string STATUS_ANALYSING = "Analysing URL...";
        private const string STATUS_VALID_URL = "URL added to queue";
        private const string STATUS_INVALID_URL = "Invalid URL";

        public MainViewModel ParentVM { get; }

        public JobViewModel(MainViewModel parent)
        {
            ParentVM = parent;

            IsEncoderInstalled = ParentVM.DownloadQueue.IsEncoderInstalled();

            loadDefaultValues();
        }

        public bool IsEncoderInstalled { get; }

        private Job newJob;

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                NotifyOfPropertyChange(() => Url);
                NotifyOfPropertyChange(() => CanAddToQueue);
            }
        }

        private bool _audioOnly;
        public bool AudioOnly
        {
            get { return _audioOnly; }
            set
            {
                _audioOnly = value;
                NotifyOfPropertyChange(() => AudioOnly);
            }
        }

        private Options.VideoQualities _videoQuality;
        public Options.VideoQualities VideoQuality
        {
            get { return _videoQuality; }
            set
            {
                _videoQuality = value;
                NotifyOfPropertyChange(() => VideoQuality);
            }
        }

        private Options.AudioQualities _audioQuality;
        public Options.AudioQualities AudioQuality
        {
            get { return _audioQuality; }
            set
            {
                _audioQuality = value;
                NotifyOfPropertyChange(() => AudioQuality);
            }
        }

        private Options.VideoFormats _videoFormat;
        public Options.VideoFormats VideoFormat
        {
            get { return _videoFormat; }
            set
            {
                _videoFormat = value;
                NotifyOfPropertyChange(() => VideoFormat);
            }
        }

        private Options.AudioFormats _audioFormat;
        public Options.AudioFormats AudioFormat
        {
            get { return _audioFormat; }
            set
            {
                _audioFormat = value;
                NotifyOfPropertyChange(() => AudioFormat);
            }
        }

        private string _outputDir;
        public string OutputDir
        {
            get { return _outputDir; }
            set
            {
                _outputDir = value;
                NotifyOfPropertyChange(() => OutputDir);
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                NotifyOfPropertyChange(() => Status);
                NotifyOfPropertyChange(() => CanAddToQueue);
            }
        }

        private Timer resetStatusTimer;





        public bool IsValid { get { return string.IsNullOrEmpty(this.Error); } }

        public string Error { get { return this[null]; } }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (string.IsNullOrEmpty(columnName) || columnName == "Url")
                {
                    if (string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(Url.Trim()))
                        result = "Field is required.";
                }
                if (Status!=null && Status.Equals(STATUS_ANALYSING))
                    result = "Analysing";
                return result;
            }
        }

        public bool CanAddToQueue { get { return IsValid; } }





        public void OpenOutputDirectory()
        {
            ParentVM.OpenDirectory(OutputDir);
        }

        public void AddToQueue()
        {          
            createJob();
            resetUrl();
            new Task(CheckUrlAndAddJobToQueue).Start();
        }





        private void createJob()
        {
            newJob = new Job(Url, OutputDir);
            newJob.Options.AudioOnly = AudioOnly;
            newJob.Options.VideoQuality = VideoQuality;
            newJob.Options.AudioQuality = AudioQuality;
            newJob.Options.VideoFormat = VideoFormat;
            newJob.Options.AudioFormat = AudioFormat;
            newJob.Options.IsEncoderMissing = !IsEncoderInstalled;
        }

        private void resetUrl()
        {
            Url = string.Empty;
        }

        private void CheckUrlAndAddJobToQueue()
        {
            Status = STATUS_ANALYSING;
            bool isValid = ParentVM.DownloadQueue.IsValidUrl(newJob);
            if (isValid)
            {
                ParentVM.DownloadQueue.Add(newJob);
                Status = STATUS_VALID_URL;
            }
            else
                Status = STATUS_INVALID_URL;
            resetStatusAfterThreeSeconds();
        }

        private void resetStatusAfterThreeSeconds()
        {
            if (Status == STATUS_ANALYSING)
                return;
            if (resetStatusTimer != null)
                resetStatusTimer.Dispose();
            resetStatusTimer = new Timer();
            resetStatusTimer.Elapsed += new ElapsedEventHandler(resetStatusIfNotAnalysing);
            resetStatusTimer.Interval = 3000;
            resetStatusTimer.Enabled = true;
        }

        private void resetStatusIfNotAnalysing(object source, ElapsedEventArgs e)
        {
            if (Status != STATUS_ANALYSING)
                Status = string.Empty;
            resetStatusTimer.Dispose();
        }

        private void loadDefaultValues()
        {
            Options defaultValues = new Options();
            OutputDir = defaultValues.OutputDir;
            AudioOnly = defaultValues.AudioOnly;
            VideoQuality = defaultValues.VideoQuality;
            AudioQuality = defaultValues.AudioQuality;
            VideoFormat = defaultValues.VideoFormat;
            AudioFormat = defaultValues.AudioFormat;
        }
    }
}
