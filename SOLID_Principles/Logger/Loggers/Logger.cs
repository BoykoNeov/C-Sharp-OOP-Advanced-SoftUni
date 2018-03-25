namespace Logger
{
    using System;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        private List<Appender> appenders;

        public Logger(params Appender[] appenders)
        {
            this.Appenders = new List<Appender>();

            foreach (Appender appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }

        public Logger() { }

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