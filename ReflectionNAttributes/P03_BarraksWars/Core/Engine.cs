namespace _03BarracksFactory.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Core.Commands;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string[] data = input.Split();
                    string commandName = data[0].ToLower();
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.InnerException.Message);
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            Assembly currentAssembly = this.GetType().Assembly;
            Dictionary<string, Type> commands = currentAssembly.GetTypes()
                     .Where(t => String.Equals(t.Namespace, "_03BarracksFactory.Core.Commands", StringComparison.Ordinal))
                     .ToDictionary(c => c.Name.ToLower(), c => c);

            Type currentCommandType = commands[commandName + "command"];

            if (currentCommandType == null || string.IsNullOrWhiteSpace(commandName))
            {
                throw new InvalidOperationException("Invalid command!");
            }
            else
            {
                Command command = (Command)Activator.CreateInstance(currentCommandType, new object[] { data, this.repository, this.unitFactory });
                MethodInfo executeMethod = currentCommandType.GetMethod("Execute");
                var result = executeMethod.Invoke(command, null);
                return result as string;
            }

            //string result = string.Empty;
            //switch (commandName)
            //{
            //    case "add":
            //        result = this.AddUnitCommand(data);
            //        break;
            //    case "report":
            //        result = this.ReportCommand(data);
            //        break;
            //    case "fight":
            //        Environment.Exit(0);
            //        break;
            //}
            //return result;
        }


        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        //private string AddUnitCommand(string[] data)
        //{
        //    string unitType = data[1];
        //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    this.repository.AddUnit(unitToAdd);
        //    string output = unitType + " added!";
        //    return output;
        //}
    }
}