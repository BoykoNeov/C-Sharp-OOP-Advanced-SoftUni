namespace Logger
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Appender> appenders = new List<Appender>();

            AppenderParser loggerParser = new AppenderParser();
            for (int i = 0; i < n; i++)
            {
                appenders.Add(loggerParser.ParseAppender(Console.ReadLine()));
            }

            string message = string.Empty;

            while((message = Console.ReadLine())!= "END")
            {
                ErrorMessageParser errorMessageParser = new ErrorMessageParser();

                foreach (Appender appender in appenders)
                {
                    errorMessageParser.Parse(message, out string dateTime, out ReportLevel reportLevel, out string errorMessage);
                    appender.ProcessMessage(dateTime, reportLevel, errorMessage);
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Logger info");
            foreach (Appender appender in appenders)
            {
               Console.WriteLine(appender.ToString());
            }

            Console.ResetColor();
        }
    }
}