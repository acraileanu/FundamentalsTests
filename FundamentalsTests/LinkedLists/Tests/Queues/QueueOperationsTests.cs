using NUnit.Framework;
using FundamentalsTests.LinkedLists.Helpers.Queues;

namespace FundamentalsTests.LinkedLists.Tests.Queues
{
  [TestFixture]
  public class QueueOperationsTests
  {
    const int value = 123;
    private readonly int[] values = { 11, 32, 53, 74, 95 };
    private Queue<int> queue;

    [SetUp]
    public void Initialize()
    {
      queue = new Queue<int>(values);
    }

    [Test]
    public void ClearingQueueRemovesAllElements()
    {
      queue.Clear();

      Assert.AreEqual(0, queue.Count);
    }

    [Test]
    public void DequeueingFromEmptyQueueRaisesException()
    {
      queue.Clear();

      Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }

    [Test]
    public void PeekingIntoEmptyQueueRaisesException()
    {
      queue.Clear();

      Assert.Throws<EmptyQueueException>(() => queue.Peek());
    }

    [Test]
    public void EnqueueingToQueueIncreasesSize()
    {
      var count = queue.Count;

      queue.Enqueue(value);

      Assert.AreEqual(count + 1, queue.Count);
    }

    [Test]
    public void DequeueingFromQueueDecreasesSize()
    {
      var count = queue.Count;

      queue.Dequeue();

      Assert.AreEqual(count - 1, queue.Count);
    }

    [Test]
    public void DequeueingFromQueueReturnsPeekedElement()
    {
      var peek = queue.Peek();
      var dequeued = queue.Dequeue();

      Assert.AreEqual(peek, dequeued);
      Assert.AreNotEqual(queue.Peek(), dequeued);
    }

    [Test]
    public void DequeueingFromQueueReturnsEnqueuedValues()
    {
      queue.Clear();
      for (var enqueueIndex = 0; enqueueIndex < values.Length; enqueueIndex++){
        queue.Enqueue(values[enqueueIndex]);
      }

      for (var dequeueIndex = 0; dequeueIndex < values.Length; dequeueIndex++){
      {
        Assert.AreEqual(values[dequeueIndex], queue.Dequeue());
      }
    }

    [Test]
    public void EnqueuedElementIsFoundInQueue()
    {
      queue.Clear();
      queue.Enqueue(value);

      Assert.IsTrue(queue.Contains(value));
    }

    [Test]
    public void NonEnqueuedElementIsMissingFromQueue()
    {
      queue.Clear();
      queue.Enqueue(value);

      Assert.IsFalse(queue.Contains(value + 1));
    }

    private void confirmEmptyState(){
      Assert.AreEqual(queue.Count, 0);
      Assert.IsFalse(queue.Contains(values[0]));
      Assert.IsFalse(queue.Contains(value));
      Assert.Throws<EmptyQueueException>(() => queue.Peek());
      Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }

    private void confirmHeadElement(int index, bool reversed = false)
    {
      var element = values[index];

      Assert.AreEqual(queue.Count, reversed ? values.Length - index : index + 1);
      Assert.IsTrue(queue.Contains(element));
      Assert.IsFalse(queue.Contains(value));
      Assert.AreEqual(queue.Peek(), values[reversed ? index : 0]);
    }

    [Test]
    public void SequenceOfOperationsProducesExpectedOutput()
    {
      // initial setup
      queue.Clear();
      confirmEmptyState();

      // enqueueing elements
      for (var index = 0; index < values.Length; index++)
      {
        queue.Enqueue(values[index]);

        confirmHeadElement(index);
      }

      // dequeueing elements
      for (var dequeueIndex = 0; dequeueIndex < values.Length; dequeueIndex++)
      {
        confirmHeadElement(dequeueIndex, true);

        var dequeued = queue.Dequeue();

        Assert.AreEqual(values[dequeueIndex], dequeued);
        Assert.IsFalse(queue.Contains(values[dequeueIndex]));
      }

      // final setup
      confirmEmptyState();
    }
  }
}
