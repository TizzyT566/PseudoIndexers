using System;

namespace PseudoIndexers;

/// <summary>
/// A PseudoIndexer with only a set accessor.
/// </summary>
/// <typeparam name="I">The type to use for the indexer.</typeparam>
/// <typeparam name="T">The return type of the indexer.</typeparam>
/// <remarks>
/// Constructs a new WriteOnlyIndexer.
/// </remarks>
/// <param name="set">The set accessor.</param>
public sealed class WriteOnlyIndexer<I, T>(Action<I, T> set)
{
    /// <summary>
    /// The underlying indexer for a PseudoIndexer.
    /// </summary>
    /// <param name="index">Index value.</param>
    public T this[I index] { set => set?.Invoke(index, value); }
}