using SaveTheVid.Models.Exceptions;
using System.IO;
using System.Threading.Tasks;

namespace SaveTheVid.Models
{
    class Downloader : NotifyBase
    {
        public const string RELATIVE_BIN_DIRECTORY = @"Resources\bin\";
        public const string DOWNLOADER_EXE_RELATIVE_PATH = RELATIVE_BIN_DIRECTORY + "youtube-dl.exe";
        public const string ENCODER1_EXE_RELATIVE_PATH = RELATIVE_BIN_DIRECTORY + "ffmpeg.exe";
        public const string ENCODER2_EXE_RELATIVE_PATH = RELATIVE_BIN_DIRECTORY + "ffprobe.exe";

        public Output Output { get; }

        private bool _isAvailable;
        public bool IsAvailable
        {
            get { return _isAvailable;}
            set
            {
                _isAvailable = value;
                NotifyPropertyChanged();
            }
        }

        public Downloader()
        {
            Output = new Output();
            IsAvailable = true;
        }




        public void Download(Job jobToDownload)
        {
            runCommand(new DownloadCommand(this, jobToDownload));
        }

        public void Update()
        {
            runCommand(new UpdateCommand(this));
        }

        public bool IsValidUrl(Job job)
        {
            AnalyseCommand command = new AnalyseCommand(null, job);
            return command.IsValidUrl();
        }

        public bool isEncoderInstalled()
        {
            return File.Exists(ENCODER1_EXE_RELATIVE_PATH) && File.Exists(ENCODER2_EXE_RELATIVE_PATH);
        }





        private void runCommand(Command command)
        {
            checkIfAvailable();
            IsAvailable = false;
            new Task(command.Run).Start();
        }

        private void checkIfAvailable()
        {
            if (!IsAvailable)
                throw new DownloaderIsNotAvailableException();
        }
        
    }
}
