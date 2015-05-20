$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$packages = [System.IO.Path]::Combine($root, "packages")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")
$solution = [System.IO.Path]::Combine($root, "PortableExtensions.sln")

task Build {
	Write-Host "Build..."
}

task Clean {
	ExecInDir {
		git clean -xdf 
	} $root
}

function ExecInDir([Parameter(Mandatory=$true)][scriptblock]$Command, [Parameter(Mandatory=$true)][string]$Path, [int[]]$ExitCode=0) {
	$location = Get-Location
	Set-Location $Path
	
	exec $Command $Path $ExitCode
	
	Set-Location $location
}

task . Build, Clean

#.\packages\Invoke-Build\tools\Invoke-Build -File .\.build\Build.ps1