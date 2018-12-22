namespace SaveTheVid.Models
{
    class Job : NotifyBase
    {
        public string Title { get; set; }
        public Options Options { get; }

        private DownloadStatus _status;
        public DownloadStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                NotifyPropertyChanged();
            }
        }

        public Job()
        {
            Options = new Options();
            Status = DownloadStatus.Idle;
        }

        public Job(string url, string outputDir) : this()
        {
            Options.Url = url;
            Options.OutputDir = outputDir;
        }

        public enum DownloadStatus
        {
            Idle,
            Downloading,
            Finished,
        }
    }
}
