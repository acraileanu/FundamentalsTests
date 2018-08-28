using System;
using NUnit.Framework;
using FundamentalsTests.Trees.Helpers;
using System.Collections.Generic;

namespace FundamentalsTests.Trees.Tests
{
  [TestFixture]
  public class BinaryTreeTests
  {
    private static readonly int[] values = { 11, 32, 53, 74, 95, 116, 137, 158, 179 };

    private static BinaryTree<int> getPrepopulatedBinaryTree()
    {
      //             95
      //       53          137
      //   11      74   116     179
      //      32              158
      var binaryTree = new BinaryTree<int>();

      binaryTree.Root = new BinaryTreeNode<int>(values[4]);
      binaryTree.Root.Left = new BinaryTreeNode<int>(values[2]);
      binaryTree.Root.Right = new BinaryTreeNode<int>(values[6]);
      binaryTree.Root.Left.Left = new BinaryTreeNode<int>(values[0]);
      binaryTree.Root.Left.Right = new BinaryTreeNode<int>(values[3]);
      binaryTree.Root.Left.Left.Right = new BinaryTreeNode<int>(values[1]);
      binaryTree.Root.Right.Left = new BinaryTreeNode<int>(values[5]);
      binaryTree.Root.Right.Right = new BinaryTreeNode<int>(values[8]);
      binaryTree.Root.Right.Right.Left = new BinaryTreeNode<int>(values[7]);

      return binaryTree;
    }

    private static BinaryTree<int> getEmptyBinaryTree()
    {
      return new BinaryTree<int>();
    }

    [Test]
    public void EmptyBinaryTreeHasNoElements()
    {
      var binaryTree = getEmptyBinaryTree();

      Assert.IsNull(binaryTree.Root);
    }

    [Test]
    public void ClearingBinaryTreeRemovesAllElements()
    {
      var binaryTree = getPrepopulatedBinaryTree();

      binaryTree.Clear();

      Assert.IsNull(binaryTree.Root);
    }

    [Test]
    public void PreOrderTraversalEmptyBinaryTreeReturnsNoElements()
    {
      var binaryTree = getEmptyBinaryTree();
      var result = new List<int>();

      binaryTree.PreOrderTraversal(result.Add);

      Assert.IsEmpty(result);
    }

    [Test]
    public void PreOrderTraversalBinaryTreeReturnsElementsInCorrectOrder()
    {
      var binaryTree = getPrepopulatedBinaryTree();
      var result = new List<int>();
      var expected = new List<int> { 95, 53, 11, 32, 74, 137, 116, 179, 158 };

      binaryTree.PreOrderTraversal(result.Add);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void PostOrderTraversalEmptyBinaryTreeReturnsNoElements()
    {
      var binaryTree = getEmptyBinaryTree();
      var result = new List<int>();

      binaryTree.PostOrderTraversal(result.Add);

      Assert.IsEmpty(result);
    }

    [Test]
    public void PostOrderTraversalBinaryTreeReturnsElementsInCorrectOrder()
    {
      var binaryTree = getPrepopulatedBinaryTree();
      var result = new List<int>();
      var expected = new List<int> { 32, 11, 74, 53, 116, 158, 179, 137, 95 };

      binaryTree.PostOrderTraversal(result.Add);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void InOrderTraversalEmptyBinaryTreeReturnsNoElements()
    {
      var binaryTree = getEmptyBinaryTree();
      var result = new List<int>();

      binaryTree.InOrderTraversal(result.Add);

      Assert.IsEmpty(result);
    }

    [Test]
    public void InOrderTraversalBinaryTreeReturnsElementsInCorrectOrder()
    {
      var binaryTree = getPrepopulatedBinaryTree();
      var result = new List<int>();
      var expected = new List<int> { 11, 32, 53, 74, 95, 116, 137, 158, 179 };

      binaryTree.InOrderTraversal(result.Add);

      Console.WriteLine(result);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void BreadthFirstTraversalEmptyBinaryTreeReturnsNoElements()
    {
      var binaryTree = getEmptyBinaryTree();
      var result = new List<int>();

      binaryTree.BreadthFirstTraversal(result.Add);

      Assert.IsEmpty(result);
    }

    [Test]
    public void BreadthFirstTraversalBinaryTreeReturnsElementsInCorrectOrder()
    {
      var binaryTree = getPrepopulatedBinaryTree();
      var result = new List<int>();
      var expected = new List<int> { 95, 53, 137, 11, 74, 116, 179, 32, 158 };

      binaryTree.BreadthFirstTraversal(result.Add);

      Assert.AreEqual(expected, result);
    }
  }
}
