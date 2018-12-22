using Caliburn.Micro;
using SaveTheVid.ViewModels;

namespace SaveTheVid.Views
{
    static class DialogHelper
    {
        public static void ShowAboutDialog(MainViewModel parent)
        {
            showDialog(new DialogAboutViewModel(parent));
        }
        
        public static void ShowEncoderMissingDialog()
        {
            showDialog(new DialogEncoderMissingViewModel());
        }

        public static string ShowFolderBrowserDialog()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                return dialog.SelectedPath;
            else
                return null;
        }


        
        private static void showDialog(Screen vm)
        {
            IWindowManager manager = new WindowManager();
            manager.ShowDialog(vm, null, null);
        }
    }
}
