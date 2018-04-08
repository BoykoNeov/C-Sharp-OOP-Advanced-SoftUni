using System.Collections.Generic;

namespace ExtendedDatabase
{
    public class Person : IDatabaseItem
    {
        private int id;
        private string username;

        public Person(int id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            if (!this.Username.Equals(other.Username))
            {
                return false;
            }
            else
            {
                return this.Id.Equals(other.Id);
            }
        }

        public override int GetHashCode()
        {
            var hashCode = 738974913;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }
    }
}