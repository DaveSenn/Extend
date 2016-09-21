#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing an item with an index.
    /// </summary>
    /// <typeparam name="T">The type of the item</typeparam>
    public interface IIndexedItem<T>
    {
        #region Properties

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

        #endregion
    }
}