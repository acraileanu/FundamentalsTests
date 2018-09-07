using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FundamentalsTests.Sortings.Sorters;

using System.Reflection;

namespace FundamentalsTests.Sortings
{
  [TestFixture(typeof(SelectionSorter<string>))]
  [TestFixture(typeof(BubbleSorter<string>))]
  [TestFixture(typeof(InsertionSorter<string>))]
  [TestFixture(typeof(MergeSorter<string>))]
  public class StringsSortTests
  {
    const string value = "123";
    private static readonly List<string> values = new List<string> { "137", "53", "32", "179", "95", "11", "116", "158", "74" };
    private ISorter<string> sorter;

    public StringsSortTests(Type sorterType)
    {
      sorter = (ISorter<string>)Activator.CreateInstance(sorterType);
    }

    private static List<string> generateRandomValues()
    {
      return Enumerable.Range(0, 100).Shuffle().Select(num => num.ToString()).ToList<string>();
    }

    [Test]
    public void SortingArrayReturnsSameNumberOfElements()
    {
      var listToSort = new List<string>(values);

      var result = sorter.Sort(listToSort);

      Assert.AreEqual(values.Count, result.Count);
    }

    [Test]
    public void CanSortEmptyList()
    {
      var result = sorter.Sort(new List<string>());

      Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void CanSortOneElementList()
    {
      var result = sorter.Sort(new List<string>{ value });

      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(value, result[0]);
    }

    [Test]
    public void SortingUnsortedListReturnsSortedList()
    {
      var expected = new List<string>(values);
      var listToSort = new List<string>(expected);
      expected.Sort();
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void SortingSortedListReturnsSameSortedList()
    {
      var expected = new List<string>(values);
      expected.Sort();
      var listToSort = new List<string>(expected);
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void SortingReversedListReturnsSortedList()
    {
      var expected = new List<string>(values);
      expected.Sort();
      var listToSort = new List<string>(expected);
      listToSort.Reverse();
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void SortingRandomListReturnsSortedList()
    {
      var expected = generateRandomValues();
      var listToSort = new List<string>(expected);
      expected.Sort();
      var result = sorter.Sort(listToSort);

      Assert.AreEqual(expected, result);
    }
  }
}
