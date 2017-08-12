#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Returns a list containing all values of the given range.
        /// </summary>
        /// <exception cref="ArgumentException">The start value can not be greater than the end value.</exception>
        /// <param name="startValue">The start of the range.</param>
        /// <param name="endValue">The end of the range.</param>
        /// <returns>Returns a list containing the specified range.</returns>
        [Pure]
        [PublicAPI]
        public static List<Int32> RangeTo( this Int32 startValue, Int32 endValue )
        {
            if ( startValue > endValue )
                throw new ArgumentException( "The start value can not be greater than the end value.", nameof(startValue) );

            var list = new List<Int32>( endValue - startValue );
            for ( var i = startValue; i <= endValue; i++ )
                list.Add( i );
            return list;
        }
    }
}