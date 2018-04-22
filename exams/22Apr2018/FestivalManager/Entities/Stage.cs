namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using Contracts;
    using System.Linq;

    public class Stage : IStage
    {
        private List<ISet> sets = new List<ISet>();
        private List<ISong> songs = new List<ISong>();
        private List<IPerformer> performers = new List<IPerformer>();

        public IReadOnlyCollection<ISet> Sets
        {
            get
            {
                return this.sets;
            }
        }

        public IReadOnlyCollection<ISong> Songs
        {
            get
            {
                return this.songs;
            }
        }

        public IReadOnlyCollection<IPerformer> Performers
        {
            get
            {
                return this.performers;
            }
        }

        public IPerformer GetPerformer(string name)
        {
            return this.Performers.FirstOrDefault(p => p.Name == name);
        }

        public ISong GetSong(string name)
        {
            return this.Songs.FirstOrDefault(s => s.Name == name);
        }

        public ISet GetSet(string name)
        {
            return this.Sets.FirstOrDefault(s => s.Name == name);
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public bool HasPerformer(string name)
        {
            IPerformer performer = this.GetPerformer(name);
            if (performer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSong(string name)
        {
            ISong song = this.GetSong(name);
            if (song == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSet(string name)
        {
            ISet set = this.GetSet(name);
            if (set == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }
    }
}