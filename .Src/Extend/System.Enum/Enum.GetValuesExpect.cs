#region Usings

using System;
using System.Collections;
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
        ///     Gets all values of the specified enumeration type, expect the specified values.
        /// </summary>
        /// <exception cref="ArgumentException">T must be an enumerated type.</exception>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="exceptions">The values to exclude from the result.</param>
        /// <returns>Returns all values of the specified enumeration type, expect the specified values.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> GetValuesExpect<T>( [CanBeNull] params T[] exceptions ) where T : struct
        {
            var values = GetValues<T>();

            return exceptions == null
                ? values
                : values
                  .ToList()
                  .RemoveRange( exceptions );
        }

        /// <summary>
        ///     Gets all values of the specified enumeration type, expect the specified values.
        /// </summary>
        /// <remarks>
        ///     How to cast returned values:
        ///     values.Cast{Object}();
        ///     values.Select( x => Convert.ChangeType( x, type ) );
        /// </remarks>
        /// <exception cref="ArgumentException">T must be an enumerated type.</exception>
        /// <param name="type">The type of the enumeration.</param>
        /// <param name="exceptions">The values to exclude from the result.</param>
        /// <returns>Returns all values of the specified enumeration type, expect the specified values.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable GetValuesExpect( [NotNull] Type type, [CanBeNull] params Object[] exceptions )
        {
            var values = GetValues( type )
                         .OfType<Object>()
                         .ToList();

            return exceptions == null ? values : values.RemoveRange( exceptions );
        }
    }
}