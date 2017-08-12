// Read start arguments
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var verbosity = Argument("verbosity", "Diagnostic");

// Paths to the root directories
var sourceDirectory = Directory("../.Src");
var toolDirectory = Directory("../.Tools");
var buildDirectory = Directory("../.Build");
var outputDirectory = Directory("../.Output");

// The path to the solution file
var solution = sourceDirectory + File("Extend.sln");
var testDirectory = sourceDirectory + Directory("Extend.Testing");
var libDirectory = sourceDirectory + Directory("Extend");
var libBinDirectory = libDirectory + Directory("bin") + Directory(configuration);

// Executables
var nuGet = toolDirectory + File("NuGet/nuget.exe");

// Clean all build output
Task("Clean")
    .Does(() =>
{	
    CleanDirectory( sourceDirectory + Directory("Extend/bin") );
    CleanDirectory( sourceDirectory + Directory("Extend.Testing/bin") );
    CleanDirectory( outputDirectory );
});

// Restore all NuGet packages
Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(solution);
});

// Patches the version of the library
Task("PatchVersion")
    .IsDependentOn("Restore")
    .Does(() =>
{
    // Get the current version => null on local system
    var currentVersion = GetBuildVersion();
    Information("Current version is: '" + currentVersion + "'");

    var projects = GetFiles(libDirectory.ToString() + "/**/*.csproj");
    foreach (var project in GetFiles(libDirectory.ToString() + "/**/*.csproj"))
    {
        var x = new System.Xml.XmlDocument();
        using ( var fs = System.IO.File.OpenRead( project.ToString() ) )
            x.Load( fs );
        
        var fileVersion = x.GetElementsByTagName( "FileVersion" );
        if(currentVersion == null)
            currentVersion = fileVersion[0].InnerText;
        fileVersion[0].InnerText = currentVersion;

        var version = x.GetElementsByTagName( "Version" );
        version[0].InnerText = currentVersion;

        var assemblyVersion = x.GetElementsByTagName( "AssemblyVersion" );
        assemblyVersion[0].InnerText = currentVersion;       

        using ( var fs = System.IO.File.Open( project.ToString(), FileMode.Create) )
            x.Save( fs );
    }
});

// Build the solution
Task("Build")
    .IsDependentOn("PatchVersion")
    .Does(() =>
{	
    DotNetCoreBuild(
                solution,
                new DotNetCoreBuildSettings()
                {
                    Configuration = configuration
                });
});

// Run the unit tests
Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    var projects = GetFiles(testDirectory.ToString() + "/**/*.csproj");
    foreach(var project in projects)
    {
        DotNetCoreTest(
                project.ToString(),
                new DotNetCoreTestSettings()
                {                    
                    Configuration = configuration,
                    NoBuild = true
                });
    }
});

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        foreach (var project in GetFiles(libDirectory.ToString() + "/**/*.csproj"))
        {
            DotNetCorePack(
                project.ToString(),
                new DotNetCorePackSettings()
                {
                    Configuration = configuration,
                    OutputDirectory = outputDirectory
                });
        }

        CopyDirectory(libBinDirectory, outputDirectory);
    });

// Default task
Task("Default")
  .IsDependentOn("Pack")
  .Does(() =>
{
    Information("Default task started");
});

// Run the target task
RunTarget(target);

/// <summary>
///     Gets the version of the current build.
/// </summary>
/// <returns>Returns the version of the current build.</returns>
private String GetBuildVersion()
{
	var version = String.Empty;
	
    // Try to get the version from AppVeyor
    var appVeyorProvider = BuildSystem.AppVeyor;
    if( appVeyorProvider.IsRunningOnAppVeyor )
        return appVeyorProvider.Environment.Build.Version; //+ "-alpha";
	
    return null;
}