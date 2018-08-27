using NUnit.Framework;
using FundamentalsTests.LinkedLists.Helpers.Queues;

namespace FundamentalsTests.LinkedLists.Tests.Queues
{
  [TestFixture]
  public class QueueInitializationTests
  {
    [Test]
    public void NewQueueHasNoElements()
    {
      var queue = new Queue<int>();

      Assert.AreEqual(0, queue.Count);
      Assert.AreEqual("<> (0)", queue.ToString());
    }

    [Test]
    public void QueueWtihEmptyEnumerableHasNoElements()
    {
      var queue = new Queue<int>(new int[] {});

      Assert.AreEqual(0, queue.Count);
      Assert.AreEqual("<> (0)", queue.ToString());
    }

    [Test]
    public void QueueWithEnumerableHasEnumerationNumberOfElements()
    {
      var queue = new Queue<int>(new int[3]);

      Assert.AreEqual(3, queue.Count);
      Assert.AreEqual("<0, 0, 0> (3)", queue.ToString());
    }

    [Test]
    public void QueueWithEnumerableHasEnumerationElements()
    {
      var queue = new Queue<int>(new int[] {1, 2, 3});

      Assert.AreEqual(3, queue.Count);
      Assert.AreEqual("<1, 2, 3> (3)", queue.ToString());
    }
  }
}
