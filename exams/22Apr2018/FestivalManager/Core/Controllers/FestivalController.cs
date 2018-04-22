namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using System.Collections.Generic;
    using System.Reflection;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        //private const string TimeFormatLong = "{0:2D}:{1:2D}";
        //private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private ISetFactory setFactory = new SetFactory();
        private IInstrumentFactory instrumentFactory = new InstrumentFactory();
        private IPerformerFactory performerFactory = new PerformerFactory();
        private ISongFactory songFactory = new SongFactory();

        private readonly IStage stage;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
        }

        public string AddPerformerToSet(string[] args)
        {
            try
            {
                string performerName = args[0];
                string setName = args[1];

                IPerformer performer = this.stage.GetPerformer(performerName);
                if (performer == null)
                {
                    throw new InvalidOperationException("ERROR: Invalid performer provided");
                }

                ISet set = this.stage.GetSet(setName);
                if (set == null)
                {
                    throw new InvalidOperationException("ERROR: Invalid set provided");
                }

                set.AddPerformer(performer);
                return $"Added {performerName} to {setName}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AddSongToSet(string[] args)
        {
            try
            {
                string songName = args[0];
                string setName = args[1];

                ISet set = this.stage.GetSet(setName);
                if (set == null)
                {
                    throw new InvalidOperationException("ERROR: Invalid set provided");
                }

                ISong song = this.stage.GetSong(songName);
                if (song == null)
                {
                    throw new InvalidOperationException("ERROR: Invalid song provided");
                }

                set.AddSong(song);
                return $"Added {song.ToString()} to {setName}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();

            TimeSpan totalFestivalLength = new TimeSpan();

            sb.AppendLine("Results:");

            foreach (var set in this.stage.Sets)
            {
                foreach (var song in set.Songs)
                {
                    TimeSpan duration = song.Duration;
                    totalFestivalLength = totalFestivalLength.Add(duration);
                }
            }

            if (totalFestivalLength.TotalSeconds < 3600)
            {
                sb.AppendLine($"Festival length: {totalFestivalLength:mm\\:ss}");
            }
            else
            {
                int totalSeconds = (int)Math.Floor(totalFestivalLength.TotalSeconds);
                int minutesLength = totalSeconds / 60;
                int secondsLeft = totalSeconds % 60;

                if (minutesLength < 100)
                {
                    sb.AppendLine($"Festival length: {minutesLength:d2}:{secondsLeft:d2}");
                }
                else
                {
                    sb.AppendLine($"Festival length: {minutesLength}:{secondsLeft:d2}");
                }
            }

            foreach (var set in stage.Sets)
            {
                TimeSpan totalSetLength = new TimeSpan();
                foreach (var song in set.Songs)
                {
                    totalSetLength = totalSetLength.Add(song.Duration);
                }

                //  sb.AppendLine($"--{set.Name} ({totalSetLength:mm\\:ss}):");

                if (totalSetLength.TotalSeconds < 3600)
                {
                    sb.AppendLine($"--{set.Name} ({totalSetLength:mm\\:ss}):");
                }
                else
                {
                    int totalSeconds = (int)Math.Floor(totalSetLength.TotalSeconds);
                    int minutesLength = totalSeconds / 60;
                    int secondsLeft = totalSeconds % 60;

                    if (minutesLength < 100)
                    {
                        sb.AppendLine($"--{set.Name} ({minutesLength:d2}:{secondsLeft:d2}):");
                    }
                    else
                    {
                        sb.AppendLine($"--({minutesLength}:{secondsLeft:d2}):");
                    }
                }

                foreach (var performer in set.Performers.OrderByDescending(p => p.Age))
                {
                    List<string> performerInstruments = new List<string>(performer.Instruments.Count);

                    foreach (var instrument in performer.Instruments)
                    {
                        performerInstruments.Add(instrument.ToString());
                    }

                    sb.AppendLine($"---{performer.ToString()} ({string.Join(", ", performerInstruments)})");
                }

                if (set.Songs.Count == 0)
                {
                    sb.AppendLine("--No songs played");
                }
                else
                {
                    sb.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        sb.AppendLine($"----{song.ToString()}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string RegisterSet(string[] args)
        {
            try
            {
                string setName = args[0];
                string setType = args[1];

                ISet newSet = setFactory.CreateSet(setName, setType);
                this.stage.AddSet(newSet);

                return $"Registered {setType} set";
            }
            catch
            {
                // not by definition
                return "ERROR registering set";
            }
        }

        public string RegisterSong(string[] args)
        {
            try
            {
                string songName = args[0];
                string[] songDuration = args[1].Split(new char[] { ':' });
                int minutes = int.Parse(songDuration[0]);
                int seconds = int.Parse(songDuration[1]);
                TimeSpan timeSpan = new TimeSpan(0, minutes, seconds);

                ISong newSong = songFactory.CreateSong(songName, timeSpan);
                this.stage.AddSong(newSong);
                return $"Registered song {songName} ({minutes:d2}:{seconds:d2})";
            }
            catch
            {
                // not by definition
                return "ERROR creating song";
            }
        }

        public string RepairInstruments(string[] args)
        {
            int repairedInstrumentsCount = 0;

            foreach (IPerformer performer in this.stage.Performers)
            {
                foreach (IInstrument instrument in performer.Instruments)
                {
                    if (instrument.Wear < 100)
                    {
                        repairedInstrumentsCount++;
                        instrument.Repair();
                    }
                }
            }

            return $"Repaired {repairedInstrumentsCount} instruments";
        }

        public string SignUpPerformer(string[] args)
        {
            try
            {
                List<string> arguments = args.ToList();
                string performerName = arguments[0];
                int performerAge = int.Parse(arguments[1]);

                arguments.RemoveAt(0);
                arguments.RemoveAt(0);

                List<IInstrument> performerInstruments = new List<IInstrument>();
                IPerformer newPerformer = this.performerFactory.CreatePerformer(performerName, performerAge);

                for (int i = 0; i < arguments.Count; i++)
                {
                    IInstrument newInstrument = this.instrumentFactory.CreateInstrument(arguments[i]);
                    newPerformer.AddInstrument(newInstrument);
                }

                this.stage.AddPerformer(newPerformer);
                return $"Registered performer {performerName}";
            }
            catch
            {
                // not by definition
                return "ERROR signign performer";
            }
        }

        //public string Report()
        //{
        //	var result = string.Empty;

        //	var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

        //	result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

        //	foreach (var set in this.stage.Sets)
        //	{
        //		result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

        //		var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
        //		foreach (var performer in performersOrderedDescendingByAge)
        //		{
        //			var instruments = string.Join(", ", performer.Instruments
        //				.OrderByDescending(i => i.Wear));

        //			result += ($"---{performer.Name} ({instruments})") + "\n";
        //		}

        //		if (!set.Songs.Any())
        //			result += ("--No songs played") + "\n";
        //		else
        //		{
        //			result += ("--Songs played:") + "\n";
        //			foreach (var song in set.Songs)
        //			{
        //				result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
        //			}
        //		}
        //	}

        //	return result.ToString();
        //}

        //public string RegisterSet(string[] args)
        //{
        //	throw new NotImplementedException(); // оф...
        //}

        //public string SignUpPerformer(string[] args)
        //{
        //	var name = args[0];
        //	var age = int.Prase(args[1]);

        //	var instrumenti = args.Skip(2).ToArray();

        //	var instrumenti2 = instrumenti
        //		.Select(i => this.instrumentFactory.CreateInstrument(i))
        //		.ToArray();

        //	var performer = this.performerFactory.CreatePerformer(name, age);

        //	foreach (var instrument in instrumenti2)
        //	{
        //		performer.AddInstrument(instrument);
        //	}

        //	this.stage.AddPerformer(performer);

        //	return $"Registered performer {performer.Name}";
        //}

        //public string RegisterSong(string[] args)
        //{
        //	// TODO: scheduled for next month

        //	return $"Registered song {song}";
        //}

        //public string SongRegistration(string[] args)
        //{
        //	var songName = args[0];
        //	var setName = args[1];

        //	if (!this.stage.HasSet(setName))
        //	{
        //		throw new InvalidOperationException("Invalid set provided");
        //	}

        //	if (!this.stage.HasSong(songName))
        //	{
        //		throw new InvalidOperationException("Invalid song provided");
        //	}

        //	var set = this.stage.GetSet(setName);
        //	var song = this.stage.GetSong(songName);

        //	set.AddSong(song);

        //	return $"Added {song} to {set.Name}";
        //}

        //// Временно!!! Чтобы работало делаем срез на конец месяца
        //public string AddPerformerToSet(string[] args)
        //{
        //	return PerformerRegistration(args);
        //}

        //public string PerformerRegistration(string[] args)
        //{
        //	var performerName = args[0];
        //	var setName = args[1];

        //	if (!this.stage.HasPerformer(performerName))
        //	{
        //		throw new InvalidOperationException("Invalid performer provided");
        //	}

        //	if (!this.stage.HasSet(setName))
        //	{
        //		throw new InvalidOperationException("Invalid set provided");
        //	}

        //	AddPerformerToSet(args);

        //	var performer = this.stage.GetPerformer(performerName);
        //	var set = this.stage.GetSet(setName);

        //	set.AddPerformer(performer);

        //	return $"Added {performer.Name} to {set.Name}";
        //}

        //public string RepairInstruments(string[] args)
        //{
        //	var instrumentsToRepair = this.stage.Performers
        //		.SelectMany(p => p.Instruments)
        //		.Where(i => i.Wear <= 100)
        //		.ToArray();

        //	foreach (var instrument in instrumentsToRepair)
        //	{
        //		instrument.Repair();
        //	}

        //	return $"Repaired {instrumentsToRepair.Length} instruments";
        //}
    }
}