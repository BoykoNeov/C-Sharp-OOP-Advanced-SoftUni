using System;
using System.Linq;

namespace ExtendedDatabase
{
    public class Database<T> where T : IDatabaseItem
    {
        private const int AllowedDatabaseSize = 16;

        private int lastIndex;
        private T[] elements;

        public T[] Elements
        {
            get { return elements; }
            private set { elements = value; }
        }


        public Database()
        {
            this.Elements = new T[AllowedDatabaseSize];
            lastIndex = -1;
        }

        public Database(T[] elements)
        {
            if (elements.Length != 16)
            {
                throw new InvalidOperationException("Db length should be 16!");
            }
            else
            {
                this.Elements = (T[])elements.Clone();
                lastIndex = 15;
            }
        }

        public void Add(T element)
        {
            if (lastIndex >= 15)
            {
                throw new InvalidOperationException("Database is full!");
            }
            else if (this.Elements.Any(x => x.Id == element.Id))
            {
                throw new InvalidOperationException("Database already contains an element with such Id!");
            }
            else if (this.Elements.Any(x => x.Username == element.Username))
            {
                throw new InvalidOperationException("Database already contains an element with such Name");
            }
            else
            {
                lastIndex++;
                this.Elements[lastIndex] = element;
            }
            
        }

        public void Remove()
        {
            if (lastIndex < 0)
            {
                throw new InvalidOperationException("Database is empty");
            }
            else
            {
                lastIndex--;
            }
        }

        public T[] Fetch()
        {
            T[] returnArray = new T[lastIndex + 1];

            for (int i = 0; i <= lastIndex; i++)
            {
                returnArray[i] = this.Elements[i];
            }

            return returnArray;
        }
    }
}