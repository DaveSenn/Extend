namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Returns the given value if it is not null, otherwise returns the alternative value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="alternativeValue">The alternative value.</param>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <returns>Returns the value or the alternative value.</returns>
        public static T IfNull<T>( this T value, T alternativeValue ) where T : class
        {
            return value ?? alternativeValue;
        }
    }
}