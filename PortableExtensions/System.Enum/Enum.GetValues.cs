#region Usings

using System;
using System.Collections;
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
        /// <exception cref="ArgumentException">T must be an enumerated type.</exception>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <returns>All values of the specified enumeration.</returns>
        public static IEnumerable<T> GetValues<T> () where T : struct
        {
            var type = typeof (T);
            if ( !type.GetTypeInfo().IsEnum )
                throw new ArgumentException( "T must be an enumerated type." );

            return Enum.GetValues( type ).OfType<T>();
        }

        /// <summary>
        ///     Gets the values of the specified enumeration.
        /// </summary>
        /// <remarks>
        ///     How to cast returned values:
        ///     values.Cast{Object}();
        ///     values.Select( x => Convert.ChangeType( x, type ) );
        /// </remarks>
        /// <exception cref="ArgumentException">T must be an enumerated type.</exception>
        /// <param name="type">The type of the enumeration.</param>
        /// <returns>All values of the specified enumeration.</returns>
        public static IEnumerable GetValues ( Type type )
        {
            if ( !type.GetTypeInfo().IsEnum )
                throw new ArgumentException( "T must be an enumerated type." );

            return Enum.GetValues( type );
        }
    }
}