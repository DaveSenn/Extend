<#
Script containing all project-build configuration.
#>
$projects = @(
	#@{  Name = "Newtonsoft.Json"; TestsName = "Newtonsoft.Json.Tests"; 	TestsFunction = "NUnitTests"; Constants=""; FinalDir="Net45"; NuGetDir = "net45"; Framework="net-4.0"; Sign=$true }
	@{ Name = "PortableExtensions.Net40.sln";    ProjectDirectory = "PortableExtensions"; ShouldBuild = $true; RestoreNuGetPackages = $true; OutputDirectory="Portable"; TestRunner = "NUnit"; TestDirectory = "PortableExtensions.Testing"; TestProjectName = "PortableExtensions.Net40.Testing" },
	@{ Name = "PortableExtensions.Portable.sln"; ProjectDirectory = "PortableExtensions"; ShouldBuild = $true; RestoreNuGetPackages = $true; OutputDirectory="Net40";    TestRunner = "NUnit"; TestDirectory = "PortableExtensions.Testing"; TestProjectName = "PortableExtensions.Portable.Testing" }
)

# Get all projects were ShouldBuild is true
function Get-Projects() {
	return $projects | where { $_.ShouldBuild }
}