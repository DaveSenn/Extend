#region Usings

using System;
using System.Globalization;

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
        public static CultureInfo SafeToCultureInfo( this String name )
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
        public static CultureInfo SafeToCultureInfo( this String name, CultureInfo fallbackCulture )
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