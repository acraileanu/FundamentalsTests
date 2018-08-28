using System;
using FundamentalsTests.LinkedLists.Helpers.Queues;

namespace FundamentalsTests.Trees.Helpers
{
  internal class BinaryTree<T>
  {
    public BinaryTreeNode<T> Root { get; set; }

    internal BinaryTree()
    {
      Root = null;
    }

    internal virtual void Clear()
    {
      Root = null;
    }

    internal void PreOrderTraversal(Action<T> action)
    {
      preOrderTraversal(Root, action);
    }

    internal void PostOrderTraversal(Action<T> action)
    {
      postOrderTraversal(Root, action);
    }

    internal void InOrderTraversal(Action<T> action)
    {
      inOrderTraversal(Root, action);
    }

    internal void BreadthFirstTraversal(Action<T> action)
    {
      breadthFirstTraversal(action);
    }

    private void preOrderTraversal(BinaryTreeNode<T> current, Action<T> action)
    {
      if (current != null)
      {
        action(current.Value);

        preOrderTraversal(current.Left, action);
        preOrderTraversal(current.Right, action);
      }
    }

    private void postOrderTraversal(BinaryTreeNode<T> current, Action<T> action)
    {
      if (current != null)
      {
        postOrderTraversal(current.Left, action);
        postOrderTraversal(current.Right, action);

        action(current.Value);
      }
    }

    private void inOrderTraversal(BinaryTreeNode<T> current, Action<T> action)
    {
      if (current != null)
      {
        inOrderTraversal(current.Left, action);

        action(current.Value);

        inOrderTraversal(current.Right, action);
      }
    }

    private void breadthFirstTraversal(Action<T> action)
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
