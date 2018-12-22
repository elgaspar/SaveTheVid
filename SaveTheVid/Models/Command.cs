using System;
using System.Diagnostics;
using System.IO;

namespace SaveTheVid.Models
{
    abstract class Command
    {
        protected Downloader downloader;
        protected Process processToExecute;
        protected string arguments;

        public Command(Downloader downloader)
        {
            this.downloader = downloader;
        }



        public abstract void Run();

        

        protected void createProcess(string args)
        {
            this.arguments = args;
            processToExecute = new Process();

            string filename = getExePath();
            processToExecute.StartInfo.FileName = filename;
            processToExecute.StartInfo.Arguments = args;

            processToExecute.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processToExecute.StartInfo.CreateNoWindow = true;

            processToExecute.StartInfo.UseShellExecute = false;
            processToExecute.StartInfo.RedirectStandardOutput = true;
            processToExecute.StartInfo.RedirectStandardError = true;
        }

        protected string getExePath()
        {
            return Path.Combine(Environment.CurrentDirectory, Downloader.DOWNLOADER_EXE_RELATIVE_PATH);
        }

        protected void executeProcess()
        {
            if (downloader!=null)
                downloader.Output.AddLine("Executing youtube-dl.exe with arguments:" + arguments);
            processToExecute.Start();
        }

        protected void handleOutputs()
        {
            downloader.Output.Handle(processToExecute.StandardOutput);
            downloader.Output.Handle(processToExecute.StandardError);
        }

    }
}
