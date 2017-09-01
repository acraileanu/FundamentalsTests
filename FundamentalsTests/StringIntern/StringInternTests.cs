using NUnit.Framework;

namespace FundamentalsTests.StringIntern
{
	[TestFixture]
	public class StringInternTests
	{
		[Test]
		public void LiteralStringsWithSameValuesAreSameAndEqual()
		{
			var first = StringInternHelpers.GetLiteral();
			var second = StringInternHelpers.GetLiteral();

			Assert.AreSame(first, second);
			Assert.AreEqual(first, second);
		}

		[Test]
		public void LiteralInternalStringsWithSameValuesAreSameAndEqual()
		{
			var first = string.Intern(StringInternHelpers.GetLiteral());
			var second = string.Intern(StringInternHelpers.GetLiteral());

			Assert.AreSame(first, second);
			Assert.AreEqual(first, second);
		}

		[Test]
		public void NonLiteralStringsWithSameValuesAreNotSameButEqual()
		{
			var first = StringInternHelpers.GetNonLiteral();
			var second = StringInternHelpers.GetNonLiteral();

			Assert.AreEqual(first, second);
			Assert.AreNotSame(first, second);
		}

		[Test]
		public void NonLiteralInternalStringsWithSameValuesAreSameAndEqual()
		{
			var first = string.Intern(StringInternHelpers.GetNonLiteral());
			var second = string.Intern(StringInternHelpers.GetNonLiteral());

			Assert.AreEqual(first, second);
			Assert.AreSame(first, second);
		}

		[Test]
		public void MixLiteralNonLiteralStringsWithSameValuesAreNotSameButEqual()
		{
			var first = StringInternHelpers.GetLiteral();
			var second = StringInternHelpers.GetNonLiteral();

			Assert.AreEqual(first, second);
			Assert.AreNotSame(first, second);
		}

		[Test]
		public void MixLiteralInternalStringsWithSameValuesAreSameAndEqual()
		{
			var first = StringInternHelpers.GetLiteral();
			var second = string.Intern(StringInternHelpers.GetNonLiteral());

			Assert.AreEqual(first, second);
			Assert.AreSame(first, second);
		}
	}
}