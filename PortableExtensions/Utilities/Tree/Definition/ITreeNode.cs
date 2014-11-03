#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Interface representing a tree node.
    /// </summary>
    /// <typeparam name="T">The type of the node's value.</typeparam>
    public interface ITreeNode<T> : IDisposable, IEnumerable<ITreeNode<T>>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the value of the node.
        /// </summary>
        /// <value>The value of the node.</value>
        T Value { get; set; }

        /// <summary>
        ///     Gets or sets the dispose traversal direction.
        /// </summary>
        /// <value>The dispose traversal direction.</value>
        TreeTraversalDirection DisposeTraversalDirection { get; set; }

        /// <summary>
        ///     Gets or sets the search traversal direction.
        /// </summary>
        /// <value>The search traversal direction.</value>
        TreeTraversalDirection SearchTraversalDirection { get; set; }

        /// <summary>
        ///     Gets or sets the parent of the node.
        /// </summary>
        /// <value>The parent of the node.</value>
        ITreeNode<T> Parent { get; set; }

        /// <summary>
        ///     Gets the root of the tree.
        /// </summary>
        /// <value>The root of the tree.</value>
        ITreeNode<T> Root { get; }

        /// <summary>
        ///     Gets the depth of the node.
        /// </summary>
        /// <value>The depth of the node.</value>
        Int32 Depth { get; }

        /// <summary>
        ///     Gets a value indicating whether the node has any children or not.
        /// </summary>
        /// <value>A value indicating whether the node has any children or not.</value>
        Boolean HasChildren { get; }

        /// <summary>
        ///     Gets a value indicating whether the node has a parent or not.
        /// </summary>
        /// <value>A value indicating whether the node has a parent or not.</value>
        Boolean Hasparent { get; }

        /// <summary>
        ///     Gets the children of the node.
        /// </summary>
        /// <value>The children of the node.</value>
        ITreeNodeCollection<T> Children { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the items which matches the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the items which matches the given predicate.</returns>
        IEnumerable<T> FindItem ( Func<T, Boolean> predicate );

        /// <summary>
        ///     Gets the nodes which matches the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the nodes which matches the given predicate.</returns>
        IEnumerable<ITreeNode<T>> FindNode ( Func<T, Boolean> predicate );

        /// <summary>
        ///     Adds the given value as child to the node.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <returns>Returns the added node.</returns>
        ITreeNode<T> AddChild ( T value );

        /// <summary>
        ///     Adds the given node as child to the node, if it is not already a child of the node.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <returns>Returns the added node.</returns>
        ITreeNode<T> AddChild ( ITreeNode<T> node );

        /// <summary>
        ///     Sets the parent of the tree node.
        /// </summary>
        /// <param name="parent">The new parent.</param>
        /// <param name="attacheToParent">
        ///     A value determining whether the node should add it self to the children of the new parent
        ///     or not.
        /// </param>
        void SetParent ( ITreeNode<T> parent, Boolean attacheToParent = true );

        #endregion
    }
}