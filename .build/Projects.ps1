<#
Script containing all project-build configuration.
#>
$projects = @(
	@{ Name = "Extend.Net40.sln";    ProjectDirectory = "Extend"; ShouldBuild = $true; RestoreNuGetPackages = $true; OutputDirectory="Portable"; TestRunner = "NUnit"; TestDirectory = "Extend.Testing"; TestProjectName = "Extend.Net40.Testing" },
	@{ Name = "Extend.Portable.sln"; ProjectDirectory = "Extend"; ShouldBuild = $true; RestoreNuGetPackages = $true; OutputDirectory="Net40";    TestRunner = "NUnit"; TestDirectory = "Extend.Testing"; TestProjectName = "Extend.Portable.Testing" }
)

# Get all projects were ShouldBuild is true
function Get-Projects() {
	return $projects | where { $_.ShouldBuild }
}