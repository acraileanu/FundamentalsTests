using NUnit.Framework;

namespace FundamentalsTests.StringsAreReferenceType
{
  [TestFixture]
  public class StringTests
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
      var originalValue = StringHelpers.GetUniqueString();
      // ReSharper disable once RedundantAssignment
      var input = originalValue;

      input = StringHelpers.GetUniqueString();

      Assert.AreNotEqual(input, originalValue);
    }

    [Test]
    public void StringPassedAsParameterIsImmutable()
    {
      var originalValue = StringHelpers.GetUniqueString();
      var input = originalValue;

      StringHelpers.ChangeString(input);

      Assert.AreEqual(input, originalValue);
    }
  }
}
