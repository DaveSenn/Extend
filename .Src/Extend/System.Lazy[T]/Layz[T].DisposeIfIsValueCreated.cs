#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing extension methods for <see cref="Lazy{T}" />.
    /// </summary>
    public static class LayzEx
    {
        /// <summary>
        ///     Disposes the value of the given lazy, if the value was created.
        /// </summary>
        /// <typeparam name="T">The type of object that is being lazily initialized.</typeparam>
        /// <param name="lazy">A see <see cref="Lazy{T}" />.</param>
        [PublicAPI]
        public static void DisposeIfIsValueCreated<T>( [CanBeNull] this Lazy<T> lazy ) where T : IDisposable
        {
            if ( lazy != null && lazy.IsValueCreated )
                lazy.Value.Dispose();
        }
    }
}