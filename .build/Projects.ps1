<#
Script containing all project-build configuration.
#>
$projects = @(
	#@{  Name = "Newtonsoft.Json"; TestsName = "Newtonsoft.Json.Tests"; 	TestsFunction = "NUnitTests"; Constants=""; FinalDir="Net45"; NuGetDir = "net45"; Framework="net-4.0"; Sign=$true }
	@{ Name = "PortableExtensions.Net40.sln";    ShouldBuild = $true; },
	@{ Name = "PortableExtensions.Portable.sln"; ShouldBuild = $true; }
)

# Get all projects were ShouldBuild is true
function Get-Projects(){
	return $projects | where { $_.ShouldBuild }
}