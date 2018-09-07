﻿using System;
using System.Collections.Generic;
using System.Linq;
using FundamentalsTests.Sortings;

namespace FundamentalsTests.Sortings.Sorters
{
  public class MergeSorter<T> : ISorter<T>
    where T : IComparable<T>
  {
    public List<T> Sort(List<T> input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      return mergeSort(input);
    }

    private static List<T> mergeSort(List<T> input)
    {
      var size = input.Count;

      if (size < 2) {
        return input;
      }

      var middle = size / 2;
      var leftArray = mergeSort(input.Take(middle).ToList<T>());
      var rightArray = mergeSort(input.Skip(middle).ToList<T>());

      merge(leftArray, rightArray, input);

      return input;
    }

    private static void merge(List<T> left, List<T> right, List<T> input)
    {
      var index = 0;

      while ((left.Count > 0) && (right.Count > 0))
      {
        if (right[0].CompareTo(left[0]) < 0)
        {
          input[index++] = right.Dequeue();
        }
        else
        {
          input[index++] = left.Dequeue();
        }
      }

      while (left.Count > 0)
      {
        input[index++] = left.Dequeue();
      }

      while (right.Count > 0)
      {
        input[index++] = right.Dequeue();
      }
    }
  }
}
