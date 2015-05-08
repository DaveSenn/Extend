#region Usings

using System;
using System.Collections.ObjectModel;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class representing a collection of tree nodes.
    /// </summary>
    /// <typeparam name="T">The type of the value of the tree nodes.</typeparam>
    public class TreeNodeCollection<T> : Collection<ITreeNode<T>>, ITreeNodeCollection<T>
    {
        #region Fields

        /// <summary>
        ///     The parent of the tree node collection.
        /// </summary>
        private ITreeNode<T> _parent;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="TreeNodeCollection{T}" /> class.
        /// </summary>
        /// <param name="parent">The parent of the node.</param>
        public TreeNodeCollection( ITreeNode<T> parent )
        {
            _parent = parent;
        }

        #endregion

        #region Implementation of ITreeNodeCollection<T>

        #region Properties

        /// <summary>
        ///     Gets the parent of the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">Parent can not be null.</exception>
        /// <value>The parent of the collection.</value>
        public ITreeNode<T> Parent
        {
            get { return _parent; }
            set
            {
                if ( _parent == value )
                    return;

                if ( _parent != null )
                    _parent.Children = new TreeNodeCollection<T>( _parent );
                _parent = value;
                if ( _parent != null )
                {
                    _parent.Children.DetachFromParent();
                    _parent.Children = this;
                }
                this.ForEach( x => x.SetParent( _parent, false ) );
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the given value as new node to the list and sets it's parent to the parent of the list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <returns>Returns the new created node.</returns>
        public ITreeNode<T> Add( T value )
        {
            var node = new TreeNode<T>( value );
            Add( node );

            return node;
        }

        /// <summary>
        ///     Detaches the collection and all it's items form it's current parent.
        /// </summary>
        public void DetachFromParent()
        {
            _parent = null;
            this.ForEach( x => x.Parent = null );
        }

        /// <summary>
        ///     Adds the given item to the list and sets it's parent to the parent of the list.
        /// </summary>
        /// <exception cref="ArgumentNullException">item can not be null.</exception>
        /// <param name="item">The item to add.</param>
        /// <param name="setParent">
        ///     A value indicating weather the parent of the given item should be set to the parent of the
        ///     collection or not.
        /// </param>
        public void Add( ITreeNode<T> item, Boolean setParent )
        {
            item.ThrowIfNull( () => item );

            if ( Contains( item ) )
                return;

            base.Add( item );
            if ( setParent )
                item.Parent = Parent;
        }

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
        public Boolean Remove( ITreeNode<T> item, Boolean setParent )
        {
            item.ThrowIfNull( () => item );

            var result = base.Remove( item );
            if ( result && setParent )
                item.Parent = null;

            return result;
        }

        #endregion

        #endregion

        #region Implementation of ICollection<ITreeNode<T>>

        /// <summary>
        ///     Adds the given item to the list and sets it's parent to the parent of the list.
        /// </summary>
        /// <exception cref="ArgumentNullException">item can not be null.</exception>
        /// <param name="item">The item to add.</param>
        public new void Add( ITreeNode<T> item )
        {
            Add( item, true );
        }

        /// <summary>
        ///     Removes the given item form the list and sets it's parent to null.
        /// </summary>
        /// <exception cref="ArgumentNullException">item can not be null.</exception>
        /// <param name="item">The item to remove.</param>
        /// <returns>
        ///     true if item is successfully removed; otherwise, false. This method also
        ///     returns false if item was not found in the original <see cref="System.Collections.ObjectModel.Collection{T}" />.
        /// </returns>
        public new Boolean Remove( ITreeNode<T> item )
        {
            return Remove( item, true );
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            return "Count: {0}, Parent: {{{1}}}".F( Count, Parent == null ? "[NULL]" : Parent.ToString() );
        }

        #endregion
    }
}