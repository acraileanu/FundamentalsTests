using System;
using FundamentalsTests.PassingParameters.Helpers;
using NUnit.Framework;

namespace FundamentalsTests.PassingParameters.Tests
{
  [TestFixture]
  public class PassingValueTypesAsParametersTests
  {
    [Test]
    public void ValueTypeSentAsParameterByValueDoesNotChangeValue()
    {
      var input = 0;

      Console.WriteLine("Value before calling method is {0}", input);
      PassingParametersHelpers.ChangeInt(input);
      Console.WriteLine("Value after calling method is {0}", input);

      Assert.AreEqual(input, 0);
    }

    [Test]
    public void ValueTypeSentAsParameterByReferenceChangesValue()
    {
      var input = 0;

      Console.WriteLine("Value before calling method is {0}", input);
      PassingParametersHelpers.ChangeIntWithReference(ref input);
      Console.WriteLine("Value after calling method is {0}", input);

      Assert.AreNotEqual(input, 0);
    }
  }
}
