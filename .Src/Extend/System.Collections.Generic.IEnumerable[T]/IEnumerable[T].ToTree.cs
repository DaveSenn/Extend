#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /*
        /// <summary>
        ///     TODO: MOVE TO EXTEND.
        /// </summary>
        /// <param name="breadcrumbItems"></param>
        /// <returns></returns>
        private TreeNode<BreadcrumbItem> ToTree( IEnumerable<BreadcrumbItem> breadcrumbItems )
            => new TreeNode<BreadcrumbItem>( null, ToTree( breadcrumbItems, x => x.BreadcrumbItemId, x => x.Parent?.BreadcrumbItemId ?? Guid.Empty, Guid.Empty ) );
        */

        /// <summary>
        ///     Builds a tree containing the items of the given collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">idSelector can not be null.</exception>
        /// <exception cref="ArgumentNullException">parentIdSelector can not be null.</exception>
        /// <typeparam name="TItem">The type of the items.</typeparam>
        /// <typeparam name="TKey">The type of the item key.</typeparam>
        /// <param name="collection">The collection to convert to a tree.</param>
        /// <param name="idSelector">A function used to extract the id of an item.</param>
        /// <param name="parentIdSelector">A function used to extract the id of an items parent.</param>
        /// <param name="rootId">The id of the root element.</param>
        /// <returns>Returns a tree representing the given collection.</returns>
        [PublicAPI]
        [NotNull]
        [Pure]
        public static ITreeNodeCollection<TItem> ToTree<TItem, TKey>(
            [NotNull] this IEnumerable<TItem> collection,
            [NotNull] Func<TItem, TKey> idSelector,
            [NotNull] Func<TItem, TKey> parentIdSelector,
            [CanBeNull] TKey rootId )
        {
            collection.ThrowIfNull( nameof(collection) );
            idSelector.ThrowIfNull( nameof(idSelector) );
            parentIdSelector.ThrowIfNull( nameof(parentIdSelector) );

            var rootNodes = new TreeNodeCollection<TItem>( null );
            var enumerable = collection as IList<TItem> ?? collection.ToList();
            rootNodes.AddRange(
                enumerable
                    // ReSharper disable once ImplicitlyCapturedClosure
                    .Where( x => EqualityComparer<TKey>.Default.Equals( parentIdSelector( x ), rootId ) )
                    .Select( x => new TreeNode<TItem>( x, null, ToTree( enumerable, idSelector, parentIdSelector, idSelector( x ) ) ) ) );

            return rootNodes;
        }
    }
}