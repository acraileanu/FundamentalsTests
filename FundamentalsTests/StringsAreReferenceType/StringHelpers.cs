using System;

namespace FundamentalsTests.StringsAreReferenceType
{
  public static class StringHelpers
  {
    public static void ChangeString(string input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      // ReSharper disable once RedundantAssignment
      input = GetUniqueString();
    }

    public static string GetUniqueString()
    {
      return Guid.NewGuid().ToString();
    }
  }
}
