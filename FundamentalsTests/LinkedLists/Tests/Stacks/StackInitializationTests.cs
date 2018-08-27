using NUnit.Framework;
using FundamentalsTests.LinkedLists.Helpers.Stacks;

namespace FundamentalsTests.LinkedLists.Tests.Stacks
{
	[TestFixture]
	public class StackInitializationTests
	{
		[Test]
		public void NewStackHasNoElements()
		{
			var stack = new Stack<int>();

			Assert.AreEqual(0, stack.Count);
      Assert.AreEqual("<> (0)", stack.ToString());
		}

    [Test]
    public void StackWtihEmptyEnumerableHasNoElements()
    {
      var stack = new Stack<int>(new int[] {});

      Assert.AreEqual(0, stack.Count);
      Assert.AreEqual("<> (0)", stack.ToString());
    }

    [Test]
    public void StackWithEnumerableHasEnumerationNumberOfElements()
    {
      var stack = new Stack<int>(new int[3]);

      Assert.AreEqual(3, stack.Count);
      Assert.AreEqual("<0, 0, 0> (3)", stack.ToString());
    }

    [Test]
    public void StackWithEnumerableHasEnumerationElements()
    {
      var stack = new Stack<int>(new int[] {1, 2, 3});

      Assert.AreEqual(3, stack.Count);
      Assert.AreEqual("<3, 2, 1> (3)", stack.ToString());
    }
	}
}
