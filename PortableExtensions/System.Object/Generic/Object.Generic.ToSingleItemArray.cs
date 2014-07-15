#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Creates a array with the given value as only item.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="value">The value to add to teh new created array.</param>
        /// <returns>Return sthe new created array.</returns>
        public static T[] ToSingleItemArray<T>(this T value)
        {
            return new[]
            {
                value
            };
        }
    }
}