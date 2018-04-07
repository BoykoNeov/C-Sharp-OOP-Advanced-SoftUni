using System;

namespace Database_01
{
    public class Database
    {
        private const int AllowedDatabaseSize = 16;

        private int lastIndex;
        private int[] ints;

        public int[] Ints
        {
            get { return ints; }
            private set { ints = value; }
        }


        public Database()
        {
            this.Ints = new int[AllowedDatabaseSize];
            lastIndex = -1;
        }

        public Database(int[] ints)
        {
            if (ints.Length != 16)
            {
                throw new InvalidOperationException("Db length should be 16!");
            }
            else
            {
                this.Ints = (int[])ints.Clone();
                lastIndex = 15;
            }
        }

        public void Add(int number)
        {
            if (lastIndex >= 15)
            {
                throw new InvalidOperationException("Database is full!");
            }
            else
            {
                lastIndex++;
                this.Ints[lastIndex] = number;
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

        public int[] Fetch()
        {
            int[] returnArray = new int[lastIndex + 1];

            for (int i = 0; i <= lastIndex; i++)
            {
                returnArray[i] = this.Ints[i];
            }

            return returnArray;
        }
    }
}