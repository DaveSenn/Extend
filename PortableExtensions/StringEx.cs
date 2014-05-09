using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PortableExtensions
{
    /// <summary>
    /// Class containing some extension methods for<see cref="string" />.
    /// </summary>
    public static class StringEx
    {
        /// <summary>
        /// Gets whether the given <see cref="String" /> is empty or not.
        /// </summary>
        /// <param name="input">The <see cref="String" /> to check.</param>
        /// <returns>A value of true if the given <see cref="String" /> is empty, otherwise false.</returns>
        public static Boolean IsEmpty( this String input )
        {
            return String.IsNullOrEmpty ( input ) || String.IsNullOrWhiteSpace ( input );
        }

        /// <summary>
        /// Gets whether the given <see cref="String" /> is empty or not.
        /// </summary>
        /// <param name="input">The <see cref="String" /> to check.</param>
        /// <returns>A value of true if the given <see cref="String" /> is not empty, otherwise false.</returns>
        public static Boolean IsNotEmpty( this String input )
        {
            return !IsEmpty ( input );
        }

        /// <summary>
        /// Gets whether a <see cref="Regex"/> with the specified pattern finds a match in the specified input <see cref="String"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">Input can not be null.</exception>
        /// <exception cref="ArgumentNullException">Pattern can not be null.</exception>
        /// <param name="input">The <see cref="String"/> to search for a match.</param>
        /// <param name="pattern">The regular expression pattern used by the see cref="Regex"/>.</param>
        /// <returns>A value of true if the regular expression finds a match, otherwise false.</returns>
        public static Boolean IsMatch( this String input, String pattern )
        {
            if( input == null )
                throw new ArgumentNullException ( "input", "Input can not be null." );
            if( pattern == null )
                throw new ArgumentNullException ( "pattern", "Pattern can not be null." );

            return new Regex ( pattern ).IsMatch ( input );
        }

        /// <summary>
        /// Gets whether a <see cref="Regex"/> with the specified pattern finds not a match in the specified input <see cref="String"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">Input can not be null.</exception>
        /// <exception cref="ArgumentNullException">Pattern can not be null.</exception>
        /// <param name="input">The <see cref="String"/> to search for a match.</param>
        /// <param name="pattern">The regular expression pattern used by the see cref="Regex"/>.</param>
        /// <returns>A value of true if the regular expression doesn't find a match, otherwise false.</returns>
        public static Boolean IsNotMatch( this String input, String pattern )
        {
            if( input == null )
                throw new ArgumentNullException ( "input", "Input can not be null." );
            if( pattern == null )
                throw new ArgumentNullException ( "pattern", "Pattern can not be null." );

            return !IsMatch ( input, pattern );
        }

        /// <summary>
        /// Replaces the format item in a specified <see cref="String"/> with the <see cref="String"/> representation of a corresponding <see cref="Object"/> in a specified array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The arguments can not be null.</exception>
        /// <exception cref="FormatException">Format is invalid.-or- The index of a format item is less than zero, or greater than or equal to the length of the args array.</exception>
        /// <param name="formatString">The <see cref="String"/> containing the format items.</param>
        /// <param name="args">The array containing all the corresponding values.</param>
        /// <returns>A copy of format in which the format items have been replaced by the <see cref="String"></see> representation of the corresponding objects in
        /// <paramref name="args"/>.</returns>
        public static String Format( this String formatString, params Object[] args )
        {
            if( formatString == null )
                throw new ArgumentNullException ( "formatString", "The format string can not be null." );
            if( args == null )
                throw new ArgumentNullException ( "args", "The arguments can not be null." );

            return String.Format ( CultureInfo.InvariantCulture, formatString, args );
        }

        /// <summary>
        /// Tries to convert the given <see cref="String"/> into a <see cref="Int32"/>.
        /// </summary>
        /// <param name="input">The <see cref="String"/> to convert.</param>
        /// <returns>If the conversion is successfully the content of the given <see cref="String"/> as <see cref="Int32"/>, otherwise null.</returns>
        public static Int32? SafeToInt( this String input )
        {
            var intValue = 0;
            if( Int32.TryParse ( input, out intValue ) )
                return intValue;
            return null;
        }
    }
}