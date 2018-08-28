using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FundamentalsTests.Sortings.SelectionSort;

using System.Reflection;

namespace FundamentalsTests.Sortings
{
  [TestFixture(typeof(SelectionSorter<int>))]
  public class SortTests
  {
    private ISorter<int> sorter;

    public SortTests(Type sorterType)
    {
      sorter = (ISorter<int>)Activator.CreateInstance(sorterType);
    }

    private static readonly List<int> values = new List<int> { 137, 53, 32, 179, 95, 11, 116, 158, 74 };

    [Test]
    public void SortingArrayReturnsSameNumberOfElements()
    {
      var result = sorter.Sort(values);

      Assert.AreEqual(values.Count, result.Count);
    }

    [Test]
    public void SortingUnsortedListReturnsSortedList()
    {
      var expected = new List<int>(values);
      var listToSort = new List<int>(expected);
      expected.Sort();
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void SortingSortedListReturnsSameSortedList()
    {
      var expected = new List<int>(values);
      expected.Sort();
      var listToSort = new List<int>(expected);
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void SortingReversedListReturnsSortedList()
    {
      var expected = new List<int>(values);
      expected.Sort();
      var listToSort = new List<int>(expected);
      listToSort.Reverse();
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }
  }
}
