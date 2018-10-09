using System;
using FundamentalsTests.PassingParameters.Helpers;
using NUnit.Framework;

namespace FundamentalsTests.PassingParameters.Tests
{
  [TestFixture]
  public class PassingReferenceTypesAsParametersTests
  {
    [Test]
    public void ReferenceTypeSentAsParameterByValueChangesPropertyValue()
    {
      var input = new ObjectWithIntProperty { IntegerProperty = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.IntegerProperty);
      PassingParametersHelpers.ChangePropertyValue(input);
      Console.WriteLine("Property value after calling method is {0}", input.IntegerProperty);

      Assert.AreEqual(input.IntegerProperty, 1);
    }

    [Test]
    public void ReferenceTypeSentAsParameterByValueDoesNotChangeReference()
    {
      var input = new ObjectWithIntProperty { IntegerProperty = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.IntegerProperty);
      PassingParametersHelpers.ReinitializeObject(input);
      Console.WriteLine("Property value after calling method is {0}", input.IntegerProperty);

      Assert.AreEqual(input.IntegerProperty, 0);
    }

    [Test]
    public void ReferenceTypeSentAsParameterByReferenceChangesReference()
    {
      var input = new ObjectWithIntProperty { IntegerProperty = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.IntegerProperty);
      PassingParametersHelpers.ReinitializeObjectWithReference(ref input);
      Console.WriteLine("Property value after calling method is {0}", input.IntegerProperty);

      Assert.AreEqual(input.IntegerProperty, 1);
    }
  }
}
