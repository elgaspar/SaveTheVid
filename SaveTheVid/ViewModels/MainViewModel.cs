using Caliburn.Micro;
using SaveTheVid.Models;
using System.Diagnostics;

namespace SaveTheVid.ViewModels
{
    class MainViewModel : PropertyChangedBase
    {
        private const string VersionNo = "1.0.1";

        public DownloadQueueViewModel DownloadQueueVM { get; }
        public JobViewModel JobVM { get; }
        public OutputViewModel OutputVM { get; }

        public MainViewModel()
        {
            DownloadQueueVM = new DownloadQueueViewModel(this);

            JobVM = new JobViewModel(this);
            OutputVM = new OutputViewModel(this);
        }

        public string Version { get { return "version " + VersionNo; } }

        public DownloadQueue DownloadQueue { get { return DownloadQueueVM.DownloadQueue; } }

        public bool CanUpdate { get { return true; } }

        public void Update()
        {
            DownloadQueueVM.DownloadQueue.UpdateDownloader();
        }

        public void OpenDirectory(string path)
        {
            Process.Start("explorer.exe", path);
        }
    }
}
