namespace Logger
{
    public abstract class Layout
    {
        public abstract string GetLayoutFormattedMessage(string dateTime, ReportLevel reportLevel, string message);

        public Layout()
        {
        }
    }
}