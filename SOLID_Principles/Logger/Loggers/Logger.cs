namespace Logger
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Logger : ILogger
    {
        private List<Appender> appenders;

        public Logger(params Appender[] appenders) : this()
        {
            foreach (Appender appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }

        public Logger()
        {
            this.Appenders = new List<Appender>();
        }

        public List<Appender> Appenders { get => appenders; private set => appenders = value; }

        public void AddAppender(Appender appender)
        {
            this.appenders.Add(appender);
        }

        private void CallAppendersWithMessage(string dateTime, ReportLevel reportLevel, string errorMessage)
        {
            foreach (Appender appender in this.appenders)
            {
                appender.ProcessMessage(dateTime, reportLevel, errorMessage);
            }
        }

        public void Critical(string dateTime, string message)
        {
            CallAppendersWithMessage(dateTime, ReportLevel.CRITICAL, message);
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info"); ;
            foreach (Appender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString();
        }

        public void Error(string dateTime, string message)
        {
            CallAppendersWithMessage(dateTime, ReportLevel.ERROR, message);
        }

        public void Fatal(string dateTime, string message)
        {
            CallAppendersWithMessage(dateTime, ReportLevel.FATAL, message);
        }

        public void Info(string dateTime, string message)
        {
            CallAppendersWithMessage(dateTime, ReportLevel.INFO, message);
        }

        public void Warning(string dateTime, string message)
        {
            CallAppendersWithMessage(dateTime, ReportLevel.WARNING, message);
        }
    }
}