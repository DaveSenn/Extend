$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$packages = [System.IO.Path]::Combine($env:Temp, "packages")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")

$solution = [System.IO.Path]::Combine($root, "PortableExtensions.sln")

task Build {
	Write-Host "Build..."
}

task Clean {
	ExecInDir {
		Write-Host "Start git clean"
		git clean -xdf 
	} $root 0
}

function ExecInDir([Parameter(Mandatory=$true)][scriptblock]$Command, [Parameter(Mandatory=$true)][string]$Path,  [int[]]$ExitCode=0) {
	$private:location = Get-Location
	Set-Location $Path
	
	Write-Host "(Run in $private:location)"
	exec $Command $ExitCode
	
	Set-Location $private:location
}

task . Build, Clean

#.\packages\Invoke-Build\tools\Invoke-Build -File .\.build\Build.ps1