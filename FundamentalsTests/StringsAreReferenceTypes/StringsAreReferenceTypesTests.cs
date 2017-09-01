using NUnit.Framework;

namespace FundamentalsTests.StringsAreReferenceTypes
{
	[TestFixture]
	public class StringsAreReferenceTypesTests
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
			var originalValue = StringsAreReferenceTypesHelpers.GetUniqueString();
			// ReSharper disable once RedundantAssignment
			var input = originalValue;

			input = StringsAreReferenceTypesHelpers.GetUniqueString();
			
			Assert.AreNotEqual(input, originalValue);
		}

		[Test]
		public void StringIsStillImmutable()
		{
			var originalValue = StringsAreReferenceTypesHelpers.GetUniqueString();
			var input = originalValue;

			StringsAreReferenceTypesHelpers.ChangeString(input);
			
			Assert.AreEqual(input, originalValue);
		}
	}
}