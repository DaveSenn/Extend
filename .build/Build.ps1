$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$packages = [System.IO.Path]::Combine($root, "packages")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")
$solution = [System.IO.Path]::Combine($root, "PortableExtensions.sln")

task Build {
	Write-Host "Build..."
}

task Clean {
	Write-Host "Clean..."
}

task . Build, Clean

#.\packages\Invoke-Build\tools\Invoke-Build .\.build\Build.ps1