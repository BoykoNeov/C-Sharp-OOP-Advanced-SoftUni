using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void Add(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var newTail = new ListNode<T>(element)
            {
                PrevNode = this.tail
            };
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }

        this.Count++;
    }

    public void Remove(T element)
    {
        ListNode<T> currentNode = this.head;

        while (currentNode != null)
        {
            if (currentNode.Value.Equals(element))
            {
                this.Count--;

                if (currentNode != this.head)
                {
                    currentNode.PrevNode.NextNode = currentNode.NextNode;
                }
                else
                {
                    this.head = currentNode.NextNode;
                }

                if (currentNode != this.tail)
                {
                    currentNode.NextNode.PrevNode = currentNode.PrevNode;
                }
                else
                {
                    this.tail = currentNode.PrevNode;
                }

                break;
            }

            currentNode = currentNode.NextNode;
        }
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        T firstElement = this.head.Value;
        this.head = this.head.NextNode;
        if (this.head != null)
        {
            this.head.PrevNode = null;
        }
        else
        {
            this.tail = null;
        }

        this.Count--;
        return firstElement;
    }

    public void Clear()
    {
        this.head = this.tail = null;
        Count = 0;
    }

    public void ForEach(Action<T> action)
    {
        DoublyLinkedList<T>.ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        DoublyLinkedList<T>.ListNode<T> curretNode = this.head;
        while (curretNode != null)
        {
            yield return curretNode.Value;
            curretNode = curretNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}