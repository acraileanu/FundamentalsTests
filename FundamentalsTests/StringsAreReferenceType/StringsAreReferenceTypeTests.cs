using NUnit.Framework;

namespace FundamentalsTests.StringsAreReferenceType
{
  [TestFixture]
  public class StringsAreReferenceTypeTests
  {
    [Test]
    public void StringTypeIsAClass()
    {
      Assert.True(typeof(string).IsClass);
    }

    [Test]
    public void StringTypeIsNotValueType()
    {
      Assert.False(typeof(string).IsValueType);
    }

    [Test]
    public void StringIsImmutable()
    {
      var originalValue = StringsAreReferenceTypeHelpers.GetUniqueString();
      // ReSharper disable once RedundantAssignment
      var input = originalValue;

      input = StringsAreReferenceTypeHelpers.GetUniqueString();

      Assert.AreNotEqual(input, originalValue);
    }

    [Test]
    public void StringPassedAsParameterIsImmutable()
    {
      var originalValue = StringsAreReferenceTypeHelpers.GetUniqueString();
      var input = originalValue;

      StringsAreReferenceTypeHelpers.ChangeString(input);

      Assert.AreEqual(input, originalValue);
    }
  }
}
