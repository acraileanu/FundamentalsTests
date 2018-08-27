using System;
using System.Collections.Generic;
using System.Text;
using FundamentalsTests.LinkedLists.Helpers;

namespace FundamentalsTests.LinkedLists.Helpers.Queues
{
  internal class Queue<T>
  {
    private Node<T> head;
    private Node<T> tail;
    private int count;

    internal Queue()
    {
      Clear();
    }

    internal Queue(IEnumerable<T> collection) : this()
    {
      foreach (T item in collection)
      {
        Enqueue(item);
      }
    }

    internal void Clear()
    {
      head = tail = null;
      count = 0;
    }

    internal T Peek()
    {
      if (head == null)
      {
        throw new EmptyQueueException();
      }
      return head.Value;
    }

    internal T Dequeue()
    {
      var value = Peek();
      head = head.Next;
      if (head == null)
      {
        tail = null;
      }
      count--;
      return value;
    }

    internal void Enqueue(T item)
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
      count++;
    }

    internal bool Contains(T item)
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
      return $"<{output}> ({count})";
    }

    internal int Count
    {
      get
      {
        return count;
      }
      set
      {
        count = value;
      }
    }
  }
}
