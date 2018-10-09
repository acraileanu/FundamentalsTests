using System;
using FundamentalsTests.PassingParameters.Helpers;
using NUnit.Framework;

namespace FundamentalsTests.PassingParameters.Tests
{
  [TestFixture]
  public class StructsAreValueTypeTests
  {
    [Test]
    public void StructSentAsParameterByValueDoesNotChangePropertyValue()
    {
      var input = new StructWithIntProperty { IntegerProperty = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.IntegerProperty);
      PassingParametersHelpers.ChangePropertyValue(input);
      Console.WriteLine("Property value after calling method is {0}", input.IntegerProperty);

      Assert.AreEqual(input.IntegerProperty, 0);
    }

    [Test]
    public void StructSentAsParameterByReferenceChangesPropertyValue()
    {
      var input = new StructWithIntProperty { IntegerProperty = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.IntegerProperty);
      PassingParametersHelpers.ChangePropertyValueWithReference(ref input);
      Console.WriteLine("Property value after calling method is {0}", input.IntegerProperty);

      Assert.AreEqual(input.IntegerProperty, 1);
    }

    [Test]
    public void StructSentAsParameterByValueDoesNotChangeReference()
    {
      var input = new StructWithIntProperty { IntegerProperty = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.IntegerProperty);
      PassingParametersHelpers.ReinitializeStruct(input);
      Console.WriteLine("Property value after calling method is {0}", input.IntegerProperty);

      Assert.AreEqual(input.IntegerProperty, 0);
    }

    [Test]
    public void StructSentAsParameterByReferenceChangesReference()
    {
      var input = new StructWithIntProperty { IntegerProperty = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.IntegerProperty);
      PassingParametersHelpers.ReinitializeStructWithReference(ref input);
      Console.WriteLine("Property value after calling method is {0}", input.IntegerProperty);

      Assert.AreEqual(input.IntegerProperty, 1);
    }
  }
}
