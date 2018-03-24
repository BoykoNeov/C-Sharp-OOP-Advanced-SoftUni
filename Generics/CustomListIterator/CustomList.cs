using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> underlyingList = new List<T>();

    public int Count => this.underlyingList.Count;

    public void Add(T element)
    {
        this.underlyingList.Add(element);
    }

    public T Remove(int index)
    {
        if (this.underlyingList.Count == 0)
        {
            throw new InvalidOperationException("CustomList is empty!");
        }

        T element = underlyingList[index];
        this.underlyingList.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        return this.underlyingList.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        if (this.underlyingList.Count == 0)
        {
            throw new InvalidOperationException("CustomList is empty!");
        }

        T elementToSwap = this.underlyingList[index1];
        this.underlyingList[index1] = this.underlyingList[index2];
        this.underlyingList[index2] = elementToSwap;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < this.underlyingList.Count; i++)
        {
            if (element.CompareTo(this.underlyingList[i]) == -1)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        if(this.underlyingList.Count == 0)
        {
            throw new InvalidOperationException("CustomList is empty!");
        }

        T currentMaxElement = this.underlyingList[0];
        for (int i = 1; i < underlyingList.Count; i++)
        {
            if(currentMaxElement.CompareTo(underlyingList[i]) == -1)
            {
                currentMaxElement = underlyingList[i];
            }
        }

        return currentMaxElement;
    }

	public T Min()
    {
        if (this.underlyingList.Count == 0)
        {
            throw new InvalidOperationException("CustomList is empty!");
        }

        T currentMinElement = this.underlyingList[0];
        for (int i = 1; i < underlyingList.Count; i++)
        {
            if (currentMinElement.CompareTo(underlyingList[i]) == 1)
            {
                currentMinElement = underlyingList[i];
            }
        }

        return currentMinElement;
    }

    public int FirstIndexOf(T element)
    {
        if (this.underlyingList.Count == 0)
        {
            throw new InvalidOperationException("CustomList is empty!");
        }

        for (int i = 0; i < this.underlyingList.Count; i++)
        {
            if (element.Equals(underlyingList[i]))
            {
                return i;
            }
        }

        return -1;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in this.underlyingList)
        {
            sb.AppendLine(item.ToString());
        }

        return sb.ToString().Trim();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.underlyingList.Count; i++)
        {
            yield return underlyingList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}