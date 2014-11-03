#region Usings

using System.Collections.Generic;

#endregion

namespace PortableExtensions
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
        ITreeNode<T> Add ( T value );

        /// <summary>
        ///     Detaches the collection and all it's items form it's current parent.
        /// </summary>
        void DetachFromParent ();

        #endregion
    }
}