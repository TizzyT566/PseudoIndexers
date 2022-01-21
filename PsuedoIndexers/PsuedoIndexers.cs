namespace System
{
    /// <summary>
    /// A class to enable indexer-like properties.
    /// </summary>
    public class PsuedoIndexers
    {
        /// <summary>
        /// A PsuedoIndexer with both getter and setter accessors.
        /// </summary>
        /// <typeparam name="I">The type to use for the indexer.</typeparam>
        /// <typeparam name="T">The return type of the indexer.</typeparam>
        public sealed class Indexer<I, T>
        {
            private readonly Func<I?, T?> _get;
            private readonly Action<I?, T?> _set;
            /// <summary>
            /// The underlying indexer for a PsuedoIndexer.
            /// </summary>
            /// <param name="index">Index value.</param>
            public T? this[I? index]
            {
                get => _get != null ? _get(index) : default;
                set => _set?.Invoke(index, value);
            }
            /// <summary>
            /// Constructs a new Indexer.
            /// </summary>
            /// <param name="get">The get accessor.</param>
            /// <param name="set">The set accessor.</param>
            public Indexer(Func<I?, T?> get, Action<I?, T?> set)
            {
                _get = get;
                _set = set;
            }
        }

        /// <summary>
        /// A PsuedoIndexer with only a get accessor.
        /// </summary>
        /// <typeparam name="I">The type to use for the indexer.</typeparam>
        /// <typeparam name="T">The return type of the indexer.</typeparam>
        public sealed class ReadOnlyIndexer<I, T>
        {
            private readonly Func<I?, T?> _get;
            /// <summary>
            /// The underlying indexer for a PsuedoIndexer.
            /// </summary>
            /// <param name="index">Index value.</param>
            public T? this[I? index] => _get != null ? _get(index) : default;
            /// <summary>
            /// Constructs a new ReadOnlyIndexer.
            /// </summary>
            /// <param name="get">The get accessor.</param>
            public ReadOnlyIndexer(Func<I?, T?> get) => _get = get;
        }

        /// <summary>
        /// A PsuedoIndexer with only a set accessor.
        /// </summary>
        /// <typeparam name="I">The type to use for the indexer.</typeparam>
        /// <typeparam name="T">The return type of the indexer.</typeparam>
        public sealed class WriteOnlyIndexer<I, T>
        {
            private readonly Action<I?, T?> _set;
            /// <summary>
            /// The underlying indexer for a PsuedoIndexer.
            /// </summary>
            /// <param name="index">Index value.</param>
            public T? this[I? index] { set => _set?.Invoke(index, value); }
            /// <summary>
            /// Constructs a new WriteOnlyIndexer.
            /// </summary>
            /// <param name="set">The set accessor.</param>
            public WriteOnlyIndexer(Action<I?, T?> set) => _set = set;
        }
    }
}