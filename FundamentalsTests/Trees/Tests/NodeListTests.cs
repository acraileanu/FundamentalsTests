using System;
using NUnit.Framework;
using FundamentalsTests.Trees.Helpers;

namespace FundamentalsTests.Trees.Tests
{
  [TestFixture]
  public class NodeListTests
  {
    const int value = 123;
    private static readonly int[] values = { 11, 32, 53, 74, 95 };

    private static NodeListCollection<int> GetPrepopulatedNodeList()
    {
      return new NodeListCollection<int>(values);
    }

    private static NodeListCollection<int> GetSizedNodeList(int size)
    {
      return new NodeListCollection<int>(size);
    }

    private static NodeListCollection<int> GetEmptyNodeList()
    {
      return new NodeListCollection<int>();
    }

    [Test]
    public void EmptyNodeListHasNoElements()
    {
      var nodeList = GetEmptyNodeList();

      Assert.AreEqual(0, nodeList.Count);
    }

    [Test]
    public void SizedNodeListHasSizeNumberOfElements()
    {
      var random = new Random();
      var size = random.Next(1, 10);
      var nodeList = GetSizedNodeList(size);

      Assert.AreEqual(size, nodeList.Count);
      Assert.IsNull(nodeList[0]);
    }

    [Test]
    public void ValuedNodeListHasElements()
    {
      var nodeList = GetPrepopulatedNodeList();

      Assert.AreEqual(values.Length, nodeList.Count);
      for (var index = 0; index < values.Length; index++)
      {
        Assert.AreEqual(values[index], nodeList[index].Value);
      }
    }

    [Test]
    public void ElementInNodeListIsFound()
    {
      var nodeList = GetPrepopulatedNodeList();

      Assert.IsNotNull(nodeList.FindByValue(values[0]));
    }

    [Test]
    public void ElementNotInNodeListIsNotFound()
    {
      var nodeList = GetPrepopulatedNodeList();

      Assert.IsNull(nodeList.FindByValue(value));
    }
  }
}
