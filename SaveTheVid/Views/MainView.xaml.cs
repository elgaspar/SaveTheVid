using MahApps.Metro.Controls;
using SaveTheVid.Models;
using SaveTheVid.ViewModels;
using System;
using System.Windows;

namespace SaveTheVid.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
        }

        private JobViewModel jobVM { get { return ((MainViewModel)DataContext).JobVM; } }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loadSettings();
        }

        private void loadSettings()
        {
            try
            {
                jobVM.AudioOnly = Properties.Settings.Default.AudioOnly;

                Enum.TryParse(Properties.Settings.Default.VideoQuality, out Options.VideoQualities videoQuality);
                jobVM.VideoQuality = videoQuality;
                Enum.TryParse(Properties.Settings.Default.AudioQuality, out Options.AudioQualities audioQuality);
                jobVM.AudioQuality = audioQuality;
                Enum.TryParse(Properties.Settings.Default.VideoFormat, out Options.VideoFormats videoFormat);
                jobVM.VideoFormat = videoFormat;
                Enum.TryParse(Properties.Settings.Default.AudioFormat, out Options.AudioFormats audioFormat);
                jobVM.AudioFormat = audioFormat;

                string outputDir = Properties.Settings.Default.OutputDirectory;
                if ( !string.IsNullOrEmpty(outputDir) )
                    jobView.browseTextBox.SelectedDirectoryPath = outputDir;
            }
            catch (Exception)
            {
                Console.WriteLine("Default settings loaded");
            }
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            if (jobVM.IsEncoderInstalled == false)
                DialogHelper.ShowEncoderMissingDialog();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            saveSettings();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.AudioOnly = jobVM.AudioOnly;
            Properties.Settings.Default.VideoQuality = jobVM.VideoQuality.ToString();
            Properties.Settings.Default.AudioQuality = jobVM.AudioQuality.ToString();
            Properties.Settings.Default.VideoFormat = jobVM.VideoFormat.ToString();
            Properties.Settings.Default.AudioFormat = jobVM.AudioFormat.ToString();
            Properties.Settings.Default.OutputDirectory = jobVM.OutputDir;

            Properties.Settings.Default.Save();
        }

    }
}
