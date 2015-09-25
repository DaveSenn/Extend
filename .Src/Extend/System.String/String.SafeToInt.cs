﻿#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Tries to convert the given <see cref="String" /> into a <see cref="Int32" />.
        /// </summary>
        /// <exception cref="ArgumentNullException">The input can not be null.</exception>
        /// <param name="input">The <see cref="String" /> to convert.</param>
        /// <returns>
        ///     If the conversion is successfully the content of the given <see cref="String" /> as <see cref="Int32" />,
        ///     otherwise null.
        /// </returns>
        public static Int32? SafeToInt( this String input )
        {
            input.ThrowIfNull(nameof(input));

            var intValue = 0;
            if ( Int32.TryParse( input, out intValue ) )
                return intValue;
            return null;
        }
    }
}