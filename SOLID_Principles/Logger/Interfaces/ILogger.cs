namespace Logger
{
    using System.Collections.Generic;

    public interface ILogger
    {
        List<Appender> Appenders { get; }

        void Critical(string dateTime, string message);
        void Fatal(string dateTime, string message);
        void Info(string dateTime, string message);
        void Warning(string dateTime, string message);
        void Error(string dateTime, string message);
    }
}