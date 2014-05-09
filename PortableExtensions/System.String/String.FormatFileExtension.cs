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
        ///     Formats the given file extension.
        /// </summary>
        /// <remarks>
        ///     Formatted extension will have the following format: ".txt".
        /// </remarks>
        /// <param name="fileExtension">The file extension to format.</param>
        /// <exception cref="ArgumentNullException">The file extension can not be null.</exception>
        /// <exception cref="InvalidOperationException">Can not format a empty string to a file extension.</exception>
        /// <returns>The correct formatted file extension.</returns>
        public static String FormatFileExtension( this String fileExtension )
        {
// ReSharper disable once AccessToModifiedClosure
            fileExtension.ThrowIfNull( () => fileExtension );

            if ( fileExtension.IsEmpty() )
                throw new InvalidOperationException( "Can not format a empty string to a file extension." );

            if ( !fileExtension.StartsWith( ".", StringComparison.Ordinal ) )
                fileExtension = fileExtension.Insert( 0, "." );
            return fileExtension.ToLower();
        }
    }
}