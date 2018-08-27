using System;

namespace FundamentalsTests.StringsAreReferenceType
{
  internal static class StringsAreReferenceTypeHelpers
  {
    internal static void ChangeString(string input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      // ReSharper disable once RedundantAssignment
      input = GetUniqueString();
    }

    internal static string GetUniqueString()
    {
      return Guid.NewGuid().ToString();
    }
  }
}
