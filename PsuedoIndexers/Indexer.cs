using System;

namespace PseudoIndexers;

/// <summary>
/// A PseudoIndexer with both getter and setter accessors.
/// </summary>
/// <typeparam name="I">The type to use for the indexer.</typeparam>
/// <typeparam name="T">The return type of the indexer.</typeparam>
/// <remarks>
/// Constructs a new Indexer.
/// </remarks>
/// <param name="get">The get accessor.</param>
/// <param name="set">The set accessor.</param>
public sealed class Indexer<I, T>(Func<I, T> get, Action<I, T> set)
{
    /// <summary>
    /// The underlying indexer for a PseudoIndexer.
    /// </summary>
    /// <param name="index">Index value.</param>
    public T this[I index]
    {
        get => get != null ? get(index) : default!;
        set => set?.Invoke(index, value);
    }
}
