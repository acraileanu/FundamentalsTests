using System;
using System.Collections.Generic;
using System.Text;
using FundamentalsTests.LinkedLists.Helpers;

namespace FundamentalsTests.LinkedLists.Helpers.Stacks
{
  internal class Stack<T>
  {
    private Node<T> top { get; set; }

    internal int Count { get; set; }

    internal Stack(){
      Clear();
    }

    internal Stack(IEnumerable<T> collection) : this(){
      foreach (T item in collection)
      {
        Push(item);
      }
    }

    internal void Clear()
    {
      top = null;
      Count = 0;
    }

    internal T Peek()
    {
      if (top == null){
        throw new EmptyStackException();
      }
      return top.Value;
    }

    internal T Pop()
    {
      var value = Peek();
      top = top.Next;
      Count--;
      return value;
    }

    internal void Push(T item)
    {
      top = new Node<T>(item, top);
      Count++;
    }

    internal bool Contains(T item)
    {
      var node = top;
      while (node != null)
      {
        if (node.Value.Equals(item)){
          return true;
        }
        node = node.Next;
      }
      return false;
    }

    public override string ToString(){
      var output = new StringBuilder();
      var node = top;
      while (node != null){
        output.AppendFormat("{0}, ", node.Value);
        node = node.Next;
      }
      if (output.Length > 2){
        output.Length -= 2;
      }
      return $"<{output}> ({Count})";
    }
  }
}
