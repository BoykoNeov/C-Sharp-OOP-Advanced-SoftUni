using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    public class ListIterator
    {
        private List<string> elements;
        private int index = 0;
        private string lastPrinted = null;

        public ListIterator(params string[] arguments)
        {
            if (arguments == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.elements = arguments.ToList();
            }
        }

        public bool HasNext()
        {
            if (index + 1 == this.elements.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.lastPrinted = elements[index];
            Console.WriteLine(lastPrinted);
        }
    }
}