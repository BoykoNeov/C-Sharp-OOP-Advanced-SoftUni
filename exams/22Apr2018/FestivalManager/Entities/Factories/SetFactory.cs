namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var setType = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == type);
            ISet newSet = (ISet)Activator.CreateInstance(setType, name);
            return newSet;
		}
	}
}