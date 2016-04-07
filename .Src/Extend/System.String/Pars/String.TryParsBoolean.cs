#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Tries to convert the specified string representation of a logical value to
        ///     its <see cref="Boolean" /> equivalent. A return value indicates whether the conversion
        ///     succeeded or failed.
        /// </summary>
        /// <param name="value">A string containing the value to convert.</param>
        /// <param name="outValue">
        ///     When this method returns, if the conversion succeeded, contains true if value
        ///     is equal to <see cref="Boolean.TrueString" /> or false if value is equal to <see cref="Boolean.FalseString" />.
        ///     If the conversion failed, contains false. The conversion fails if value is
        ///     null or is not equal to the value of either the <see cref="Boolean.TrueString" />
        ///     or <see cref="Boolean.FalseString" /> field.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsBoolean( [CanBeNull] this String value, out Boolean outValue )
            => Boolean.TryParse( value, out outValue );
    }
}