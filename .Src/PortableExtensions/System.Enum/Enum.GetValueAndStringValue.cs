#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Enum" />.
    /// </summary>
    public static partial class EnumEx
    {
        /// <summary>
        ///     Gets a dictionary containing the string value for each value of the enumeration of the given type.
        /// </summary>
        /// <exception cref="ArgumentException">T must be an enumerated type.</exception>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <returns>Returns a key value pair for each value of the specified enumeration type.</returns>
        public static IDictionary<T, String> GetValueAndStringValue<T>() where T : struct
        {
            var values = GetValues<T>();
            return values.ToDictionary( x => x, x => x.ToString() );
        }
    }
}