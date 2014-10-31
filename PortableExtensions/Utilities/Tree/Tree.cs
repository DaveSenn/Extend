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
        public Tree ()
        {
        }

        /// <summary>
        ///     Initialize a new instance of the <see cref="Tree{T}" /> class.
        /// </summary>
        /// <param name="children">The children of the tree</param>
        public Tree ( ITreeNodeCollection<T> children )
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
        public override IEnumerable<T> FindItem ( Func<T, Boolean> predicate )
        {
            return Children.SelectMany( x => x.FindItem( predicate ) );
        }

        #region Implementation of ITreeItem<T>

        /// <summary>
        ///     Gets the nodes which matches the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the nodes which matches the given predicate.</returns>
        public override IEnumerable<ITreeNode<T>> FindNode ( Func<T, Boolean> predicate )
        {
            return Children.SelectMany( x => x.FindNode( predicate ) );
        }

        #endregion

        #endregion
    }
}