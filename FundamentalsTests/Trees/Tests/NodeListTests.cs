using System;
using NUnit.Framework;
using FundamentalsTests.Trees.Helpers;

namespace FundamentalsTests.Trees.Tests
{
  [TestFixture]
  public class NodeListTests
  {
    const int value = 123;
    private readonly int[] values = { 11, 32, 53, 74, 95 };

    private NodeList<int> getPrepopulatedNodeList()
    {
      return new NodeList<int>(values);
    }

    private NodeList<int> getSizedNodeList(int size)
    {
      return new NodeList<int>(size);
    }

    private NodeList<int> getEmptyNodeList()
    {
      return new NodeList<int>();
    }

    [Test]
    public void EmptyNodeListHasNoElements()
    {
      var nodeList = getEmptyNodeList();

      Assert.AreEqual(0, nodeList.Count);
    }

    [Test]
    public void SizedNodeListHasSizeNumberOfElements()
    {
      var random = new Random();
      var size = random.Next(1, 10);
      var nodeList = getSizedNodeList(size);

      Assert.AreEqual(size, nodeList.Count);
      Assert.IsNull(nodeList[0]);
    }

    [Test]
    public void ValuedNodeListHasElements()
    {
      var nodeList = getPrepopulatedNodeList();

      Assert.AreEqual(values.Length, nodeList.Count);
      for (var index = 0; index < values.Length; index++)
      {
        Assert.AreEqual(values[index], nodeList[index].Value);
      }
    }

    [Test]
    public void ElementInNodeListIsFound()
    {
      var nodeList = getPrepopulatedNodeList();

      Assert.IsNotNull(nodeList.FindByValue(values[0]));
    }

    [Test]
    public void ElementNotInNodeListIsNotFound()
    {
      var nodeList = getPrepopulatedNodeList();

      Assert.IsNull(nodeList.FindByValue(value));
    }
  }
}
