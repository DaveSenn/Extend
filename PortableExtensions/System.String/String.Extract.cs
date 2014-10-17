#region Usings

using System;
using System.Linq;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts parts of the input string, based on the predicate given.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <param name="str">The string to extract.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The extracted parts of the input string.</returns>
        public static String Extract ( this String str, Func<Char, Boolean> predicate )
        {
            str.ThrowIfNull( () => str );
            predicate.ThrowIfNull( () => predicate );

            return new String( str.ToCharArray().Where( predicate ).ToArray() );
        }
    }
}