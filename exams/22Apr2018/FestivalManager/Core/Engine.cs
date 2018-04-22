namespace FestivalManager.Core
{
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;

    class Engine : IEngine
    {
        private const string endRunningString = "END";
        private IReader reader;
        private IWriter writer;

        private IStage stage;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer) 
        {
            this.writer = writer;
            this.reader = reader;
            this.stage = new Stage();
            this.festivalCоntroller = new FestivalController(stage);
            this.setCоntroller = new SetController(stage);
        }

        public Engine()
        {
            this.stage = new Stage();
            this.festivalCоntroller = new FestivalController(stage);
            this.setCоntroller = new SetController(stage);
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
        }

        public Engine(IReader reader, IWriter writer, IStage stage, IFestivalController festivalController, ISetController setController)
        {
            this.writer = writer;
            this.reader = reader;
            this.stage = stage;
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        public string ProcessCommand(string input)
        {
            string result = string.Empty;

            try
            {
                string[] inputs = input.Split();

                string command = inputs[0];
                string[] commandInputsList = inputs.Skip(1).ToArray();

                switch (command)
                {
                    case "RegisterSet":
                        result = (festivalCоntroller.RegisterSet(commandInputsList));
                        break;

                    case "SignUpPerformer":
                        result = (festivalCоntroller.SignUpPerformer(commandInputsList));
                        break;

                    case "RegisterSong":
                        result = (festivalCоntroller.RegisterSong(commandInputsList));
                        break;

                    case "AddSongToSet":
                        result = (festivalCоntroller.AddSongToSet(commandInputsList));
                        break;

                    case "AddPerformerToSet":
                        result = (festivalCоntroller.AddPerformerToSet(commandInputsList));
                        break;

                    case "RepairInstruments":
                        result = (festivalCоntroller.RepairInstruments(commandInputsList));
                        break;

                    case "LetsRock":
                        result = (setCоntroller.PerformSets());
                        break;

                    case "END":
                        result = festivalCоntroller.ProduceReport();
                        return result;

                    default:
                        break;
                }

                return result;

                //	string.Intern(input);

                //    var result = this.DoCommand(input);
                //    this.writer.WriteLine(result);
            }
            catch (Exception ex) // in case we run out of memory
            {
                // Fix this!!!! if needed
                result = ("ERROR: " + ex.Message);
                return result;
            }
        }

        // daigaz
        public void Run()
        {
            string input = string.Empty;

            while ((input = reader.ReadLine()) != endRunningString) // for job security
            {
                writer.WriteLine(ProcessCommand(input));
            }

            writer.WriteLine(ProcessCommand("END"));

            //    // string end = this.festivalController.Report();


            //    this.writer.WriteLine("Results:");
            //  //  this.writer.WriteLine(end);
            //}

            //public string DoCommand(string input)
            //{
            //    var chasti = input.Split(" ".ToCharArray().First());

            //    var purvoto = chasti.First();
            //    var parametri = chasti.Skip(1).ToArray();

            //    if (purvoto == "LetsRock")
            //    {
            //        var setovete = this.setController.PerformSets();
            //        return setovete;
            //    }

            //    var festivalcontrolfunction = this.festivalController.GetType()
            //        .GetMethods()
            //        .FirstOrDefault(x => x.Name == purvoto);

            //    string a;

            //    try
            //    {
            //        a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
            //    }
            //    catch (TargetInvocationException up)
            //    {
            //        throw up; // ha ha
            //    }

            //    return a;
            //}

            //public string ProcessCommand(string input)
            //{
            //    throw new NotImplementedException();
            //}
        }
    }
}