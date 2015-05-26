param(
    [hashtable] $parameters = @{},
    [hashtable] $properties = @{}
)

$currentDirectory = Split-Path -Path $MyInvocation.MyCommand.Path
$psakePath = [System.IO.Path]::Combine($currentDirectory, "..\", ".Tools\PSake\psake.psm1")

Import-Module ($psakePath)
Try
{
    Invoke-Psake ($currentDirectory + '\Build.ps1') -properties $properties -parameters $parameters

    if ($psake.build_success -eq $false)
    {
        Write-Host "Build failed" -fore Red
        exit 1
    }
    else
    {
        Write-Host "Build succeeded" -fore Green
        exit 0
    }
}
Finally
{
    Remove-Module psake
}