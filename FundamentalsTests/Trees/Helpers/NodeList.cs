using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FundamentalsTests.Trees.Helpers
{
  internal class NodeList<T> : Collection<Node<T>>
  {
    internal NodeList(int initialSize = 0)
    {
      for (var index = 0; index < initialSize; index++)
      {
        base.Items.Add(default(Node<T>));
      }
    }
    internal NodeList(IList<T> list) : base()
    {
      foreach (var item in list)
      {
        base.Items.Add(new Node<T>(item));
      }
    }

    internal Node<T> FindByValue(T value)
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
