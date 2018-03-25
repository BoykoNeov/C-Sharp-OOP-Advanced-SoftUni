namespace Logger
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Logger logger = new Logger();

            int n = int.Parse(Console.ReadLine());

            AppenderParser loggerParser = new AppenderParser();
            for (int i = 0; i < n; i++)
            {
                logger.Appenders.Add(loggerParser.ParseAppender(Console.ReadLine()));
            }

            string message = string.Empty;

            while ((message = Console.ReadLine()) != "END")
            {
                ErrorMessageParser errorMessageParser = new ErrorMessageParser();

                foreach (Appender appender in logger.Appenders)
                {
                    errorMessageParser.Parse(message, out string dateTime, out ReportLevel reportLevel, out string errorMessage);
                    appender.ProcessMessage(dateTime, reportLevel, errorMessage);
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(logger.GetInfo());
            Console.ResetColor();
        }
    }
}