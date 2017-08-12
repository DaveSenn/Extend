#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
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
        /// <exception cref="ArgumentException">Can not format a empty string to a file extension.</exception>
        /// <returns>The correct formatted file extension.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String FormatFileExtension( [NotNull] this String fileExtension )
        {
            fileExtension.ThrowIfNull( nameof(fileExtension) );

            if ( fileExtension.IsEmpty() )
                throw new ArgumentException( "Can not format a empty string to a file extension.", nameof(fileExtension) );

            if ( !fileExtension.StartsWith( ".", StringComparison.Ordinal ) )
                fileExtension = fileExtension.Insert( 0, "." );
            return fileExtension.ToLower();
        }
    }
}