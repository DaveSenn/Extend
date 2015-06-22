#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the string representation of a GUID to the equivalent <see cref="Guid" /> structure.
        /// </summary>
        /// <param name="value">The GUID to convert.</param>
        /// <param name="outValue">
        ///     The structure that will contain the parsed value. If the method returns true,result contains a
        ///     valid System.Guid. If the method returns false, result equals <see cref="Guid.Empty" />.
        /// </param>
        /// <returns>Returns true if the parse operation was successful; otherwise, false.</returns>
        public static Boolean TryParsGuid( this String value, out Guid outValue )
        {
            value.ThrowIfNull( () => value );

            return Guid.TryParse( value, out outValue );
        }
    }
}