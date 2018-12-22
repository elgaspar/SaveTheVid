using System.Collections.ObjectModel;
using System.IO;

namespace SaveTheVid.Models
{
    class Output
    {
        public ObservableCollection<string> AsList { get; }

        public Output()
        {
            AsList = new ObservableCollection<string>();
        }

        private string currentLine;
        private string previousLine;





        public void Handle(StreamReader stream)
        {
            while (!stream.EndOfStream)
            {
                currentLine = stream.ReadLine();
                parseLine();
            }
        }

        public void AddLine(string line)
        {
            AsList.Add(line);
        }

        public void AddEmptyLine()
        {
            AsList.Add(string.Empty);
        }





        private void parseLine()
        {
            if (!isEmpty() && isDownloadLine(currentLine) && isDownloadLine(previousLine))
                removeLastLine();

            if (!isEmptyLine(currentLine))
                AsList.Add(currentLine);

            previousLine = currentLine;
        }

        private bool isEmpty()
        {
            return (AsList.Count == 0);
        }

        private void removeLastLine()
        {
            if (isEmpty())
                return;
            AsList.RemoveAt(AsList.Count - 1);
        }

        private bool isDownloadLine(string line)
        {
            return line!=null && line.StartsWith("[download]");
        }

        private bool isEmptyLine(string line)
        {
            return string.IsNullOrEmpty(line.Trim());
        }
    }
}
