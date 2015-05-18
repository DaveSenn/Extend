$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$packages = [System.IO.Path]::Combine($root, "packages")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")

# Install FAKE (F# build tool) using NuGet
& $nuget "Install" "FAKE" "-OutputDirectory" $packages "-ExcludeVersion"

# Check if installation was successfully
$fake = [System.IO.Path]::Combine($packages, "FAKE\tools\Fake.exe")
If (Test-Path $fake)
{
	Write-Host "FAKE successfully installed: '$fake'"
}
Else
{
	Write-Host "Failed to install FAKE"
	Write-Host "Current directory: $currentDir"
	Write-Host "Root directory: $root"
	Write-Host "Package directory: $packages"
	Write-Host "NuGet: $nuget"
}