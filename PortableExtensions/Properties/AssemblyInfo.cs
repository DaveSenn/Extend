#region Using

using System.Reflection;
using System.Resources;

#endregion

// General Information about an assembly is controlled through the following set of attributes. Change these attribute values to modify the information associated with an assembly.

[assembly: AssemblyTitle( "PortableExtensions" )]
[assembly: AssemblyDescription( "A set of .Net extension methods build as portable class library" )]
#if DEBUG

[assembly: AssemblyConfiguration( "Debug" )]
#else

[assembly: AssemblyConfiguration( "Release" )]
#endif

[assembly: AssemblyCompany( "Dave Senn" )]
[assembly: AssemblyProduct( "PortableExtensions" )]
[assembly: AssemblyCopyright( "Copyright © Dave Senn 2014" )]
[assembly: AssemblyTrademark( "PortableExtensions" )]
[assembly: AssemblyCulture( "" )]
[assembly: NeutralResourcesLanguage( "en" )]

// Version information for an assembly consists of the following four values:
//
// Major Version Minor Version Build Number Revision
//
// You can specify all the values or you can default the Build and Revision Numbers by using the '*' as shown below: [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.14.0")]
[assembly: AssemblyFileVersion("1.0.14.0")]