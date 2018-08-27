using NUnit.Framework;
using FundamentalsTests.LinkedLists.Helpers.Stacks;

namespace FundamentalsTests.LinkedLists.Tests.Stacks
{
	[TestFixture]
	public class StackOperationsTests
	{
    const int value = 123;
    private readonly int[] values = { 11, 32, 53, 74, 95 };
    private Stack<int> stack;

    [SetUp]
    public void Initialize()
    {
      stack = new Stack<int>(values);
    }

		[Test]
		public void ClearingStackRemovesAllElements()
		{
      stack.Clear();

      Assert.AreEqual(0, stack.Count);
    }

		[Test]
		public void PoppingFromEmptyStackRaisesException()
		{
      stack.Clear();

      Assert.Throws<EmptyStackException>(() => stack.Pop());
    }

		[Test]
		public void PeekingIntoEmptyStackRaisesException()
		{
      stack.Clear();

      Assert.Throws<EmptyStackException>(() => stack.Peek());
    }

		[Test]
		public void PushingToStackIncreasesSize()
		{
      var count = stack.Count;

      stack.Push(value);

      Assert.AreEqual(count + 1, stack.Count);
    }

		[Test]
		public void PoppingFromStackDecreasesSize()
		{
      var count = stack.Count;

      stack.Pop();

      Assert.AreEqual(count - 1, stack.Count);
    }

		[Test]
		public void PoppingFromStackReturnsPeekedElement()
		{
      var peek = stack.Peek();
      var popped = stack.Pop();

      Assert.AreEqual(peek, popped);
      Assert.AreNotEqual(stack.Peek(), popped);
    }

		[Test]
		public void PoppingFromStackReturnsPushedValuesInReverseOrder()
		{
      stack.Clear();
      for (var pushIndex = 0; pushIndex < values.Length; pushIndex++){
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
      stack.Clear();
      stack.Push(value);

      Assert.IsTrue(stack.Contains(value));
    }

		[Test]
		public void NonPushedElementIsMissingFromStack()
		{
      stack.Clear();
      stack.Push(value);

      Assert.IsFalse(stack.Contains(value + 1));
    }

    private void confirmEmptyState(){
      Assert.AreEqual(stack.Count, 0);
      Assert.IsFalse(stack.Contains(values[0]));
      Assert.IsFalse(stack.Contains(value));
      Assert.Throws<EmptyStackException>(() => stack.Peek());
      Assert.Throws<EmptyStackException>(() => stack.Pop());
    }

    private void confirmLastElement(int index)
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
      stack.Clear();
      confirmEmptyState();

      // pushing elements
      for (var index = 0; index < values.Length; index++){
        stack.Push(values[index]);

        confirmLastElement(index);
      }

      // popping elements
      var popIndex = values.Length;
      while (--popIndex >= 0)
      {
        confirmLastElement(popIndex);

        var popped = stack.Pop();

        Assert.AreEqual(values[popIndex], popped);
        Assert.IsFalse(stack.Contains(values[popIndex]));
      }

      // final setup
      confirmEmptyState();
    }
	}
}
