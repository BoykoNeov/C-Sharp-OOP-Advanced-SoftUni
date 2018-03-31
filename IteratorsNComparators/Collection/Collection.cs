using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Collection<T> : IEnumerable<T>
{
    private List<T> internalList = new List<T>();
    private int internalIndex = 0;

    public Collection(params T[] collectionItems)
    {
        this.internalList.AddRange(collectionItems);
    }

    public Collection(IEnumerable<T> collection)
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

    public IEnumerable<T> PrintAll()
    {
        return this.internalList;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.internalList.Count; i++)
        {
            yield return this.internalList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}