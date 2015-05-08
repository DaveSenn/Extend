#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Tries to convert a string value to an enum.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="value">The String value to convert.</param>
        /// <param name="ignoreCase">Determines whether or not to ignore the casing of the string.</param>
        /// <param name="outValue">The output value.</param>
        /// <returns>Returns the converted enum value.</returns>
        public static Boolean TryToEnum<T>( String value, out T outValue, Boolean ignoreCase = true ) where T : struct
        {
            value.ThrowIfNull( () => value );

            return Enum.TryParse( value, ignoreCase, out outValue );
        }
    }
}