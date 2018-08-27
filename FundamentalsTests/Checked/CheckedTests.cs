using System;
using NUnit.Framework;

namespace FundamentalsTests.Checked
{
  [TestFixture]
  public class CheckedTests
  {
    [Test]
    public void UnheckedValidCodeDoesNotThrowError()
    {
      var x = int.MaxValue - 1;
      var y = 1;

      var z = unchecked(x + y);

      Assert.AreEqual(z, int.MaxValue);
    }

    [Test]
    public void UnheckedInvalidCodeDoesNotThrowError()
    {
      var x = int.MaxValue;
      var y = int.MaxValue;

      var z = unchecked(x + y);

      Assert.AreEqual(z, -2);
    }

    [Test]
    public void CheckedValidCodeDoesNotThrowError()
    {
      var x = int.MaxValue - 1;
      var y = 1;

      var z = checked(x + y);

      Assert.AreEqual(z, int.MaxValue);
    }

    [Test]
    public void CheckedInvalidCodeThrowsError()
    {
      var x = int.MaxValue;
      var y = int.MaxValue;

      Assert.Throws<OverflowException>(() =>
      {
        Console.WriteLine(checked(x + y));
      });
    }

    [Test]
    public void DefaultValidCodeDoesNotThrowError()
    {
      var x = int.MaxValue - 1;
      var y = 1;

      var z = x + y;

      Assert.AreEqual(z, int.MaxValue);
    }

    [Test]
    public void DefaultInvalidCodeDoesNotThrowError()
    {
      var x = int.MaxValue;
      var y = int.MaxValue;

      var z = x + y;

      Assert.AreEqual(z, -2);
    }
  }
}
