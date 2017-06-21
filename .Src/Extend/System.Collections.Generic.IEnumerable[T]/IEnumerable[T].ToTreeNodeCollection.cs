#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <summary>
        ///     Builds a tree node collection containing the items of the given collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">idSelector can not be null.</exception>
        /// <exception cref="ArgumentNullException">parentIdSelector can not be null.</exception>
        /// <exception cref="InvalidOperationException">Found items without a matching parent.</exception>
        /// <exception cref="InvalidOperationException">Found items without a unique id.</exception>
        /// <typeparam name="TItem">The type of the items.</typeparam>
        /// <typeparam name="TKey">The type of the item key.</typeparam>
        /// <param name="collection">The collection to convert to a tree.</param>
        /// <param name="idSelector">A function used to extract the id of an item.</param>
        /// <param name="parentIdSelector">A function used to extract the id of an items parent.</param>
        /// <param name="rootId">The id of the root element.</param>
        /// <param name="equalityComparer">
        ///     A <see cref="EqualityComparer{TKey}" /> used to compare the ids of the items, or null to
        ///     use the default <see cref="EqualityComparer{TKey}" />.
        /// </param>
        /// <returns>Returns a tree representing the given collection.</returns>
        [PublicAPI]
        [NotNull]
        [Pure]
        public static ITreeNodeCollection<TItem> ToTreeNodeCollection<TItem, TKey>(
            [NotNull] this IEnumerable<TItem> collection,
            [NotNull] Func<TItem, TKey> idSelector,
            [NotNull] Func<TItem, TKey> parentIdSelector,
            [CanBeNull] TKey rootId,
            [CanBeNull] IEqualityComparer<TKey> equalityComparer = null )
        {
            collection.ThrowIfNull( nameof(collection) );
            idSelector.ThrowIfNull( nameof(idSelector) );
            parentIdSelector.ThrowIfNull( nameof(parentIdSelector) );

            var enumerable = collection as IList<TItem> ?? collection.ToList();
            equalityComparer = equalityComparer ?? EqualityComparer<TKey>.Default;

            // Get all items without a unique id
            var itemsWithSameKey = enumerable
                .Where( x => enumerable.Count( y => equalityComparer.Equals( idSelector( x ), idSelector( y ) ) ) > 1 )
                .ToList();
            if ( itemsWithSameKey.Any() )
            {
                // Found items without a unique id => throw exception
                var sb = new StringBuilder();
                sb.AppendLine( "The following items do not have a unique id:" );
                itemsWithSameKey.ForEach( x => sb.AppendLine( $"\t {x}" ) );

                throw new InvalidOperationException( sb.ToString() );
            }

            // Get all items without a matching parent
            var itemsWithNoParent = enumerable.Where( x => enumerable
                                                               .Where( y => !y.RefEquals( x ) )
                                                               .All( y => !equalityComparer.Equals( idSelector( y ), parentIdSelector( x ) ) )
                                                           && !equalityComparer.Equals( parentIdSelector( x ), rootId ) )
                                              .ToList();

            // ReSharper disable once InvertIf
            if ( itemsWithNoParent.Any() )
            {
                // Found items without a marching parent => throw exception
                var sb = new StringBuilder();
                sb.AppendLine( "Could not find a matching parent for the following items:" );
                itemsWithNoParent.ForEach( x => sb.AppendLine( $"\t {x}" ) );

                throw new InvalidOperationException( sb.ToString() );
            }

            return ToTreeNodeCollectionInternal( enumerable, idSelector, parentIdSelector, rootId, equalityComparer );
        }

        /// <summary>
        ///     Builds a tree node collection containing the items of the given collection.
        /// </summary>
        /// <typeparam name="TItem">The type of the items.</typeparam>
        /// <typeparam name="TKey">The type of the item key.</typeparam>
        /// <param name="collection">The collection to convert to a tree.</param>
        /// <param name="idSelector">A function used to extract the id of an item.</param>
        /// <param name="parentIdSelector">A function used to extract the id of an items parent.</param>
        /// <param name="rootId">The id of the root element.</param>
        /// <param name="equalityComparer">A <see cref="EqualityComparer{TKey}" /> used to compare the ids of the items.</param>
        /// <returns>Returns a tree representing the given collection.</returns>
        [NotNull]
        [Pure]
        private static ITreeNodeCollection<TItem> ToTreeNodeCollectionInternal<TItem, TKey>(
            // ReSharper disable once ParameterTypeCanBeEnumerable.Local
            [NotNull] this ICollection<TItem> collection,
            [NotNull] Func<TItem, TKey> idSelector,
            [NotNull] Func<TItem, TKey> parentIdSelector,
            [CanBeNull] TKey rootId,
            [NotNull] IEqualityComparer<TKey> equalityComparer )
        {
            var rootNodes = new TreeNodeCollection<TItem>( null );
            rootNodes.AddRange(
                collection
                    // ReSharper disable once ImplicitlyCapturedClosure
                    .Where( x => equalityComparer.Equals( parentIdSelector( x ), rootId ) )
                    .Select( x => new TreeNode<TItem>( x, null, ToTreeNodeCollectionInternal( collection, idSelector, parentIdSelector, idSelector( x ), equalityComparer ) ) ) );

            return rootNodes;
        }
    }
}