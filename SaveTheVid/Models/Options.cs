using System;
using System.ComponentModel;

namespace SaveTheVid.Models
{
    class Options
    {
        public String Url { get; set; }
        public string OutputDir { get; set; }
        public bool AudioOnly { get; set; }
        public VideoQualities VideoQuality { get; set; }
        public AudioQualities AudioQuality { get; set; }
        public VideoFormats VideoFormat { get; set; }
        public AudioFormats AudioFormat { get; set; }

        public bool IsEncoderMissing { get; set; }

        public Options()
        {
            Url = string.Empty;
            OutputDir = getDefaultOutputDirectory();
            AudioOnly = false;
            VideoQuality = VideoQualities.p480;
            AudioQuality = AudioQualities.Normal;
            VideoFormat = Options.VideoFormats.Default;
            AudioFormat = Options.AudioFormats.mp3;
        }

        public enum VideoQualities
        {
            [Description("480p")]
            p480 = 480,
            [Description("720p")]
            p720 = 720,
            [Description("1080p")]
            p1080 = 1080,
            [Description("2160p")]
            p2160 = 2160
        }

        public enum AudioQualities
        {
            Low = 9,
            Normal = 5,
            High = 0,
        }

        public enum VideoFormats
        {
            Default, avi, flv, mkv, mp4
        }

        public enum AudioFormats
        {
            aac, flac, mp3, wav
        }

        private string getDefaultOutputDirectory()
        {
            return Environment.CurrentDirectory + "\\Output";
        }
    }
}
