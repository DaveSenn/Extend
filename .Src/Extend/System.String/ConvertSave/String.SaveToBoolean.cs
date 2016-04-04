#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a boolean.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the boolean.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean SaveToBoolean( [CanBeNull] this String value, Boolean? defaultValue = null )
        {
            Boolean outValue;
            return value.TryParsBoolean( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }
    }
}