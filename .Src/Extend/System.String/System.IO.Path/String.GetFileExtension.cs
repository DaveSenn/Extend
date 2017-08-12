#region Usings

using System;
using System.IO;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the extension of the given file.
        /// </summary>
        /// <exception cref="ArgumentNullException">The file name can not be null.</exception>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The file extension.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetFileExtension( [NotNull] this String fileName )
        {
            fileName.ThrowIfNull( nameof(fileName) );

            return Path.GetExtension( fileName );
        }
    }
}