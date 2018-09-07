using System;
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions
{
  public static void Push<T>(this List<T> source, T value)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    source.Add(value);
  }

  public static T Pop<T>(this List<T> source)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    var result = source.Last();
    source.RemoveAt(source.Count - 1);
    return result;
  }

  public static void Enqueue<T>(this List<T> source, T value)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    source.Add(value);
  }

  public static T Dequeue<T>(this List<T> source)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    var result = source.First();
    source.RemoveAt(0);
    return result;
  }
}
