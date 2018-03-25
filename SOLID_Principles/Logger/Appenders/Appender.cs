namespace Logger
{
    public abstract class Appender
    {
        private uint appendedMessagesCount;

        public abstract void ProcessMessage(string dateTime, ReportLevel messageReportLevel, string message);

        private ReportLevel reportThreshold;

        public ReportLevel ReportThreshold
        {
            get { return this.reportThreshold; }
            set { this.reportThreshold = value; }
        }

        private Layout layout;

        public Appender(Layout layout)
        {
            this.Layout = layout;
            this.reportThreshold = ReportLevel.INFO;
        }

        public Appender(Layout layout, ReportLevel reportThreshold)
        {
            this.Layout = layout;
            this.reportThreshold = reportThreshold;
        }

        public uint AppendedMessagesCount { get => appendedMessagesCount; protected set => appendedMessagesCount = value; }

        public Layout Layout { get => this.layout; protected set => this.layout = value; }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportThreshold}, Messages appended: {this.AppendedMessagesCount}";
        }
    }
}