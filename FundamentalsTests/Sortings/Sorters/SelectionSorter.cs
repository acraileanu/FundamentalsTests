using System;
using System.Collections.Generic;
using System.Linq;
using FundamentalsTests.Sortings;

namespace FundamentalsTests.Sortings.Sorters
{
  public class SelectionSorter<T> : ISorter<T>
    where T : IComparable<T>
  {
    public List<T> Sort(List<T> input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      for (var index = 0; index < input.Count; index++)
      {
        var smallestIndex = index;

        for (var nextIndex = index + 1; nextIndex < input.Count; nextIndex++)
        {
          if (input[nextIndex].CompareTo(input[smallestIndex]) < 0)
          {
            smallestIndex = nextIndex;
          }
        }

        if (smallestIndex != index)
        {
          swapItems(input, index, smallestIndex);
        }
      }

      return input;
    }

    private static void swapItems(List<T> input, int first, int second)
    {
      var current = input[first];
      input[first] = input[second];
      input[second] = current;
    }
  }
}
