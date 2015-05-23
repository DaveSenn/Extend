<#
Main build script
#>
properties { 
    $srcDir = "$root\.Src\"
    $nuget = "$root\.Tools\NuGet\nuget.exe"
    $nunit = "$root\.Tools\NUnit\nunit-console.exe"
    $git = "git"
    $msBuild = "MSBuild"
    $buildConfiguration = "Release"
    $msBuildTargets = "Clean;Rebuild"
    $msBuildVerbosity = "minimal"
    $treatWarningsAsErrors = $true
    $binDir = "bin"
    $outputDirectory = "$root\Output"
    $nugetPackDirectory = "$outputDirectory\NuGet"
}
$root = Resolve-Path ..

# Load additional scripts
."$root\.Build\Projects.ps1"
."$root\.Build\BuildHelpers.ps1"

# Get projects to build
$allProjects = Get-Projects

# Default task
Task default -Depends Clean, RestorePackages, Build, CopyBuildOutput, Test

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

# Build all projects
task Build {
    Write-Host "Build projects" -fore Magenta

    # For each project
    foreach($project in $allProjects) {
        $projectPath = [System.IO.Path]::Combine($srcDir, $project.Name)
        $outDir = $project.OutputDirectory
        exec {
            &$msBuild $projectPath "/t:$msBuildTargets" "/p:Configuration=$buildConfiguration" "/p:Platform=Any CPU" "/verbosity:$msBuildVerbosity" "/p:TreatWarningsAsErrors=$treatWarningsAsErrors" "/p:OutputPath=$binDir\$buildConfiguration\$outDir\"
        } "Failed to build: '$projectPath'"
    }
}

# Run all unit tests
task CopyBuildOutput {
    Write-Host "Copy build output" -fore Magenta

    # Create output directory if not exists
    if(!(Test-Path -Path $outputDirectory )) {
        New-Item -ItemType directory -Path $outputDirectory | Out-Null
    }

    # Copy each build output to the output directory
    foreach($project in $allProjects) {
        $buildOutput = [System.IO.Path]::Combine($srcDir, $project.ProjectDirectory, $binDir, $buildConfiguration, $project.OutputDirectory)
        
        # Get the files top copy
        Get-ChildItem -Path $buildOutput  -Recurse -Include @("*.xml", "*.dll") | Foreach ($_) { 
            $destination = [System.IO.Path]::Combine($nugetPackDirectory, "lib", $project.NuGetDir)
            # Create output directory (NuGet dir) if not exists
            if(!(Test-Path -Path $destination )) {
                New-Item -ItemType directory -Path $destination | Out-Null
            }
            # Copy the file
            Copy-Item $_.FullName -Destination "$destination"
        }
    }

    Get-Childitem $outputDirectory -Include *.pdb -Recurse | Foreach ($_) { Remove-Item $_.fullname }
}

# Run all unit tests
task Test {
    Write-Host "Run unit tests" -fore Magenta
    
    # For each project
    foreach($project in $allProjects | where { $_.TestRunner -ne $null } ) {

        $buildOutput = [System.IO.Path]::Combine($srcDir, $project.TestDirectory, $binDir, $buildConfiguration, $project.OutputDirectory, $project.TestProjectName) + ".dll"
        Write-Host $buildOutput
        
        switch ($project.TestRunner) { 
            "NUnit" { RunNUnitTest $project $buildOutput } 
            default { throw "Test-runner '{0}' is not supported" -f $project.TestRunner }
        }
    }
}

# Create all NuGet packages
task NuGetPack {
    Write-Host "Create NuGet packages" -fore Magenta
    
    # Copy NuGet spec file to NuGet directory
    $nuspec = [System.IO.Path]::Combine($root, ".Build", "NuGet") + "\Extend.nuspec"
    Copy-Item $nuspec -Destination $nugetPackDirectory

    &$nuget pack "$nugetPackDirectory\Extend.nuspec" -Properties "id=Test;version=1.1.1.1;description=desc;copyright=DAveSenn;" -OutputDirectory $nugetPackDirectory
}

<#

task CreatePackage {
    exec { 
        $nuspecFile = [System.IO.Path]::Combine($currentDir, "Nuget\PortableExtensions.nuspec")
        $assemblyPath = [System.IO.Path]::Combine($root, "PortableExtensions\bin\Release\PortableExtensions.dll" )
        $nugetOutput = [System.IO.Path]::Combine($outputDirectory, "Nuget\")
        
        $nugetPack = [System.IO.Path]::Combine($currentDir, "Nuget\pack.ps1")	
        &$nugetPack $assemblyPath $nuspecFile $nuget $nugetOutput
    }
}

#>

# Run NUnit tests for the given project
function RunNUnitTest($project, $testDll) {
    Write-Host "Run NUnit tests: '$testDll'"
    exec { 
        &$nunit $testDll | Out-Null 
    } "Running NUnit tests '$testDll' failed"

}