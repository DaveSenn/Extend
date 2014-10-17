#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Converts the given IEnumerable to a ObservableCollection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <returns>The given IEnumerable as ObservableCollection.</returns>
        public static ObservableCollection<T> ToObservableCollection<T> ( this IEnumerable<T> enumerable )
        {
            enumerable.ThrowIfNull( () => enumerable );

            return new ObservableCollection<T>( enumerable );
        }
    }
}