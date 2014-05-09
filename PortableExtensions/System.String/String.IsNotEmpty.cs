#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="string" />.
    /// </summary>
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets whether the given <see cref="String" /> is empty or not.
        /// </summary>
        /// <param name="input">The <see cref="String" /> to check.</param>
        /// <returns>A value of true if the given <see cref="String" /> is not empty, otherwise false.</returns>
        public static Boolean IsNotEmpty( this String input )
        {
            return !IsEmpty( input );
        }
    }
}