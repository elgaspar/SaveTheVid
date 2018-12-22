namespace SaveTheVid.Models
{
    class AnalyseCommand : Command
    {
        private Job job;

        public AnalyseCommand(Downloader downloader, Job job) : base(downloader)
        {
            this.job = job;
        }



        public override void Run()
        {
            createProcess(ArgumentsGenerator.GenerateGetTitleArguments(job));
            executeProcess();
            job.Title = getOutput();
        }

        public bool IsValidUrl()
        {
            Run();
            if (!processToExecute.StandardError.EndOfStream)
                return false;
            return true;
        }



        private string getOutput()
        {
            if (!processToExecute.StandardOutput.EndOfStream)
                return processToExecute.StandardOutput.ReadLine();
            return string.Empty;
        }

    }
}
