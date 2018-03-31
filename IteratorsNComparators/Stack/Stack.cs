using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private List<T> internalList = new List<T>();

    public Stack(params T[] collectionItems)
    {
        this.internalList.AddRange(collectionItems);
    }

    public Stack()
    {
    }

    public Stack(IEnumerable<T> collection)
    {
        this.internalList = collection.ToList();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = internalList.Count - 1; i >= 0; i--)
        {
            yield return this.internalList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Push (params T[] items)
    {
        this.internalList.AddRange(items);
    }

    public T Pop()
    {
        if(this.internalList.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }
        else
        {
            T itemToReturn = this.internalList.Last();
            this.internalList.RemoveAt(this.internalList.Count - 1);
            return itemToReturn;
        }
    }
}