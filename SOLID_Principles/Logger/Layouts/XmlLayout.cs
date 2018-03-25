namespace Logger
{
    using System.Text;

    public class XmlLayout : Layout
    {
        public override string GetLayoutFormattedMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            string ident = new string(' ', 4);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<log>");
            sb.AppendLine($"{ident}<date>{dateTime}</date>");
            sb.AppendLine($"{ident}<level>{reportLevel}</level>");
            sb.AppendLine($"{ident}<message>{message}</message>");
            sb.AppendLine($"</log>");
            return sb.ToString();
        }

        public XmlLayout() : base()
        {
        }
    }
}