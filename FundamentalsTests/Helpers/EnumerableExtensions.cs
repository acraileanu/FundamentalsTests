using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
  public static void Push<T>(this IEnumerable<T> source, T value)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    source.Append(value);
  }

  public static T Pop<T>(this IEnumerable<T> source)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    var result = source.Last();
    source = source.Reverse().Skip(1).Reverse();
    return result;
  }

  public static void Enqueue<T>(this IEnumerable<T> source, T value)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    source.Append(value);
  }

  public static T Dequeue<T>(this IEnumerable<T> source)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    var result = source.First();
    source = source.Skip(1);
    return result;
  }

  public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random randomGenerator = null)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    return source.ShuffleIterator(randomGenerator ?? new Random());
  }

  private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random randomGenerator)
  {
    var buffer = source.ToList();

    for (var index = 0; index < buffer.Count; index++)
    {
      var randomIndex = randomGenerator.Next(index, buffer.Count);
      yield return buffer[randomIndex];

      buffer[randomIndex] = buffer[index];
    }
  }
}
