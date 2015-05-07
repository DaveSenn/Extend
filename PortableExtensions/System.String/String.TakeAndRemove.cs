#region Usings

using System;
using System.Linq;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns a specified number of characters from the start of the given value
        ///     and removes the returned characters from the value.
        /// </summary>
        /// <param name="value">
        ///     The source value.
        /// </param>
        /// <param name="count">The numbers of characters to return.</param>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <returns>
        ///     A <see cref="String" /> that contains the specified number of chars.
        /// </returns>
        public static String TakeAndRemove( this Int32 count, ref String value )
        {
            if ( value == null )
                throw new ArgumentNullException( "value can not be null." );

            if ( count > value.Length )
                throw new ArgumentOutOfRangeException( "count",
                                                       "Count must be smaller than the length of the given value." );

            var returnValue = new String( value.ToCharArray()
                                               .Take( count )
                                               .ToArray() );
            value = value.Remove( 0, count );
            return returnValue;
        }
    }
}