using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FundamentalsTests.Trees.Helpers
{
  public sealed class NodeListCollection<T> : Collection<Node<T>>
  {
    public NodeListCollection(int initialSize = 0)
    {
      for (var index = 0; index < initialSize; index++)
      {
        base.Items.Add(default(Node<T>));
      }
    }

    public NodeListCollection(IList<T> list) : base()
    {
      foreach (var item in list)
      {
        base.Items.Add(new Node<T>(item));
      }
    }

    public Node<T> FindByValue(T value)
    {
      foreach (var node in Items)
      {
        if (node.Value.Equals(value))
        {
          return node;
        }
      }

      return null;
    }
  }
}
