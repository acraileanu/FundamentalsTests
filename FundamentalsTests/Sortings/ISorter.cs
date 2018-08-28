using System;
using System.Collections.Generic;

namespace FundamentalsTests.Sortings
{
  public interface ISorter<T>
    where T : IComparable<T>
  {
    List<T> Sort(List<T> input);
  }
}
