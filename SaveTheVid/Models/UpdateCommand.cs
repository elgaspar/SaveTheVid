namespace SaveTheVid.Models
{
    class UpdateCommand : Command
    {
        private const string STARTING_LINE = "Update starting...";
        private const string ENDING_LINE = "Update finished...";

        public UpdateCommand(Downloader downloader) : base(downloader)
        {
        }



        public override void Run()
        {
            downloader.Output.AddLine(STARTING_LINE);

            createProcess( ArgumentsGenerator.GenerateUpdateArguments() );

            executeProcess();
            handleOutputs();

            downloader.Output.AddLine(ENDING_LINE);
            downloader.Output.AddEmptyLine();
            downloader.IsAvailable = true;
        }

    }
}
