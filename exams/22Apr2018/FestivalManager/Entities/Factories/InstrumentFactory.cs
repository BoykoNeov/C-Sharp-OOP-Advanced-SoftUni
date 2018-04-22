namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var instrumentType = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == type);
            return (IInstrument)Activator.CreateInstance(instrumentType);

            //if (type == "Drums")
            //{
            //	return new Drums();
            //}
            //else if (type == "Guitar")
            //{
            //	return new Guitar();
            //}
            //else
            //{
            //	return new Microphone();
            //}
        }
	}
}