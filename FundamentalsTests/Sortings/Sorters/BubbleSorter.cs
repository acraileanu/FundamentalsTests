using System;
using System.Collections.Generic;
using System.Linq;
using FundamentalsTests.Sortings;

namespace FundamentalsTests.Sortings.Sorters
{
  public class BubbleSorter<T> : ISorter<T>
    where T : IComparable<T>
  {
    public List<T> Sort(List<T> input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      var end = input.Count;
      var isSorted = false;

      while (!isSorted)
      {
        isSorted = true;
        end--;

        for (var index = 0; index < end; index++)
        {
          if (input[index].CompareTo(input[index + 1]) > 0)
          {
            swapItems(input, index);
            isSorted = false;
          }
        }
      }

      return input;
    }

    private static void swapItems(List<T> input, int index)
    {
      var current = input[index];
      input[index] = input[index + 1];
      input[index + 1] = current;
    }
  }
}
