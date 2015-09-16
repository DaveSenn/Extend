<#
Main build script
#>
properties { 
    $srcDir = "$root\.Src\"
    $toolsDir = "$root\.Tools\"
    $nuget = "$toolsDir\NuGet\nuget.exe"
    $nunit = "$toolsDir\NUnit\nunit-console.exe"
    $7zip = "$toolsDir\7zip\7za.exe"
    $curl = "$toolsDir\Curl\curl.exe"
    $git = "git"
    $msBuild = "MSBuild"
    $buildConfiguration = "Release"
    $msBuildTargets = "Clean;Rebuild"
    $msBuildVerbosity = "minimal"
    $treatWarningsAsErrors = $true
    $binDir = "bin"
    $outputDirectory = "$root\Output"
    $nugetPackDirectory = "$outputDirectory\NuGet"
    $coverityBuildTool = "cov-build"
    $coverityDir = "$outputDirectory\cov-int"
    $coveritySolution = "$root\.Src\Extend.sln"
}
$root = Resolve-Path ..

# Load additional scripts
."$root\.Build\Projects.ps1"
."$root\.Build\BuildHelpers.ps1"

# Get projects to build
$allProjects = Get-Projects

# Default task
Task default -Depends Clean, RestorePackages, Build, Test, CopyBuildOutput, NuGetPack

# CI task
#Task CI -Depends RestorePackages, Build, CopyBuildOutput, NuGetPack, CoverityScan, CoverityUpload
Task CI -Depends RestorePackages, Build, CopyBuildOutput, NuGetPack

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
Task Build {
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
Task CopyBuildOutput {
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

            foreach($nugetDir in  $project.NuGetDir) {
                $destination = [System.IO.Path]::Combine($nugetPackDirectory, "lib", $nugetDir)
                # Create output directory (NuGet dir) if not exists
                if(!(Test-Path -Path $destination )) {
                    New-Item -ItemType directory -Path $destination | Out-Null
                }
                # Copy the file
                Copy-Item $_.FullName -Destination "$destination"
            }
        }
    }

    Get-Childitem $outputDirectory -Include *.pdb -Recurse | Foreach ($_) { Remove-Item $_.fullname }
}

# Run all unit tests
Task Test {
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
Task NuGetPack {
    Write-Host "Create NuGet packages" -fore Magenta
    
    # Copy NuGet spec file to NuGet directory
    $nuspec = [System.IO.Path]::Combine($root, ".Build", "NuGet") + "\Extend.nuspec"
    Copy-Item $nuspec -Destination $nugetPackDirectory

    # Get package version
    $version = GetVersionSecure

    &$nuget pack "$nugetPackDirectory\Extend.nuspec" -Properties "version=$version;" -OutputDirectory $nugetPackDirectory
}

# Run Coverity scan
Task CoverityScan {
    Write-Host "Run Coverity scan" -fore Magenta

    &$coverityBuildTool --dir $coverityDir "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" $coveritySolution "/t:Clean,Build" "/p:Configuration=Release" | Out-Null

    Write-Host "Create zip from coverity result"
    $zipPath =[System.IO.Path]::Combine($outputDirectory) + "\cov-int.zip"
    $coverityOutDir = $coverityDir
    &$7zip a $zipPath $coverityOutDir | Out-Null 
}

# Upload the Coverity scan results
Task CoverityUpload {
    Write-Host "Upload Coverity scan result" -fore Magenta
    
    # Get needed values
    $version = GetVersionSecure
    $zipPath =[System.IO.Path]::Combine($outputDirectory) + "\cov-int.zip"
    $token = $env:coverity_token
    $email = $env:email
    $message = $env:APPVEYOR_REPO_COMMIT_MESSAGE
    
    # Upload the Coverity result
    UploadCoverityScanResult $token $email $message $version $zipPath "https://scan.coverity.com/builds?project=DaveSenn%2FExtend"
}

# Run NUnit tests for the given project
function RunNUnitTest($project, $testDll) {
    Write-Host "Run NUnit tests: '$testDll'"
    exec { 
        &$nunit $testDll | Out-Null 
    } "Running NUnit tests '$testDll' failed"
}

# Gets the version of the built DLL
function GetVersionSecure(){
    # Get version
    $dllPath = [System.IO.Path]::Combine($nugetPackDirectory, "lib", $allProjects[0].NuGetDir[0]) + "\Extend.dll"
    return GetVersion $dllPath
}