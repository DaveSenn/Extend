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
Task("RestorePackages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solution, new NuGetRestoreSettings
        { 
            ToolPath = nuGet
        } );
});

// Build the solution
Task("Build")
    .IsDependentOn("RestorePackages")
    .Does(() =>
{	
    MSBuild(solution, settings => 
        settings.SetConfiguration(configuration)
            .SetVerbosity( Verbosity.Minimal ) );
});

// Run the unit tests
Task("RunTests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3( sourceDirectory.ToString() + "/**/bin/Release/*.Test.dll", new NUnit3Settings
        { 
            NoResults = true,
            ToolPath = nUnit
        });
});


RunTarget(target);