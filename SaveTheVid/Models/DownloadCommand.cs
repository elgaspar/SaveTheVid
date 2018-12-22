using System;
using System.IO;

namespace SaveTheVid.Models
{
    class DownloadCommand : Command
    {
        private const string STARTING_LINE = "Download starting...";
        private const string ENDING_LINE = "Download finished...";

        private Job jobToDownload;
        private string temporaryDirectoryPath;

        public DownloadCommand(Downloader downloader, Job job) : base(downloader)
        {
            jobToDownload = job;
            temporaryDirectoryPath = ArgumentsGenerator.getTemporaryDir(jobToDownload.Options.OutputDir);
        }



        public override void Run()
        {
            jobToDownload.Status = Job.DownloadStatus.Downloading;
            downloader.Output.AddLine(STARTING_LINE);

            createTemporaryDirectory();

            createProcess( ArgumentsGenerator.GenerateDownloadArguments(jobToDownload) );

            executeProcess();
            handleOutputs();

            deleteTemporaryDirectory();

            downloader.Output.AddLine(ENDING_LINE);
            downloader.Output.AddEmptyLine();
            jobToDownload.Status = Job.DownloadStatus.Finished;
            downloader.IsAvailable = true;
        }

        private void createTemporaryDirectory()
        {
            DirectoryInfo dir = Directory.CreateDirectory(temporaryDirectoryPath);
            dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }

        private void deleteTemporaryDirectory()
        {
            var dir = new DirectoryInfo(temporaryDirectoryPath);
            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
            try
            {
                dir.Delete(true);
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't delete temporary directory.");
            }
        }

    }
}
