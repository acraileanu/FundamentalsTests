using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
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
