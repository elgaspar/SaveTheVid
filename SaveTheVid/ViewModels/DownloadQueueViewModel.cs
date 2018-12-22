using Caliburn.Micro;
using SaveTheVid.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace SaveTheVid.ViewModels
{
    class DownloadQueueViewModel : PropertyChangedBase
    {
        public MainViewModel ParentVM { get; }

        public DownloadQueueViewModel(MainViewModel parent)
        {
            ParentVM = parent;

            DownloadQueue = new DownloadQueue();
            BindingOperations.EnableCollectionSynchronization(DownloadQueue.Jobs, new object());
        }

        public DownloadQueue DownloadQueue { get; }

        private Job _selectedJob;
        public Job SelectedJob
        {
            get { return _selectedJob; }
            set
            {
                _selectedJob = value;
                NotifyOfPropertyChange(() => SelectedJob);
                NotifyOfPropertyChange(() => IsJobSelected);
            }
        }

        public bool IsJobSelected { get { return SelectedJob!=null; } }

        public void OpenOutputDirectory()
        {
            ParentVM.OpenDirectory(SelectedJob.Options.OutputDir);
        }

        public void CopyUrl()
        {
            Clipboard.SetText(SelectedJob.Options.Url);
        }

        public void VisitUrl()
        {
            Process.Start(SelectedJob.Options.Url);
        }

    }
}
