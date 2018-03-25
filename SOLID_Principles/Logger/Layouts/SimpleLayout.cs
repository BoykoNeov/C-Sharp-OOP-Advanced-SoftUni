namespace Logger
{
    public class SimpleLayout : Layout
    {
        public SimpleLayout() : base()
        {
        }

        public override string GetLayoutFormattedMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}