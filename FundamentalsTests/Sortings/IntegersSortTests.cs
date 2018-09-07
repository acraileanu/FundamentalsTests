using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FundamentalsTests.Sortings.Sorters;

using System.Reflection;

namespace FundamentalsTests.Sortings
{
  [TestFixture(typeof(SelectionSorter<int>))]
  [TestFixture(typeof(BubbleSorter<int>))]
  [TestFixture(typeof(InsertionSorter<int>))]
  [TestFixture(typeof(MergeSorter<int>))]
  public class IntegersSortTests
  {
    const int value = 123;
    private static readonly List<int> values = new List<int> { 137, 53, 32, 179, 95, 11, 116, 158, 74 };
    private ISorter<int> sorter;

    public IntegersSortTests(Type sorterType)
    {
      sorter = (ISorter<int>)Activator.CreateInstance(sorterType);
    }

    private static List<int> generateRandomValues()
    {
      return Enumerable.Range(0, 100).Shuffle().ToList<int>();
    }

    [Test]
    public void SortingArrayReturnsSameNumberOfElements()
    {
      var listToSort = new List<int>(values);

      var result = sorter.Sort(listToSort);

      Assert.AreEqual(values.Count, result.Count);
    }

    [Test]
    public void CanSortEmptyList()
    {
      var result = sorter.Sort(new List<int>());

      Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void CanSortOneElementList()
    {
      var result = sorter.Sort(new List<int>{ value });

      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(value, result[0]);
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

    [Test]
    public void SortingRandomListReturnsSortedList()
    {
      var expected = generateRandomValues();
      var listToSort = new List<int>(expected);
      expected.Sort();
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }
  }
}
