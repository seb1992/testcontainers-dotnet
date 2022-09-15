namespace DotNet.Testcontainers.Builders
{
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  /// Combines the builder configuration.
  /// </summary>
  internal static class BuildConfiguration
  {
    /// <summary>
    /// Returns the first configuration that is not null.
    /// </summary>
    /// <param name="next">The next configuration.</param>
    /// <param name="previous">The previous configuration.</param>
    /// <typeparam name="T">Any class.</typeparam>
    /// <returns>The first configuration that is not null.</returns>
    public static T Combine<T>(T next, T previous)
      where T : class
    {
      return next ?? previous;
    }

    /// <summary>
    /// Combines the previous with the next configuration.
    /// </summary>
    /// <param name="next">The next configuration.</param>
    /// <param name="previous">The previous configuration.</param>
    /// <typeparam name="T">Type of <see cref="IEnumerable{T}" />.</typeparam>
    /// <returns>The previous with the next configuration.</returns>
    public static IEnumerable<T> Combine<T>(IEnumerable<T> next, IEnumerable<T> previous)
      where T : class
    {
      if (next == null || previous == null)
      {
        return next ?? previous;
      }

      return previous.Concat(next).ToArray();
    }

    /// <summary>
    /// Combines the previous with the next configuration while preserving the order of insertion.
    /// </summary>
    /// <param name="next">The next configuration.</param>
    /// <param name="previous">The previous configuration.</param>
    /// <typeparam name="T">Type of <see cref="IReadOnlyList{T}" />.</typeparam>
    /// <returns>The previous with the next configuration.</returns>
    public static IReadOnlyList<T> Combine<T>(IReadOnlyList<T> next, IReadOnlyList<T> previous)
      where T : class
    {
      if (next == null || previous == null)
      {
        return next ?? previous;
      }

      return previous.Concat(next).ToArray();
    }

    /// <summary>
    /// Combines the previous with the next configuration while preserving the order of insertion.
    /// </summary>
    /// <param name="next">The next configuration.</param>
    /// <param name="previous">The previous configuration.</param>
    /// <typeparam name="T">Type of <see cref="IReadOnlyDictionary{TKey, TValue}" />.</typeparam>
    /// <returns>The previous with the next configuration.</returns>
    public static IReadOnlyDictionary<T, T> Combine<T>(IReadOnlyDictionary<T, T> next, IReadOnlyDictionary<T, T> previous)
      where T : class
    {
      if (next == null || previous == null)
      {
        return next ?? previous;
      }

      return previous.Concat(next).GroupBy(item => item.Key).ToDictionary(item => item.Key, item => item.Last().Value);
    }
  }
}
