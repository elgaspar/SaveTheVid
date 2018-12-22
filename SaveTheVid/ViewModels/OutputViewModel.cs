using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace SaveTheVid.ViewModels
{
    class OutputViewModel : PropertyChangedBase
    {
        public MainViewModel ParentVM { get; }

        public OutputViewModel(MainViewModel parent)
        {
            ParentVM = parent;

            Output = ParentVM.DownloadQueue.OutputAsList;
            BindingOperations.EnableCollectionSynchronization(Output, new object());

            addWelcomeInfo();
        }

        public ObservableCollection<string> Output { get; }

        private void addWelcomeInfo()
        {
            addLineToOutput("SaveTheVid " + ParentVM.Version);
            addLineToOutput(string.Empty);
        }

        private void addLineToOutput(string line)
        {
            ParentVM.DownloadQueue.AddLineToOutput(line);
        }
    }
}
