using System;

namespace FundamentalsTests.StringsAreReferenceTypes
{
	internal static class StringsAreReferenceTypesHelpers
	{
		internal static void ChangeString(string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException(nameof(input));
			}

			input = GetUniqueString();
		}

		internal static string GetUniqueString()
		{
			return Guid.NewGuid().ToString();
		}
	}
}