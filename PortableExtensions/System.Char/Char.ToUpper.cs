#region Using

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="char" />.
    /// </summary>
    public static partial class CharEx
    {
        //replace
        /// <summary>
        ///     Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-
        ///     specific formatting information.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns>
        ///     The uppercase equivalent of , modified according to , or the unchanged value of  if  is already uppercase,
        ///     has no uppercase equivalent, or is not alphabetic.
        /// </returns>
        public static Char ToUpper( this Char c, CultureInfo culture = null )
        {
#if mono
            return Char.ToUpper( c );
#elif DotNet
			return Char.ToUpper(c, culture ?? CultureInfo.InvariantCulture);
			#endif
        }
    }
}