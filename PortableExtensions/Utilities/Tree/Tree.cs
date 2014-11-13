#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class representing a tree data structure.
    /// </summary>
    /// <typeparam name="T">The type of the values in the tree.</typeparam>
    public class Tree<T> : TreeNode<T>, ITree<T>
    {
        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="Tree{T}" /> class.
        /// </summary>
        public Tree()
        {
        }

        /// <summary>
        ///     Initialize a new instance of the <see cref="Tree{T}" /> class.
        /// </summary>
        /// <param name="children">The children of the tree</param>
        public Tree( ITreeNodeCollection<T> children )
            : base( children )
        {
        }

        #endregion

        #region Overrides of TreeNode<T>

        /// <summary>
        ///     Gets the items which matches the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the items which matches the given predicate.</returns>
        public override IEnumerable<T> FindItem( Func<T, Boolean> predicate )
        {
            return Children.SelectMany( x => x.FindItem( predicate ) );
        }

        /// <summary>
        ///     Gets the nodes which matches the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the nodes which matches the given predicate.</returns>
        public override IEnumerable<ITreeNode<T>> FindNode( Func<T, Boolean> predicate )
        {
            return Children.SelectMany( x => x.FindNode( predicate ) );
        }

        #endregion

        #region Overrides of TreeNode<T>

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            return "Tree Root - Value: {0}, Count: {1}".F( Value, Children.Count );
        }

        #endregion

        #region Implementation of ITreeNode<T>

        /// <summary>
        ///     Gets or sets the parent of the node.
        /// </summary>
        /// <remarks>
        ///     You can not set the parent of a tree root.
        /// </remarks>
        /// <exception cref="InvalidOperationException">You can not set the parent of a tree root.</exception>
        /// <value>The parent of the node.</value>
        public new ITreeNode<T> Parent
        {
            get { return null; }
            set { throw new InvalidOperationException( "You can not set the parent of a tree root." ); }
        }

        /// <summary>
        ///     Gets the depth of the node.
        /// </summary>
        /// <remarks>
        ///     Returns always
        ///     <value>0</value>
        ///     .
        /// </remarks>
        /// <value>The depth of the node.</value>
        public new Int32 Depth
        {
            get { return 0; }
        }

        /// <summary>
        ///     Gets the root of the tree.
        /// </summary>
        /// <remarks>
        ///     Returns always the
        ///     <value>this</value>
        ///     .
        /// </remarks>
        /// <value>The root of the tree.</value>
        public new ITreeNode<T> Root
        {
            get { return this; }
        }

        /// <summary>
        ///     Gets a value indicating whether the node has a parent or not.
        /// </summary>
        /// <remarks>
        ///     Returns always
        ///     <value>false</value>
        ///     .
        /// </remarks>
        /// <value>A value indicating whether the node has a parent or not.</value>
        public new Boolean HasParent
        {
            get { return false; }
        }

        /// <summary>
        ///     Sets the parent of the tree node.
        /// </summary>
        /// <remarks>
        ///     You can not set the parent of a tree root.
        /// </remarks>
        /// <exception cref="InvalidOperationException">You can not set the parent of a tree root.</exception>
        /// <param name="parent">The new parent.</param>
        /// <param name="attacheToParent">
        ///     A value determining whether the node should add it self to the children of the new parent
        ///     or not.
        /// </param>
        public new void SetParent( ITreeNode<T> parent, Boolean attacheToParent = true )
        {
            throw new InvalidOperationException( "You can not set the parent of a tree root." );
        }

        #endregion
    }
}