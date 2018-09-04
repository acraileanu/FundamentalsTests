namespace FundamentalsTests.Trees.Helpers
{
  internal class BinaryTreeNode<T> : Node<T>
  {
    internal BinaryTreeNode() : base() {}
    internal BinaryTreeNode(T value, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null)
    {
      base.Value = value;

      if ((left != null) || (right != null))
      {
        var children = new NodeList<T>(2);
        children[0] = left;
        children[1] = right;

        base.LinkedNodes = children;
      }
    }

    internal BinaryTreeNode<T> Left
    {
      get
      {
        return base.LinkedNodes == null ? null : (BinaryTreeNode<T>)base.LinkedNodes[0];
      }
      set
      {
        if (base.LinkedNodes == null)
        {
          base.LinkedNodes = new NodeList<T>(2);
        }

        base.LinkedNodes[0] = value;
      }
    }

    internal BinaryTreeNode<T> Right
    {
      get
      {
        return base.LinkedNodes == null ? null : (BinaryTreeNode<T>)base.LinkedNodes[1];
      }
      set
      {
        if (base.LinkedNodes == null)
        {
          base.LinkedNodes = new NodeList<T>(2);
        }

        base.LinkedNodes[1] = value;
      }
    }
  }
}
