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
