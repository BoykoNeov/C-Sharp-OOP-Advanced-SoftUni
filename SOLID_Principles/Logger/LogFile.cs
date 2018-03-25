namespace Logger
{
    using System.Collections.Generic;

    public class LogFile : IFile
    {
        public LogFile()
        {
            this.Messages = new List<string>();
        }

        public void AppendMessageToFile(string message)
        {
            this.Messages.Add(message);
        }

        private List<string> messages;

        public ulong Size {
            get
            {
                ulong result = 0;

                for (int i = 0; i < this.Messages.Count; i++)
                {
                    for (int j = 0; j < this.Messages[i].Length; j++)
                    {
                        if (char.IsLetter(this.Messages[i][j]))
                        {
                            result += this.Messages[i][j];
                        }
                    }
                }

                return result;
            }
        }

        public List<string> Messages { get => messages; private set => messages = value; }
    }
}