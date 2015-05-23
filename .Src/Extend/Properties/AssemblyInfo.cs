#region Usings

using System.Reflection;
using System.Resources;

#endregion

[assembly: AssemblyTitle("PortableExtensions")]
[assembly:
    AssemblyDescription(
        "PortableExtensions is a set of .Net extension methods build as portable class library. " +
        "PortableExtensions enhance the .Net framework by adding a bunch of methods to increase developer’s productivity.")]

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else

[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("Dave Senn")]
[assembly: AssemblyProduct("PortableExtensions")]
[assembly: AssemblyCopyright("Copyright © Dave Senn 2015")]
[assembly: AssemblyTrademark("PortableExtensions")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("1.1.4.0")]
[assembly: AssemblyFileVersion("1.1.4.0")]