namespace Logger
{
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(Layout layout) : base(layout)
        {
        }

        public ConsoleAppender(Layout layout, ReportLevel reportThreshold) : base(layout, reportThreshold)
        {
        }

        public override void ProcessMessage(string dateTime , ReportLevel messageReportLevel, string message)
        {
            if (this.ReportThreshold > messageReportLevel)
            {
                return;
            }
            else
            {
                string result = this.Layout.GetLayoutFormattedMessage(dateTime, messageReportLevel, message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result);
                Console.ResetColor();
                this.AppendedMessagesCount++;
            }


        }
    }
}