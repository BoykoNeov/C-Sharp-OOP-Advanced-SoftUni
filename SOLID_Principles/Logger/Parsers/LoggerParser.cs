namespace Logger
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    public class AppenderParser
    {
        public Appender ParseAppender(string input)
        {
            try
            {
                string[] splitInput = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                ReportLevel? reportLevel = null;
                Appender newAppender = null;

                Assembly assembly = Assembly.GetExecutingAssembly();
                Type[] types = assembly.GetTypes();

                Dictionary<string, string> assemblyTypesWithoutNamespaceAsKeys = new Dictionary<string, string>();

                foreach (Type type in types)
                {
                    string typeWithoutNamespace = type.Name;
                    assemblyTypesWithoutNamespaceAsKeys[typeWithoutNamespace] = type.Namespace + "." + type.Name;
                }


                Layout layout = (Layout)assembly.CreateInstance(assemblyTypesWithoutNamespaceAsKeys[splitInput[1]]);
                Type appenderType = Type.GetType(assemblyTypesWithoutNamespaceAsKeys[splitInput[0]]);

                if (splitInput.Length == 2)
                {
                    newAppender = (Appender)Activator.CreateInstance(appenderType, layout);
                }
                if (splitInput.Length == 3)
                {
                    reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), splitInput[2]);
                    newAppender = (Appender)Activator.CreateInstance(appenderType, layout, reportLevel);
                }

                return newAppender;
            }
            catch
            {
                throw new ArgumentException("Invalid logger params!");
            }
        }
    }
}