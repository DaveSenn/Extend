using System;

namespace Extend
{
    /// <summary>
    /// Interface representing an imte with an index.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIndexedItem<T>
    {
        /// <summary>
        ///     Gets the index of the item.
        /// </summary>
        /// <value>The index of the item.</value>
        Int32 Index { get; }

        /// <summary>
        ///     Gets the item.
        /// </summary>
        /// <value>The item.</value>
        T Item { get; }
    }
}