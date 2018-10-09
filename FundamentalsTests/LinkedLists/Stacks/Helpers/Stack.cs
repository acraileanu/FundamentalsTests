using System;
using System.Collections.Generic;
using System.Text;
using FundamentalsTests.LinkedLists.Helpers;

namespace FundamentalsTests.LinkedLists.Stacks.Helpers
{
  public sealed class Stack<T>
  {
    private Node<T> top;

    public int Count { get; private set; }

    public Stack(IEnumerable<T> collection = null)
    {
      Clear();

      if (collection != null)
      {
        foreach (T item in collection)
        {
          Push(item);
        }
      }
    }

    public void Clear()
    {
      top = null;
      Count = 0;
    }

    public T Peek()
    {
      if (top == null)
      {
        throw new EmptyStackException();
      }

      return top.Value;
    }

    public T Pop()
    {
      var value = Peek();
      top = top.Next;
      Count--;

      return value;
    }

    public void Push(T item)
    {
      top = new Node<T>(item, top);
      Count++;
    }

    public bool Contains(T item)
    {
      var node = top;

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
      var node = top;

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
