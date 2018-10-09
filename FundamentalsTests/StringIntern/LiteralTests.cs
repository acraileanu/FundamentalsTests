using NUnit.Framework;

namespace FundamentalsTests.StringIntern
{
  [TestFixture]
  public class LiteralTests
  {
    [Test]
    public void LiteralStringsWithSameValuesAreSameAndEqual()
    {
      var first = LiteralHelpers.GetLiteral();
      var second = LiteralHelpers.GetLiteral();

      Assert.AreSame(first, second);
      Assert.AreEqual(first, second);
    }

    [Test]
    public void LiteralInternalStringsWithSameValuesAreSameAndEqual()
    {
      var first = string.Intern(LiteralHelpers.GetLiteral());
      var second = string.Intern(LiteralHelpers.GetLiteral());

      Assert.AreSame(first, second);
      Assert.AreEqual(first, second);
    }

    [Test]
    public void NonLiteralStringsWithSameValuesAreNotSameButEqual()
    {
      var first = LiteralHelpers.GetNonLiteral();
      var second = LiteralHelpers.GetNonLiteral();

      Assert.AreEqual(first, second);
      Assert.AreNotSame(first, second);
    }

    [Test]
    public void NonLiteralInternalStringsWithSameValuesAreSameAndEqual()
    {
      var first = string.Intern(LiteralHelpers.GetNonLiteral());
      var second = string.Intern(LiteralHelpers.GetNonLiteral());

      Assert.AreEqual(first, second);
      Assert.AreSame(first, second);
    }

    [Test]
    public void MixLiteralNonLiteralStringsWithSameValuesAreNotSameButEqual()
    {
      var first = LiteralHelpers.GetLiteral();
      var second = LiteralHelpers.GetNonLiteral();

      Assert.AreEqual(first, second);
      Assert.AreNotSame(first, second);
    }

    [Test]
    public void MixLiteralNonLiteralInternalStringsWithSameValuesAreSameAndEqual()
    {
      var first = LiteralHelpers.GetLiteral();
      var second = string.Intern(LiteralHelpers.GetNonLiteral());

      Assert.AreEqual(first, second);
      Assert.AreSame(first, second);
    }
  }
}
