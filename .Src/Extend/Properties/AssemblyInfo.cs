#region Usings

using System.Reflection;
using System.Resources;

#endregion

[assembly: AssemblyTitle("Extend")]
[assembly:
    AssemblyDescription(
        "Extend is a set of .Net extension methods build as portable class library. " +
        "Extend enhance the .Net framework by adding a bunch of methods to increase developer’s productivity.")]

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else

[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("Dave Senn")]
[assembly: AssemblyProduct("Extend")]
[assembly: AssemblyCopyright("Copyright © Dave Senn 2015")]
[assembly: AssemblyTrademark("Extend")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("1.1.4.0")]
[assembly: AssemblyFileVersion("1.1.4.0")]