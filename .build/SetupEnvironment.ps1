Write-Host "Setup Environment started"

$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")
$packages = [System.IO.Path]::Combine($env:Temp, "packages")

# Install Invoke-Build (PowerShell build tool) using NuGet
&$nuget "Install" "Invoke-Build" "-OutputDirectory" $packages "-ExcludeVersion"

# Check if installation was successfully
$invokeBuild = [System.IO.Path]::Combine($packages, "Invoke-Build\tools\Invoke-Build.ps1")
If (Test-Path $invokeBuild)
{
	Write-Host "Invoke-Build successfully installed: '$invokeBuild'"
}
Else
{
	Write-Host "Failed to install invokeBuild"
	Write-Host "Current directory: $currentDir"
	Write-Host "Root directory: $root"
	Write-Host "Package directory: $packages"
	Write-Host "NuGet: $nuget"
}