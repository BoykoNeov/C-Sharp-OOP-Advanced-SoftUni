namespace Logger
{
    using System;

    public class ErrorMessageParser
    {
        public void Parse(string inputMessage, out string date, out ReportLevel reportLevel, out string message)
        {
            string[] splitInput = inputMessage.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                date = splitInput[1];
                reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), splitInput[0]);
                message = splitInput[2];
            }
            catch
            {
                date = null;
                message = null;

                throw new FormatException("Invalid message format");
            }

            return;
        }
    }
}