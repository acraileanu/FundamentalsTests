using System;

namespace FundamentalsTests.Trees.Helpers
{
  internal class BinarySearchTree<T> : BinaryTree<T>
    where T : IComparable<T>
  {
    internal int Count { get; private set; }

    internal override void Clear(){
      base.Clear();
      Count = 0;
    }

    internal bool Contains(T data)
    {
      return getNodeByValue(Root, data) != null;
    }

    internal void Add(T data)
    {
      var node = new BinaryTreeNode<T>(data);
      var parent = getParentNode(Root, data);

      if (parent == null)
      {
        Root = node;
        Count = 1;
      }
      else
      {
        var result = parent.Value.CompareTo(data);
        if ((result > 0) && (parent.Left == null))
        {
          parent.Left = node;
          Count++;
        }
        else if ((result < 0) && (parent.Right == null))
        {
          parent.Right = node;
          Count++;
        }
      }
    }

    internal bool Remove(T data)
    {
      if (Root == null)
      {
        return false;
      }

      int result;
      BinaryTreeNode<T> current;

      var parent = getParentNode(Root, data);
      if (parent == null)
      {
        current = Root;
      }
      else
      {
        result = parent.Value.CompareTo(data);
        if ((result > 0) && (parent.Left != null))
        {
          current = parent.Left;
        }
        else if ((result < 0) && (parent.Right != null))
        {
          current = parent.Right;
        }
        else
        {
          return false;
        }
      }

      BinaryTreeNode<T> nodeToLink;
      if (current.Right == null)
      {
        nodeToLink = current.Left;
      }
      else if (current.Right.Left == null)
      {
        current.Right.Left = current.Left;

        nodeToLink = current.Right;
      }
      else
      {
        BinaryTreeNode<T> leftmost = current.Right.Left, leftMostParent = current.Right;
        while (leftmost.Left != null)
        {
          leftMostParent = leftmost;
          leftmost = leftmost.Left;
        }

        leftMostParent.Left = leftmost.Right;

        leftmost.Left = current.Left;
        leftmost.Right = current.Right;

        nodeToLink = leftmost;
      }

      if (parent == null)
      {
        Root = nodeToLink;
      }
      else
      {
        result = parent.Value.CompareTo(current.Value);
        if (result > 0)
        {
          parent.Left = nodeToLink;
        }
        else
        {
          parent.Right = nodeToLink;
        }
      }

      Count--;

      return true;
    }

    private static BinaryTreeNode<T> getNodeByValue(BinaryTreeNode<T> current, T data){
      if (current == null)
      {
        return null;
      }

      var result = current.Value.CompareTo(data);
      if (result == 0)
      {
        return current;
      }
      else if (result > 0)
      {
        return getNodeByValue(current.Left, data);
      }

      return getNodeByValue(current.Right, data);
    }

    private static BinaryTreeNode<T> getParentNode(BinaryTreeNode<T> current, T data, BinaryTreeNode<T> parent = null){
      if (current == null)
      {
        return parent;
      }

      var result = current.Value.CompareTo(data);
      if (result == 0)
      {
        return parent;
      }
      else if (result > 0)
      {
        return getParentNode(current.Left, data, current);
      }

      return getParentNode(current.Right, data, current);
    }
  }
}
