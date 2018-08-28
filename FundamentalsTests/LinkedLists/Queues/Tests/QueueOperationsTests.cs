using NUnit.Framework;
using FundamentalsTests.LinkedLists.Queues.Helpers;

namespace FundamentalsTests.LinkedLists.Queues.Tests
{
  [TestFixture]
  public class QueueOperationsTests
  {
    const int value = 123;
    private static readonly int[] values = { 11, 32, 53, 74, 95 };

    private static Queue<int> getPrepopulatedQueue()
    {
      return new Queue<int>(values);
    }

    private static Queue<int> getEmptyQueue()
    {
      return new Queue<int>();
    }

    [Test]
    public void EmptyQueueHasNoElements()
    {
      var queue = getEmptyQueue();

      Assert.AreEqual(0, queue.Count);
    }

    [Test]
    public void ClearingQueueRemovesAllElements()
    {
      var queue = getPrepopulatedQueue();
      Assert.AreNotEqual(0, queue.Count);

      queue.Clear();

      Assert.AreEqual(0, queue.Count);
    }

    [Test]
    public void DequeueingFromEmptyQueueRaisesException()
    {
      var queue = getEmptyQueue();

      Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }

    [Test]
    public void PeekingIntoEmptyQueueRaisesException()
    {
      var queue = getEmptyQueue();

      Assert.Throws<EmptyQueueException>(() => queue.Peek());
    }

    [Test]
    public void EnqueueingToQueueIncreasesSize()
    {
      var queue = getPrepopulatedQueue();
      var count = queue.Count;

      queue.Enqueue(value);

      Assert.AreEqual(count + 1, queue.Count);
    }

    [Test]
    public void DequeueingFromQueueDecreasesSize()
    {
      var queue = getPrepopulatedQueue();
      var count = queue.Count;

      queue.Dequeue();

      Assert.AreEqual(count - 1, queue.Count);
    }

    [Test]
    public void DequeueingFromQueueReturnsPeekedElement()
    {
      var queue = getPrepopulatedQueue();
      var peek = queue.Peek();
      var dequeued = queue.Dequeue();

      Assert.AreEqual(peek, dequeued);
      Assert.AreNotEqual(queue.Peek(), dequeued);
    }

    [Test]
    public void DequeueingFromQueueReturnsEnqueuedValues()
    {
      var queue = getEmptyQueue();
      for (var enqueueIndex = 0; enqueueIndex < values.Length; enqueueIndex++)
      {
        queue.Enqueue(values[enqueueIndex]);
      }

      for (var dequeueIndex = 0; dequeueIndex < values.Length; dequeueIndex++)
      {
        Assert.AreEqual(values[dequeueIndex], queue.Dequeue());
      }
    }

    [Test]
    public void EnqueuedElementIsFoundInQueue()
    {
      var queue = getEmptyQueue();
      queue.Enqueue(value);

      Assert.IsTrue(queue.Contains(value));
    }

    [Test]
    public void NonEnqueuedElementIsMissingFromQueue()
    {
      var queue = getEmptyQueue();
      queue.Enqueue(value);

      Assert.IsFalse(queue.Contains(value + 1));
    }

    private static void confirmEmptyState(Queue<int> queue){
      Assert.AreEqual(queue.Count, 0);
      Assert.IsFalse(queue.Contains(values[0]));
      Assert.IsFalse(queue.Contains(value));
      Assert.Throws<EmptyQueueException>(() => queue.Peek());
      Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }

    private static void confirmHeadElement(Queue<int> queue, int index, bool reversed = false)
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
      var queue = getEmptyQueue();
      confirmEmptyState(queue);

      // enqueueing elements
      for (var index = 0; index < values.Length; index++)
      {
        queue.Enqueue(values[index]);

        confirmHeadElement(queue, index);
      }

      // dequeueing elements
      for (var dequeueIndex = 0; dequeueIndex < values.Length; dequeueIndex++)
      {
        confirmHeadElement(queue, dequeueIndex, true);

        var dequeued = queue.Dequeue();

        Assert.AreEqual(values[dequeueIndex], dequeued);
        Assert.IsFalse(queue.Contains(values[dequeueIndex]));
      }

      // final setup
      confirmEmptyState(queue);
    }
  }
}
