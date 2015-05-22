properties { 
  $workingName = if ($workingName) {$workingName} else {"Working"}
  $baseDir  = resolve-path ..
  $buildDir = "$baseDir\Build"
  $sourceDir = "$baseDir\Src"
  $toolsDir = "$baseDir\Tools"
}

<#
Main build script
#>

# Get some paths
$currentDir = split-path -parent $MyInvocation.MyCommand.Definition
$root = [System.IO.Path]::Combine($currentDir, "..\")

# Load projects file
."$root\.Build\Projects.ps1"
# Get projects to build
$allProjects = Get-Projects

# Cleans the output directory
task Clean {

	Write-Host "Clean...";
    <#
  Write-Host "Setting location to $baseDir"
  Set-Location $baseDir
  
  if (Test-Path -path $workingDir)
  {
    Write-Host "Deleting existing working directory $workingDir"
    
    del $workingDir -Recurse -Force
  }
  
  Write-Host "Creating working directory $workingDir"
  New-Item -Path $workingDir -ItemType Directory
    #>
}

task Clean2 {
	Write-Host "Clean2...";
}