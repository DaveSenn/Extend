#region Usings

using System.Reflection;
using System.Resources;

#endregion

#if PORTABLE45

[assembly: AssemblyTitle( "Extend.Portable" )]
[assembly: AssemblyProduct( "Extend.Portable" )]
[assembly: AssemblyTrademark( "Extend.Portable" )]
#elif NET40

[assembly: AssemblyTitle( "Extend.Net40" )]
[assembly: AssemblyProduct( "Extend.Net40" )]
[assembly: AssemblyTrademark( "Extend.Net40" )]
#endif

[assembly:
    AssemblyDescription(
        "Extend is a set of .Net extension methods build as PCL or .Net40 DLL. Extend enhance the .Net framework by adding a bunch of methods to increase developer’s productivity."
    )]

#if DEBUG

[assembly: AssemblyConfiguration( "Debug" )]
#else

[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany( "Dave Senn" )]
[assembly: AssemblyCopyright( "Copyright © Dave Senn 2015" )]
[assembly: AssemblyCulture( "" )]
[assembly: NeutralResourcesLanguage( "en" )]
[assembly: AssemblyVersion("1.1.10.0")]
[assembly: AssemblyFileVersion("1.1.10.0")]