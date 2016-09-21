#region Usings

using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Creates a array with the given value as only item.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="value">The value to add to the new created array.</param>
        /// <returns>Returns the new created array.</returns>
        [NotNull]
        [ItemCanBeNull]
        [Pure]
        [PublicAPI]
        public static T[] ToSingleItemArray<T>( [CanBeNull] this T value )
            => new[]
            {
                value
            };
    }
}