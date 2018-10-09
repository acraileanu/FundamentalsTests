using System;

namespace FundamentalsTests.Trees.Helpers
{
  public sealed class BinaryTreeNode<T> : Node<T>
  {
    public BinaryTreeNode(T value, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null)
    {
      base.Value = value;

      if ((left != null) || (right != null))
      {
        base.LinkedNodes.Add(left);
        base.LinkedNodes.Add(right);
      }
    }

    public BinaryTreeNode<T> Left
    {
      get
      {
        return base.LinkedNodes.Count < 1 ? null : (BinaryTreeNode<T>)base.LinkedNodes[0];
      }
      set
      {
        if (base.LinkedNodes == null)
        {
          throw new InvalidOperationException("LinkedNodes is not initialized");
        }

        if (base.LinkedNodes.Count < 1)
        {
          base.LinkedNodes.Add(value);
        }
        else
        {
          base.LinkedNodes[0] = value;
        }
      }
    }

    public BinaryTreeNode<T> Right
    {
      get
      {
        return base.LinkedNodes.Count < 2 ? null : (BinaryTreeNode<T>)base.LinkedNodes[1];
      }
      set
      {
        if (base.LinkedNodes == null)
        {
          throw new InvalidOperationException("LinkedNodes is not initialized");
        }

        if (base.LinkedNodes.Count < 2)
        {
          if (base.LinkedNodes.Count < 1)
          {
            base.LinkedNodes.Add(null);
          }

          base.LinkedNodes.Add(value);
        }
        else
        {
          base.LinkedNodes[1] = value;
        }
      }
    }
  }
}
