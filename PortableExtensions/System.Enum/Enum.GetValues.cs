#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Enum" />.
    /// </summary>
    public static partial class EnumEx
    {
        /// <summary>
        ///     Gets the values of the specified enumeration.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <returns>All values of the specified enumeration.</returns>
        public static IEnumerable<T> GetValues<T>() where T : struct
        {
            if ( !typeof ( T ).GetTypeInfo().IsEnum )
                throw new ArgumentException( "T must be an enumerated type" );

            return Enum.GetValues( typeof ( T ) ).OfType<T>();
        }
    }
}