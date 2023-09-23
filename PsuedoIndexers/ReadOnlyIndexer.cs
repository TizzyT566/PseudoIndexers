using System;

namespace PseudoIndexers;

/// <summary>
/// A PseudoIndexer with only a get accessor.
/// </summary>
/// <typeparam name="I">The type to use for the indexer.</typeparam>
/// <typeparam name="T">The return type of the indexer.</typeparam>
/// <remarks>
/// Constructs a new ReadOnlyIndexer.
/// </remarks>
/// <param name="get">The get accessor.</param>
public sealed class ReadOnlyIndexer<I, T>(Func<I, T> get)
{
    /// <summary>
    /// The underlying indexer for a PseudoIndexer.
    /// </summary>
    /// <param name="index">Index value.</param>
    public T this[I index] => get != null ? get(index) : default!;
}
