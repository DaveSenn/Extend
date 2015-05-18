$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$packages = [System.IO.Path]::Combine($root, "packages")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")

# Install FAKE (F# build tool) using NuGet
& $nuget "Install" "psake" "-OutputDirectory" $packages "-ExcludeVersion"

# Check if installation was successfully
$psake = [System.IO.Path]::Combine($packages, "psake\tools\psake.psm1")
If (Test-Path $psake)
{
	Write-Host "psake successfully installed: '$psake'"
}
Else
{
	Write-Host "Failed to install psake"
	Write-Host "Current directory: $currentDir"
	Write-Host "Root directory: $root"
	Write-Host "Package directory: $packages"
	Write-Host "NuGet: $nuget"
}