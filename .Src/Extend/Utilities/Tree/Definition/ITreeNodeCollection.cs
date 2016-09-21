#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a collection of tree nodes.
    /// </summary>
    /// <typeparam name="T">The type of the items in the collection.</typeparam>
    public interface ITreeNodeCollection<T> : ICollection<ITreeNode<T>>
    {
        #region Properties

        /// <summary>
        ///     Gets the parent of the collection.
        /// </summary>
        /// <value>The parent of the collection.</value>
        ITreeNode<T> Parent { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the given value as new node to the collection.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <returns>Returns the new added node.</returns>
        [NotNull]
        [PublicAPI]
        ITreeNode<T> Add( [CanBeNull] T value );

        /// <summary>
        ///     Adds the given item to the list and sets it's parent to the parent of the list.
        /// </summary>
        /// <exception cref="ArgumentNullException">item can not be null.</exception>
        /// <param name="item">The item to add.</param>
        /// <param name="setParent">
        ///     A value indicating weather the parent of the given item should be set to the parent of the
        ///     collection or not.
        /// </param>
        [PublicAPI]
        void Add( [NotNull] ITreeNode<T> item, Boolean setParent );

        /// <summary>
        ///     Removes the given item form the list and sets it's parent to null.
        /// </summary>
        /// <exception cref="ArgumentNullException">item can not be null.</exception>
        /// <param name="item">The item to remove.</param>
        /// <param name="setParent">A value indicating whether the parent of the item should get set to null or not.</param>
        /// <returns>
        ///     true if item is successfully removed; otherwise, false. This method also
        ///     returns false if item was not found in the original <see cref="System.Collections.ObjectModel.Collection{T}" />.
        /// </returns>
        [PublicAPI]
        Boolean Remove( [NotNull] ITreeNode<T> item, Boolean setParent );

        /// <summary>
        ///     Detaches the collection and all it's items form it's current parent.
        /// </summary>
        [PublicAPI]
        void DetachFromParent();

        #endregion
    }
}