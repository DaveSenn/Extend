#region Usings

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
        ///     Checks if the Int32 value is a multiple of the given factor.
        /// </summary>
        /// <param name="value">The Int32 to check.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>>Returns true if the Int32 value is a multiple of the given factor.</returns>
        public static Boolean IsMultipleOf ( this Int32 value, Int32 factor )
        {
            return value % factor == 0;
        }
    }
}