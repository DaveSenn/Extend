#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Checks if the Int32 is even.
        /// </summary>
        /// <param name="value">The Int32 to check.</param>
        /// <returns>Returns true if the Int32 is even, otherwise false.</returns>
        public static Boolean IsEven( this Int32 value )
        {
            return value % 2 == 0;
        }
    }
}