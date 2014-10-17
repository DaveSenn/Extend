#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Swaps the given values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="obj">An object to cal the extension method on, can be null.</param>
        /// <param name="value0">The first value.</param>
        /// <param name="value1">The second value.</param>
        public static void Swap<T> ( this Object obj, ref T value0, ref T value1 )
        {
            var temp = value0;
            value0 = value1;
            value1 = temp;
        }
    }
}