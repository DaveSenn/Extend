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
        ///     Checks if th given type is a Microsoft type, based on the company attribute of it's declaring assembly.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>Returns a value of true if the given type is a Microsoft type; otherwise, false.</returns>
        public static Boolean IsMicrosoftType( this Type type )
        {
#if PORTABLE45
            var attributes = type.GetTypeInfo()
                                 .Assembly.GetCustomAttributes<AssemblyCompanyAttribute>();
#elif NET40
            var attributes = type.Assembly.GetCustomAttributes( typeof (AssemblyCompanyAttribute), false )
                                 .OfType<AssemblyCompanyAttribute>();
#endif
            return attributes.Any( x => x.Company == "Microsoft Corporation" );
        }
    }
}