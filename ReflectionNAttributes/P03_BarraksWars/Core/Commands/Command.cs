namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public string[] Data { get => data; private set => data = value; }
        public IRepository Repository { get => repository; private set => repository = value; }
        public IUnitFactory UnitFactory { get => unitFactory; private set => unitFactory = value; }

        public abstract string Execute();
    }
}