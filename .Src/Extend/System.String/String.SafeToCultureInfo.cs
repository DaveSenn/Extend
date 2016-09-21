#region Usings

using System;
using System.Globalization;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Tries to create a new <see cref="CultureInfo" /> with the given name.
        /// </summary>
        /// <param name="name">The name of the culture.</param>
        /// <returns>Returns the <see cref="CultureInfo" /> with the given name, or null if the culture is not supported.</returns>
        [Pure]
        [PublicAPI]
        public static CultureInfo SafeToCultureInfo( [NotNull] this String name )
        {
            try
            {
                return new CultureInfo( name );
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Tries to create a new <see cref="CultureInfo" /> with the given name.
        /// </summary>
        /// <param name="name">The name of the culture.</param>
        /// <param name="fallbackCulture">The culture returned if the culture with the given name is not supported.</param>
        /// <returns>Returns the <see cref="CultureInfo" /> with the given name, or <paramref name="fallbackCulture" />.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static CultureInfo SafeToCultureInfo( [NotNull] this String name, CultureInfo fallbackCulture )
        {
            try
            {
                return new CultureInfo( name );
            }
            catch
            {
                return fallbackCulture;
            }
        }
    }
}