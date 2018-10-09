using NUnit.Framework;
using FundamentalsTests.LinkedLists.Queues.Helpers;

namespace FundamentalsTests.LinkedLists.Queues.Tests
{
  [TestFixture]
  public class QueueOperationsTests
  {
    const int value = 123;
    private static readonly int[] values = { 11, 32, 53, 74, 95 };

    private static Queue<int> GetPrepopulatedQueue()
    {
      return new Queue<int>(values);
    }

    private static Queue<int> GetEmptyQueue()
    {
      return new Queue<int>();
    }

    [Test]
    public void EmptyQueueHasNoElements()
    {
      var queue = GetEmptyQueue();

      Assert.AreEqual(0, queue.Count);
    }

    [Test]
    public void ClearingQueueRemovesAllElements()
    {
      var queue = GetPrepopulatedQueue();
      Assert.AreNotEqual(0, queue.Count);

      queue.Clear();

      Assert.AreEqual(0, queue.Count);
    }

    [Test]
    public void DequeueingFromEmptyQueueRaisesException()
    {
      var queue = GetEmptyQueue();

      Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }

    [Test]
    public void PeekingIntoEmptyQueueRaisesException()
    {
      var queue = GetEmptyQueue();

      Assert.Throws<EmptyQueueException>(() => queue.Peek());
    }

    [Test]
    public void EnqueueingToQueueIncreasesSize()
    {
      var queue = GetPrepopulatedQueue();
      var count = queue.Count;

      queue.Enqueue(value);

      Assert.AreEqual(count + 1, queue.Count);
    }

    [Test]
    public void DequeueingFromQueueDecreasesSize()
    {
      var queue = GetPrepopulatedQueue();
      var count = queue.Count;

      queue.Dequeue();

      Assert.AreEqual(count - 1, queue.Count);
    }

    [Test]
    public void DequeueingFromQueueReturnsPeekedElement()
    {
      var queue = GetPrepopulatedQueue();
      var peek = queue.Peek();
      var dequeued = queue.Dequeue();

      Assert.AreEqual(peek, dequeued);
      Assert.AreNotEqual(queue.Peek(), dequeued);
    }

    [Test]
    public void DequeueingFromQueueReturnsEnqueuedValues()
    {
      var queue = GetEmptyQueue();
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
      var queue = GetEmptyQueue();
      queue.Enqueue(value);

      Assert.IsTrue(queue.Contains(value));
    }

    [Test]
    public void NonEnqueuedElementIsMissingFromQueue()
    {
      var queue = GetEmptyQueue();
      queue.Enqueue(value);

      Assert.IsFalse(queue.Contains(value + 1));
    }

    private static void ConfirmEmptyState(Queue<int> queue)
    {
      Assert.AreEqual(queue.Count, 0);
      Assert.IsFalse(queue.Contains(values[0]));
      Assert.IsFalse(queue.Contains(value));
      Assert.Throws<EmptyQueueException>(() => queue.Peek());
      Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }

    private static void ConfirmHeadElement(Queue<int> queue, int index, bool reversed = false)
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
      var queue = GetEmptyQueue();
      ConfirmEmptyState(queue);

      // enqueueing elements
      for (var index = 0; index < values.Length; index++)
      {
        queue.Enqueue(values[index]);

        ConfirmHeadElement(queue, index);
      }

      // dequeueing elements
      for (var dequeueIndex = 0; dequeueIndex < values.Length; dequeueIndex++)
      {
        ConfirmHeadElement(queue, dequeueIndex, true);

        var dequeued = queue.Dequeue();

        Assert.AreEqual(values[dequeueIndex], dequeued);
        Assert.IsFalse(queue.Contains(values[dequeueIndex]));
      }

      // final setup
      ConfirmEmptyState(queue);
    }
  }
}
