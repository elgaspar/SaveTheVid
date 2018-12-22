using SaveTheVid.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SaveTheVid.Views
{
    /// <summary>
    /// Interaction logic for ToolBarViewxaml.xaml
    /// </summary>
    public partial class ToolBarView : UserControl
    {
        public ToolBarView()
        {
            InitializeComponent();
        }

        private void Button_Click_About(object sender, RoutedEventArgs e)
        {
            showAboutDialog();
        }

        private void showAboutDialog()
        {
            DialogHelper.ShowAboutDialog((MainViewModel)DataContext);
        }
    }
}
