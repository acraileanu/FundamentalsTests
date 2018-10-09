using System;
using NUnit.Framework;
using FundamentalsTests.Trees.Helpers;
using System.Collections.Generic;

namespace FundamentalsTests.Trees.Tests
{
  [TestFixture]
  public class BinarySearchTreeTests
  {
    const int value = 123;
    private static readonly int[] values = { 11, 32, 53, 74, 95, 116, 137, 158, 179 };

    private static BinarySearchTree<int> GetPrepopulatedBinarySearchTree()
    {
      //             95
      //       53          137
      //   11      74   116     179
      //      32              158
      var binarySearchTree = new BinarySearchTree<int>();

      binarySearchTree.Add(values[4]);
      binarySearchTree.Add(values[2]);
      binarySearchTree.Add(values[6]);
      binarySearchTree.Add(values[0]);
      binarySearchTree.Add(values[3]);
      binarySearchTree.Add(values[1]);
      binarySearchTree.Add(values[5]);
      binarySearchTree.Add(values[8]);
      binarySearchTree.Add(values[7]);

      return binarySearchTree;
    }

    private static BinarySearchTree<int> GetEmptyBinarySearchTree()
    {
      return new BinarySearchTree<int>();
    }

    [Test]
    public void EmptyBinarySearchTreeHasNoElements()
    {
      var binarySearchTree = GetEmptyBinarySearchTree();

      Assert.AreEqual(0, binarySearchTree.Count);
    }

    [Test]
    public void ClearingBinarySearchTreeRemovesAllElements()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var existingValue = values[3];

      Assert.IsTrue(binarySearchTree.Contains(existingValue));

      binarySearchTree.Clear();

      Assert.AreEqual(0, binarySearchTree.Count);
      Assert.IsFalse(binarySearchTree.Contains(existingValue));
    }

    [Test]
    public void AddingElementToEmptyBinarySearchTreeSetsItAsRoot()
    {
      var binarySearchTree = GetEmptyBinarySearchTree();

      binarySearchTree.Add(value);

      Assert.AreEqual(value, binarySearchTree.Root.Value);
    }

    [Test]
    public void AddingSmallerElementToBinarySearchTreeRootSetsItAsLeftNode()
    {
      var binarySearchTree = GetEmptyBinarySearchTree();

      binarySearchTree.Add(values[1]);
      binarySearchTree.Add(values[0]);

      Assert.AreEqual(values[1], binarySearchTree.Root.Value);
      Assert.AreEqual(values[0], binarySearchTree.Root.Left.Value);
    }

    [Test]
    public void AddingLargerElementToBinarySearchTreeRootSetsItAsRightNode()
    {
      var binarySearchTree = GetEmptyBinarySearchTree();

      binarySearchTree.Add(values[1]);
      binarySearchTree.Add(values[2]);

      Assert.AreEqual(values[1], binarySearchTree.Root.Value);
      Assert.AreEqual(values[2], binarySearchTree.Root.Right.Value);
    }

    [Test]
    public void AddingNewElementToPrepopulatedBinarySearchTreeSetsItAsRightNode()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();

      binarySearchTree.Add(value);

      Assert.AreEqual(value, binarySearchTree.Root.Right.Left.Right.Value);
    }

    [Test]
    public void AddedElementIsFoundInBinarySearchTree()
    {
      var binarySearchTree = GetEmptyBinarySearchTree();
      binarySearchTree.Add(value);

      Assert.IsTrue(binarySearchTree.Contains(value));
    }

    [Test]
    public void NonAddedElementIsMissingFromBinarySearchTree()
    {
      var binarySearchTree = GetEmptyBinarySearchTree();
      binarySearchTree.Add(value);

      Assert.IsFalse(binarySearchTree.Contains(value + 1));
    }

    [Test]
    public void RemovingElementFromBinarySearchTreeUsesTheRightLeftMostNode()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var right = binarySearchTree.Root.Right.Left;

      var removed = binarySearchTree.Remove(binarySearchTree.Root.Value);

      Assert.AreEqual(right.Value, binarySearchTree.Root.Value);
      Assert.IsTrue(removed);
    }

    [Test]
    public void RemovingLeftLeafElementFromBinarySearchTreeMakesNoChangesInStructure()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var removeValue = values[7];
      var expected = new List<int>();
      binarySearchTree.PreOrderTraversal(expected.Add);
      expected.Remove(removeValue);
      var result = new List<int>();

      var removed = binarySearchTree.Remove(removeValue);
      binarySearchTree.PreOrderTraversal(result.Add);

      Assert.AreEqual(expected, result);
      Assert.IsTrue(removed);
    }

    [Test]
    public void RemovingRightLeafElementFromBinarySearchTreeMakesNoChangesInStructure()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var removeValue = values[1];
      var expected = new List<int>();
      binarySearchTree.PreOrderTraversal(expected.Add);
      expected.Remove(removeValue);
      var result = new List<int>();

      var removed = binarySearchTree.Remove(removeValue);
      binarySearchTree.PreOrderTraversal(result.Add);

      Assert.AreEqual(expected, result);
      Assert.IsTrue(removed);
    }

    [Test]
    public void RemovingElementWithRightButNoRightLeftFromBinarySearchTreeUseRightNode()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var removeValue = values[3];
      var expected = new List<int>();
      binarySearchTree.PreOrderTraversal(expected.Add);
      expected.Remove(removeValue);
      var result = new List<int>();

      var removed = binarySearchTree.Remove(removeValue);
      binarySearchTree.PreOrderTraversal(result.Add);

      Assert.AreEqual(expected, result);
      Assert.IsTrue(removed);
    }

    [Test]
    public void RemovedElementIsMissingFromBinarySearchTree()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var removeValue = values[3];

      Assert.IsTrue(binarySearchTree.Contains(removeValue));

      var removed = binarySearchTree.Remove(removeValue);

      Assert.IsFalse(binarySearchTree.Contains(removeValue));
      Assert.IsTrue(removed);
    }

    [Test]
    public void AddingElementToBinarySearchTreeIncreasesSize()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var count = binarySearchTree.Count;

      Assert.IsFalse(binarySearchTree.Contains(value));

      binarySearchTree.Add(value);

      Assert.AreEqual(count + 1, binarySearchTree.Count);
      Assert.IsTrue(binarySearchTree.Contains(value));
    }

    [Test]
    public void AddingExistingElementToBinarySearchTreeDoesNotIncreaseSize()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var count = binarySearchTree.Count;
      var addValue = values[3];

      Assert.IsTrue(binarySearchTree.Contains(addValue));

      binarySearchTree.Add(addValue);

      Assert.AreEqual(count, binarySearchTree.Count);
      Assert.IsTrue(binarySearchTree.Contains(addValue));
    }

    [Test]
    public void RemovingElementFromBinarySearchTreeDecreasesSize()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var count = binarySearchTree.Count;
      var removeValue = values[6];

      Assert.IsTrue(binarySearchTree.Contains(removeValue));

      binarySearchTree.Remove(values[6]);

      Assert.AreEqual(count - 1, binarySearchTree.Count);
      Assert.IsFalse(binarySearchTree.Contains(removeValue));
    }

    [Test]
    public void RemovingNonExistingElementFromBinarySearchTreeDoesNotDecreaseSize()
    {
      var binarySearchTree = GetPrepopulatedBinarySearchTree();
      var count = binarySearchTree.Count;

      Assert.IsFalse(binarySearchTree.Contains(value));

      var removed = binarySearchTree.Remove(value);

      Assert.AreEqual(count, binarySearchTree.Count);
      Assert.IsFalse(binarySearchTree.Contains(value));
      Assert.IsFalse(removed);
    }
  }
}
