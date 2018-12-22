using Caliburn.Micro;
using System.Diagnostics;

namespace SaveTheVid.ViewModels
{
    class DialogEncoderMissingViewModel : Screen
    {
        private const string InstructionsFile = @"Resources\How to install encoder.html";

        public void OpenInstructionsFile()
        {
            Process.Start(InstructionsFile);
        }

        public void Ok()
        {
            //Do nothing
            TryClose(true);
        }

    }
}
