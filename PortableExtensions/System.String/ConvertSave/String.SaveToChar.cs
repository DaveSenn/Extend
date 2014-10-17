#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a char.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The char.</returns>
        public static Char SaveToChar ( this String value, Char? defaultValue = null )
        {
            value.ThrowIfNull( () => value );

            Char outValue;
            return value.TryParsChar( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }
    }
}