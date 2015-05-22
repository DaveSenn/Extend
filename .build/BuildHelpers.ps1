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