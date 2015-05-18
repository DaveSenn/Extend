$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")
$packages = [System.IO.Path]::Combine($root, "packages")
$nuget = [System.IO.Path]::Combine($root, ".tools\NuGet\nuget.exe")
$solution = [System.IO.Path]::Combine($root, "PortableExtensions.sln")
<#
properties {
    # build variables
    $framework = "4.5.1"		# .net framework version
    $configuration = "Release"	# build configuration
    $script:version = "1.0.0"
    $script:nugetVersion = "1.0.0"
    $script:runCoverity = $false

    # directories
    $base_dir = . resolve-path .\
    $build_output_dir = "$base_dir\src\csmacnz.CoverityPublisher\bin\$configuration\"
    $test_results_dir = "$base_dir\TestResults\"
    $package_dir = "$base_dir\Package\"
    $archive_dir = "$package_dir" + "Archive"
    $nuget_pack_dir = "$package_dir" + "Pack"

    # files
    $sln_file = "$base_dir\src\csmacnz.CoverityPublisher.sln"
    $nuspec_filename = "PublishCoverity.nuspec"
    $applicationName = "PublishCoverity"
}
#>

Task default -Depends RestorePackages

# Cleans the repository
Task Clean {
	Write-Host "Restoring NuGet packages"
	Write-Host (Get-Location)
    
	exec { 
		Set-Location $root
		git clean -xdf }
	Start-Process git -Argumentlist "clean -xdf" -WorkingDirectory $root
	
	Write-Host (Get-Location)
}

# Task restoring the NuGet packages of the solution
Task RestorePackages {
	Write-Host "Restoring NuGet packages"
    exec { &$nuget restore $solution }
}

Task Test {
    Write-Host "Hi"
}
