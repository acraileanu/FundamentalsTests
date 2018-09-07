using System;
using System.Collections.Generic;
using System.Linq;
using FundamentalsTests.Sortings;

namespace FundamentalsTests.Sortings.Sorters
{
  public class InsertionSorter<T> : ISorter<T>
    where T : IComparable<T>
  {
    public List<T> Sort(List<T> input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      for (var index = 1; index < input.Count; index++)
      {
        var current = input[index];
        var sortedIndex = index;

        while ((sortedIndex > 0) && (current.CompareTo(input[sortedIndex - 1]) < 0))
        {
          input[sortedIndex] = input[sortedIndex-- - 1];
        }

        input[sortedIndex] = current;
      }

      return input;
    }
  }
}
