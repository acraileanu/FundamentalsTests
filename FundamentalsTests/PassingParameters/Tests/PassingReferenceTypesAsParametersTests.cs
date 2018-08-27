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
      var input = new ObjectWithIntProperty { Property = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.Property);
      PassingParametersHelpers.ChangePropertyValue(input);
      Console.WriteLine("Property value after calling method is {0}", input.Property);

      Assert.AreEqual(input.Property, 1);
    }

    [Test]
    public void ReferenceTypeSentAsParameterByValueDoesNotChangeReference()
    {
      var input = new ObjectWithIntProperty { Property = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.Property);
      PassingParametersHelpers.ReinitializeObject(input);
      Console.WriteLine("Property value after calling method is {0}", input.Property);

      Assert.AreEqual(input.Property, 0);
    }

    [Test]
    public void ReferenceTypeSentAsParameterByReferenceChangesReference()
    {
      var input = new ObjectWithIntProperty { Property = 0 };

      Console.WriteLine("Property value before calling method is {0}", input.Property);
      PassingParametersHelpers.ReinitializeObjectWithReference(ref input);
      Console.WriteLine("Property value after calling method is {0}", input.Property);

      Assert.AreEqual(input.Property, 1);
    }
  }
}
