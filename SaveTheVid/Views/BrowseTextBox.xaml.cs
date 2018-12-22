using SaveTheVid.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SaveTheVid.Views
{
    /// <summary>
    /// Interaction logic for BrowseTextBox.xaml
    /// </summary>
    public partial class BrowseTextBox : UserControl
    {
        public BrowseTextBox()
        {
            InitializeComponent();
        }

        public string SelectedDirectoryPath
        {
            get { return (string)GetValue(SelectedDirectoryPathProperty); }
            set
            {
                SetValue(SelectedDirectoryPathProperty, value);
                OutputDir.Text = SelectedDirectoryPath;
            }
        }

        public static readonly DependencyProperty SelectedDirectoryPathProperty =
            DependencyProperty.Register("SelectedDirectoryPath", typeof(string), typeof(BrowseTextBox), new PropertyMetadata(string.Empty));

        private void MouseLeftButtonDown_BrowseButton(object sender, MouseButtonEventArgs e)
        {
            string folder = DialogHelper.ShowFolderBrowserDialog();
            if (folder != null)
                SelectedDirectoryPath = folder;
        }

        private void OutputDir_TextChanged(object sender, TextChangedEventArgs e)
        {
            OutputDir.Text = SelectedDirectoryPath;
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            JobViewModel vm = (JobViewModel)DataContext;
            SelectedDirectoryPath = vm.OutputDir;
        }
    }
}
