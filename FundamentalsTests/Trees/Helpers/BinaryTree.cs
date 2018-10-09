using System;
using System.Collections.Generic;

namespace FundamentalsTests.Trees.Helpers
{
  public class BinaryTree<T>
  {
    public BinaryTreeNode<T> Root { get; set; }

    public BinaryTree()
    {
      Root = null;
    }

    public virtual void Clear()
    {
      Root = null;
    }

    public void PreOrderTraversal(Action<T> action)
    {
      TraversePreOrder(Root, action);
    }

    public void PostOrderTraversal(Action<T> action)
    {
      TraversePostOrder(Root, action);
    }

    public void InOrderTraversal(Action<T> action)
    {
      TraverseInOrder(Root, action);
    }

    public void BreadthFirstTraversal(Action<T> action)
    {
      TraverseBreadthFirst(action);
    }

    private void TraversePreOrder(BinaryTreeNode<T> current, Action<T> action)
    {
      if (current != null)
      {
        action(current.Value);

        TraversePreOrder(current.Left, action);
        TraversePreOrder(current.Right, action);
      }
    }

    private void TraversePostOrder(BinaryTreeNode<T> current, Action<T> action)
    {
      if (current != null)
      {
        TraversePostOrder(current.Left, action);
        TraversePostOrder(current.Right, action);

        action(current.Value);
      }
    }

    private void TraverseInOrder(BinaryTreeNode<T> current, Action<T> action)
    {
      if (current != null)
      {
        TraverseInOrder(current.Left, action);

        action(current.Value);

        TraverseInOrder(current.Right, action);
      }
    }

    private void TraverseBreadthFirst(Action<T> action)
    {
      if (Root == null)
      {
        return;
      }

      var queue = new Queue<BinaryTreeNode<T>>(new[] { Root });

      while (queue.Count > 0)
      {
        var currentNode = queue.Dequeue();

        if (currentNode.Left != null)
        {
          queue.Enqueue(currentNode.Left);
        }
        if (currentNode.Right != null)
        {
          queue.Enqueue(currentNode.Right);
        }

        action(currentNode.Value);
      }
    }
  }
}
