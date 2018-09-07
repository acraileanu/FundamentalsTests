using NUnit.Framework;
using FundamentalsTests.LinkedLists.Stacks.Helpers;

namespace FundamentalsTests.LinkedLists.Stacks.Tests
{
  [TestFixture]
  public class StackOperationsTests
  {
    const int value = 123;
    private static readonly int[] values = { 11, 32, 53, 74, 95 };

    private static Stack<int> getPrepopulatedStack()
    {
      return new Stack<int>(values);
    }

    private static Stack<int> getEmptyStack()
    {
      return new Stack<int>();
    }

    [Test]
    public void EmptyStackHasNoElements()
    {
      var stack = getEmptyStack();

      Assert.AreEqual(0, stack.Count);
    }

    [Test]
    public void ClearingStackRemovesAllElements()
    {
      var stack = getPrepopulatedStack();
      Assert.AreNotEqual(0, stack.Count);

      stack.Clear();

      Assert.AreEqual(0, stack.Count);
    }

    [Test]
    public void PoppingFromEmptyStackRaisesException()
    {
      var stack = getEmptyStack();

      Assert.Throws<EmptyStackException>(() => stack.Pop());
    }

    [Test]
    public void PeekingIntoEmptyStackRaisesException()
    {
      var stack = getEmptyStack();

      Assert.Throws<EmptyStackException>(() => stack.Peek());
    }

    [Test]
    public void PushingToStackIncreasesSize()
    {
      var stack = getPrepopulatedStack();
      var count = stack.Count;

      stack.Push(value);

      Assert.AreEqual(count + 1, stack.Count);
    }

    [Test]
    public void PoppingFromStackDecreasesSize()
    {
      var stack = getPrepopulatedStack();
      var count = stack.Count;

      stack.Pop();

      Assert.AreEqual(count - 1, stack.Count);
    }

    [Test]
    public void PoppingFromStackReturnsPeekedElement()
    {
      var stack = getPrepopulatedStack();
      var peek = stack.Peek();
      var popped = stack.Pop();

      Assert.AreEqual(peek, popped);
      Assert.AreNotEqual(stack.Peek(), popped);
    }

    [Test]
    public void PoppingFromStackReturnsPushedValuesInReverseOrder()
    {
      var stack = getEmptyStack();
      for (var pushIndex = 0; pushIndex < values.Length; pushIndex++)
      {
        stack.Push(values[pushIndex]);
      }

      var popIndex = values.Length;
      while (--popIndex >= 0)
      {
        Assert.AreEqual(values[popIndex], stack.Pop());
      }
    }

    [Test]
    public void PushedElementIsFoundInStack()
    {
      var stack = getEmptyStack();
      stack.Push(value);

      Assert.IsTrue(stack.Contains(value));
    }

    [Test]
    public void NonPushedElementIsMissingFromStack()
    {
      var stack = getEmptyStack();
      stack.Push(value);

      Assert.IsFalse(stack.Contains(value + 1));
    }

    private static void confirmEmptyState(Stack<int> stack)
    {
      Assert.AreEqual(stack.Count, 0);
      Assert.IsFalse(stack.Contains(values[0]));
      Assert.IsFalse(stack.Contains(value));
      Assert.Throws<EmptyStackException>(() => stack.Peek());
      Assert.Throws<EmptyStackException>(() => stack.Pop());
    }

    private static void confirmLastElement(Stack<int> stack, int index)
    {
      var element = values[index];

      Assert.AreEqual(stack.Count, index + 1);
      Assert.IsTrue(stack.Contains(element));
      Assert.IsFalse(stack.Contains(value));
      Assert.AreEqual(stack.Peek(), element);
    }

    [Test]
    public void SequenceOfOperationsProducesExpectedOutput()
    {
      // initial setup
      var stack = getEmptyStack();
      confirmEmptyState(stack);

      // pushing elements
      for (var index = 0; index < values.Length; index++)
      {
        stack.Push(values[index]);

        confirmLastElement(stack, index);
      }

      // popping elements
      var popIndex = values.Length;
      while (--popIndex >= 0)
      {
        confirmLastElement(stack, popIndex);

        var popped = stack.Pop();

        Assert.AreEqual(values[popIndex], popped);
        Assert.IsFalse(stack.Contains(values[popIndex]));
      }

      // final setup
      confirmEmptyState(stack);
    }
  }
}
