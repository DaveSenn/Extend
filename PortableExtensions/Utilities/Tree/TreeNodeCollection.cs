#region Usings

using System;
using System.Collections.ObjectModel;
using PortableExtensions;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class representing a collection of tree nodes.
    /// </summary>
    /// <typeparam name="T">The type of the value of the tree nodes.</typeparam>
    public class TreeNodeCollection<T> : Collection<ITreeNode<T>>, ITreeNodeCollection<T>
    {
        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="TreeNodeCollection{T}" /> class.
        /// </summary>
        /// <param name="parent">The parent of the node.</param>
        public TreeNodeCollection ( ITreeNode<T> parent )
        {
            Parent = parent;
        }

        #endregion

        #region Implementation of ITreeNodeCollection<T>

        #region Properties

        /// <summary>
        ///     Gets the parent of the collection.
        /// </summary>
        /// <value>The parent of the collection.</value>
        public ITreeNode<T> Parent { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the given value as new node to the list and sets it's parent to the parent of the list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <returns>Returns the new created node.</returns>
        public ITreeNode<T> Add ( T value )
        {
            var node = new TreeNode<T>( value );
            Add( node );

            return node;
        }

        #endregion

        #endregion

        #region Implementation of ICollection<ITreeNode<T>>

        /// <summary>
        ///     Adds the given item to the list and sets it's parent to the parent of the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public new void Add ( ITreeNode<T> item )
        {
            base.Add( item );
            item.Parent = Parent;
        }

        /// <summary>
        ///     Removes the given item form the list and sets it's parent to null.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>
        ///     true if item is successfully removed; otherwise, false. This method also
        ///     returns false if item was not found in the original <see cref="System.Collections.ObjectModel.Collection{T}" />.
        /// </returns>
        public new Boolean Remove ( ITreeNode<T> item )
        {
            if ( item != null )
                item.Parent = null;

            return base.Remove( item );
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override String ToString ()
        {
            return "Count: {0}".F( Count );
        }

        #endregion
    }
}