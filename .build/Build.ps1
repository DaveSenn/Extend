<#
Main build script
#>
properties { 
    $srcDir = "$root\.Src\"
    $nuget = "$root\.Tools\NuGet\nuget.exe"
    $git = "git"
}
$root = Resolve-Path ..

# Load additional scripts
."$root\.Build\Projects.ps1"
."$root\.Build\BuildHelpers.ps1"

# Get projects to build
$allProjects = Get-Projects

# Cleans the output directory
Task Clean {
    Write-Host "Clean repository" -fore Magenta
    
    ExecInDir $root {
        exec { &$git clean -xdf  } "Git clean failed"
    }
}

# Restores all NuGet packages
Task RestorePackages {
	Write-Host "Restore NuGet packages" -fore Magenta

	# For each project with enabled NuGet restore
    foreach($project in $allProjects | where { $_.RestoreNuGetPackages } ) {
		$projectPath = [System.IO.Path]::Combine($srcDir, $project.Name)
		exec {
			&$nuget restore $projectPath
		} "NuGet restore failed for: '$projectPath'"
    }
}