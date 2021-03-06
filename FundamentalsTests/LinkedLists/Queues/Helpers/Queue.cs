using System;
using System.Collections.Generic;
using System.Text;
using FundamentalsTests.LinkedLists.Helpers;

namespace FundamentalsTests.LinkedLists.Queues.Helpers
{
  public sealed class Queue<T>
  {
    private Node<T> head;
    private Node<T> tail;

    public int Count { get; private set; }

    public Queue(IEnumerable<T> collection = null)
    {
      Clear();

      if (collection != null)
      {
        foreach (T item in collection)
        {
          Enqueue(item);
        }
      }
    }

    public void Clear()
    {
      head = tail = null;
      Count = 0;
    }

    public T Peek()
    {
      if (head == null)
      {
        throw new EmptyQueueException();
      }

      return head.Value;
    }

    public T Dequeue()
    {
      var value = Peek();
      head = head.Next;

      if (head == null)
      {
        tail = null;
      }

      Count--;

      return value;
    }

    public void Enqueue(T item)
    {
      var node = new Node<T>(item);

      if (head == null)
      {
        head = tail = node;
      }
      else
      {
        tail.Next = node;
        tail = node;
      }

      Count++;
    }

    public bool Contains(T item)
    {
      var node = head;

      while (node != null)
      {
        if (node.Value.Equals(item))
        {
          return true;
        }
        node = node.Next;
      }

      return false;
    }

    public override string ToString()
    {
      var output = new StringBuilder();
      var node = head;

      while (node != null)
      {
        output.AppendFormat("{0}, ", node.Value);
        node = node.Next;
      }

      if (output.Length > 2)
      {
        output.Length -= 2;
      }

      return $"<{output}> ({Count})";
    }
  }
}
