#region Usings

using System;
using System.Linq;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Type" />.
    /// </summary>
    public static partial class TypeEx
    {
        /// <summary>
        ///     Checks if th egiven type is a microsoft type, based on the company attribut eof it's declaring assembly.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>Returns a value of true if the given type is a microsft type; otherweise, false.</returns>
        public static Boolean IsMicrosoftType( this Type type )
        {
#if PORTABLE45
            var attributes = type.GetTypeInfo()
                                 .Assembly.GetCustomAttributes<AssemblyCompanyAttribute>();
#elif NET40
            var attributes = type.Assembly.GetCustomAttributes( typeof (AssemblyCompanyAttribute), false )
                                 .OfType<AssemblyCompanyAttribute>();
#endif
            return attributes.Any( attr => attr.Company == "Microsoft Corporation" );
        }
    }
}