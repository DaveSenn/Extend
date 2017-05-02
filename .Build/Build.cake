// Read start arguments
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var verbosity = Argument("verbosity", "Diagnostic");

// Paths to the root directories
var sourceDirectory = Directory("../.Src");
var toolDirectory = Directory("../.Tools");
var buildDirectory = Directory("../.Build");
var outputDirectory = Directory("../.Output");
var outputNuGetDirectory = Directory("../.Output/NuGet");

// The path to the solution file
var solution = sourceDirectory + File("Extend.sln");
var testDirectory = sourceDirectory + Directory("Extend.Testing");
var libDirectory = sourceDirectory + Directory("Extend");

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

// Build the solution
Task("Build")
    .IsDependentOn("Restore")
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
    //var projects = GetFiles(testDirectory.ToString() + "/**/*.csproj");
    /*
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
    */
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
        version = appVeyorProvider.Environment.Build.Version;
	else
	{
	    // Get the version from the built DLL
		var outputDll = System.IO.Directory.EnumerateFiles( outputNuGetDirectory, "*", System.IO.SearchOption.AllDirectories).First( x => x.Contains( ".dll" ) );
		var assembly = System.Reflection.Assembly.LoadFile(  MakeAbsolute( File( outputDll ) ).ToString() );
		version = assembly.GetName().Version.ToString();
	}
	
	return version;
	// return version + "-alpha";
}