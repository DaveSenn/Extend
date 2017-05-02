[CmdletBinding()]
Param(
    [string]$Script = "build.cake",
	
    [string]$Target = "Default",
    
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",

    [ValidateSet("Quiet", "Minimal", "Normal", "Verbose", "Diagnostic")]
    [string]$Verbosity = "Verbose",
	
    # [switch]$Experimental,
    # [Alias("DryRun","Noop")]
    # [switch]$WhatIf,
    # [switch]$Mono,
    # [switch]$SkipToolPackageRestore,
    [Parameter(Position=0, Mandatory=$false, ValueFromRemainingArguments=$true)]
    [string[]]$ScriptArgs
)

# Get path of script
if(!$PSScriptRoot){
    $PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
}

# Get the full path to the script file
$Script = [System.IO.Path]::Combine($PSScriptRoot, $Script)

# Get the path to the cake executable
$CAKE_EXE = [System.IO.Path]::Combine($PSScriptRoot, "..\", ".Tools\Cake\Cake.exe")
# Store the path to the NuGet executable
$ENV:NUGET_EXE = "C:\Tools\NuGet\nuget.exe"

# Invoke-Expression "& `"$CAKE_EXE`" `"$Script`" -target=`"$Target`" -configuration=`"$Configuration`" -verbosity=`"$Verbosity`" $UseMono $UseDryRun $UseExperimental $ScriptArgs"
Invoke-Expression "& `"$CAKE_EXE`" `"$Script`" -target=`"$Target`" -configuration=`"$Configuration`" -verbosity=`"$Verbosity`""
exit $LASTEXITCODE