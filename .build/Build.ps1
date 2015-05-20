$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$packages = [System.IO.Path]::Combine($env:Temp, "packages")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")
$nunit = [System.IO.Path]::Combine($root, ".tools\NUnit-2.6.4\bin\nunit-console.exe")
$solution = [System.IO.Path]::Combine($root, "PortableExtensions.sln")

task Build {
	Write-Host "Build..."
}

# Removes all not tracked files
task Clean {
	ExecInDir {
		Write-Host "Start git clean"
		git clean -xdf 
	} $root 0
}

# Restores all NuGet packages
task RestorePackages {
	exec {
		&$nuget restore $solution
	}
}

# Build the project.
task Build {
	exec { 
		MSBuild $solution /t:Build /p:Configuration=Release /verbosity:minimal
	}
}

# Run unit tests.
task Tests {
	exec { 
		&$nunit "C:\_git\PortableExtensions\PortableExtensions.Testing\bin\Release\PortableExtensions.Testing.dll"
	}
}

# Create NuGet packages
task CreatePackage {
	exec { 
		$nuspecFile = [System.IO.Path]::Combine($currentDir, "Nuget\PortableExtensions.nuspec")
		$assemblyPath = [System.Reflection.Assembly]::LoadFile([System.IO.Path]::Combine($root, "PortableExtensions\bin\Release\PortableExtensions.dll" ))
		
		$nugetPack = [System.IO.Path]::Combine($currentDir, "Nuget\pack.ps1")	
		&$nugetPack $assemblyPath $nuspecFile $nuget
	}
}

function ExecInDir([Parameter(Mandatory=$true)][scriptblock]$Command, [Parameter(Mandatory=$true)][string]$Path,  [int[]]$ExitCode=0) {
	$private:location = Get-Location
	Set-Location $Path
	
	Write-Host "(Run in $private:location)"
	exec $Command $ExitCode
	
	Set-Location $private:location
}

task . Clean, RestorePackages, Build, Tests, CreatePackage

<#

&([System.IO.Path]::Combine($env:Temp, "packages\Invoke-Build\tools\Invoke-Build.ps1")) -File .\.build\Build.ps1

&"C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe"

#>