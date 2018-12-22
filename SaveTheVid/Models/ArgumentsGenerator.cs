using SaveTheVid.Models.Exceptions;
using System;

namespace SaveTheVid.Models
{
    static class ArgumentsGenerator
    {
        private static string argumentsString;
        private static Options options;



        public static string GenerateDownloadArguments(Job job)
        {
            ArgumentsGenerator.options = job.Options;
            argumentsString = string.Empty;
            appendUrlArgument();
            appendOutputArgument();
            appendOptionsArguments();
            return argumentsString;
        }

        public static string GenerateUpdateArguments()
        {
            return " --update";
        }

        public static string GenerateGetTitleArguments(Job job)
        {
            ArgumentsGenerator.options = job.Options;
            argumentsString = string.Empty;
            appendUrlArgument();
            appendWithLeadingSpace(" --get-title");
            return argumentsString;
        }

        public static string getTemporaryDir(string outputDir)
        {
            if (options == null)
                throw new NullReferenceException();
            return outputDir + "\\tmp.SaveTheVid\\";
        }



        private static void appendWithLeadingSpace(string str)
        {
            argumentsString += " " + str;
        }

        private static void appendUrlArgument()
        {
            if (string.IsNullOrEmpty(options.Url))
                throw new InvalidUrlException();

            appendWithLeadingSpace("\"" + options.Url + "\"");
            appendWithLeadingSpace("--no-playlist");
        }

        private static void appendOutputArgument()
        {
            appendWithLeadingSpace("--output \"" + getTemporaryDir(options.OutputDir) + "%(title)s.%(ext)s\" --exec \"move {} \"\"" + options.OutputDir + "\\\"\"");
        }

        private static void appendOptionsArguments()
        {
            if (options.IsEncoderMissing)
                return;

            if (options.AudioOnly)
            {
                appendAudioOnlyArgument();
                appendAudioFormatArgument();
            }
            else
            {
                appendVideoQualityArgument();
                appendVideoFormatArgument();
            }
        }

        private static void appendAudioOnlyArgument()
        {
            int quality = (int)options.AudioQuality;
            appendWithLeadingSpace("--extract-audio --audio-quality " + quality);
        }

        private static void appendAudioFormatArgument()
        {
            appendWithLeadingSpace("--audio-format " + options.AudioFormat);
        }

        private static void appendVideoQualityArgument()
        {
            int height = (int)options.VideoQuality;
            appendWithLeadingSpace("-f bestvideo[height<=" + height + "]+bestaudio/best[height<=" + height + "]");
        }

        private static void appendVideoFormatArgument()
        {
            if (options.VideoFormat != Options.VideoFormats.Default)
                appendWithLeadingSpace("--recode-video " + options.VideoFormat);
        }
    }
}
