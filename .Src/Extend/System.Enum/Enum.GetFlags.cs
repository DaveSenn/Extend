#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Enum" />.
    /// </summary>
    public static partial class EnumEx
    {
        /// <summary>
        ///     Gets all SET flags of the given enumeration value.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="enumValue">The enumeration value.</param>
        /// <returns>Returns all SET flags of the given value.</returns>
        [PublicAPI]
        [NotNull]
        [Pure]
        public static IEnumerable<T> GetFlags<T>( this Enum enumValue ) where T : struct//, IConvertible Only available on .NET Standard 1.3+
            => Enum.GetValues( enumValue.GetType() )
                   .Cast<Enum>()
                   .Where( enumValue.HasFlag )
                   .Cast<T>();
    }
}