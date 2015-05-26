# Load needed assemblies
Add-Type -AssemblyName System
Add-Type -AssemblyName System.Reflection

# Executes the given script block in the given directory
function ExecInDir {
    [CmdletBinding()]
    param(
        [Parameter(Position=0, Mandatory=$true)][string]$workinDir,
        [Parameter(Position=1, Mandatory=$true)][scriptblock]$cmd
    )
    # Change location
    $private:location = Get-Location
    Set-Location $workinDir
    
    # Run script block
    Write-Host "(Run in $workinDir)"
    & $cmd
    
    # Change location back
    Set-Location $private:location
}

# Gets the version of the given assembly
function GetVersion([string] $dllPath) {
    $version = $env:appveyor_build_version;
    if($version) {
        return $version;
    }
    
    # Load built assembly
    $assembly = [System.Reflection.Assembly]::LoadFile($dllPath)
    # Get assembly version
    $version = $assembly.GetName().Version;
    Try {
        $version = New-Object System.Version($version)
        return New-Object System.Version($version.Major, $version.Minor, $version.Build, ($version.Revision + 1))
    }
    Catch [System.Exception] {
        Write-Host  $_.Exception.Message
        return $version
    }
}