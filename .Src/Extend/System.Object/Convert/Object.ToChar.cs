#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Converts the given object to a char.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <param name="obj">The object to convert.</param>
        /// <returns>The char.</returns>
        public static Char ToChar( this Object obj )
        {
            obj.ThrowIfNull( () => obj );

            var str = obj.ToString();
            if ( str.Length != 1 )
                throw new InvalidCastException( "Cannot convert the given object to a char." );

            return str[0];
        }
    }
}