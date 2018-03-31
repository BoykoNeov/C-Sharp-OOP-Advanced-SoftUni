using System;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T>
{
    private List<T> internalList = new List<T>();
    private int internalIndex = 0;

    public ListyIterator(params T[] collectionItems)
    {
        this.internalList.AddRange(collectionItems);
    }

    public ListyIterator(IEnumerable<T> collection)
    {
        this.internalList = collection.ToList();
    }


    public bool Move()
    {
        if (this.HasNext())
        {
            this.internalIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasNext()
    {
        if (this.internalIndex < this.internalList.Count - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public T Print()
    {
        if (this.internalList.Count > 0)
        {
            return this.internalList[internalIndex];
        }
        else
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }
}