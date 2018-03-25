namespace Logger
{
    public class FileAppender : Appender
    {
        public FileAppender(Layout layout, IFile file) : base (layout)
        {
            this.File = file;
        }

        public FileAppender(Layout layout) : base(layout)
        {
            this.File = new LogFile();
        }

        public FileAppender(Layout layout, ReportLevel reportThreshold) : base(layout, reportThreshold)
        {
            this.File = new LogFile();
        }

        public IFile File { get; set; }

        public override void ProcessMessage(string dateTime, ReportLevel messageReportLevel, string message)
        {
            string messageToAppend = this.Layout.GetLayoutFormattedMessage(dateTime, messageReportLevel, message);
            this.File.AppendMessageToFile(messageToAppend);
            this.AppendedMessagesCount++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}