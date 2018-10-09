using System;

namespace FundamentalsTests.Trees.Helpers
{
  public sealed class BinarySearchTree<T> : BinaryTree<T>
    where T : IComparable<T>
  {
    public int Count { get; private set; }

    public override void Clear()
    {
      base.Clear();
      Count = 0;
    }

    public bool Contains(T data)
    {
      return GetNodeByValue(Root, data) != null;
    }

    public void Add(T data)
    {
      var node = new BinaryTreeNode<T>(data);
      var parent = GetParentNode(Root, data);

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

    public bool Remove(T data)
    {
      if (Root == null)
      {
        return false;
      }

      var parent = GetParentNode(Root, data);
      var current = GetNodeByParentAndData(parent, data);

      if (current == null)
      {
        return false;
      }

      var replacementNode = GetReplacementNode(current);

      ReplaceNode(replacementNode, parent, current.Value);

      Count--;

      return true;
    }

    private void ReplaceNode(BinaryTreeNode<T> replacementNode, BinaryTreeNode<T> parent, T compareValue)
    {
      if (parent == null)
      {
        Root = replacementNode;
      }
      else
      {
        var result = parent.Value.CompareTo(compareValue);
        if (result > 0)
        {
          parent.Left = replacementNode;
        }
        else
        {
          parent.Right = replacementNode;
        }
      }
    }

    private static BinaryTreeNode<T> GetReplacementNode(BinaryTreeNode<T> current)
    {
      if (current.Right == null)
      {
        return current.Left;
      }
      else if (current.Right.Left == null)
      {
        current.Right.Left = current.Left;

        return current.Right;
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

        return leftmost;
      }
    }

    private BinaryTreeNode<T> GetNodeByParentAndData(BinaryTreeNode<T> parent, T data)
    {
      if (parent == null)
      {
        return Root;
      }
      else
      {
        var result = parent.Value.CompareTo(data);
        if ((result > 0) && (parent.Left != null))
        {
          return parent.Left;
        }
        else if ((result < 0) && (parent.Right != null))
        {
          return parent.Right;
        }
        else
        {
          return null;
        }
      }
    }

    private static BinaryTreeNode<T> GetNodeByValue(BinaryTreeNode<T> current, T data)
    {
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
        return GetNodeByValue(current.Left, data);
      }

      return GetNodeByValue(current.Right, data);
    }

    private static BinaryTreeNode<T> GetParentNode(BinaryTreeNode<T> current, T data, BinaryTreeNode<T> parent = null)
    {
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
        return GetParentNode(current.Left, data, current);
      }

      return GetParentNode(current.Right, data, current);
    }
  }
}
