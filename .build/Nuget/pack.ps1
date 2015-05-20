# Script parameters
param(
	[Parameter(Mandatory=$true)][string]$dllPath,
	[Parameter(Mandatory=$true)][string]$nuspecPath,
	[Parameter(Mandatory=$true)][string]$nugetPath,
	[Parameter(Mandatory=$true)][string]$outputPath
)

Write-Host "dllPath: $dllPath"
Write-Host "nuspecPath: $nuspecPath"
Write-Host "nugetPath: $nugetPath"
Write-Host "outputPath: $outputPath"

# Load needed assemblies
Add-Type -AssemblyName System
Add-Type -AssemblyName System.Reflection

# Load the built assembly
$assembly = [System.Reflection.Assembly]::LoadFile($dllPath)
# Get assembly name and version
$name = $assembly.GetName().Name;
$version = $assembly.GetName().Version;

# Get assembly description
$type = [System.Reflection.AssemblyDescriptionAttribute]
$attribute = [System.Reflection.AssemblyDescriptionAttribute]::GetCustomAttribute($assembly, $type);
$description = $attribute.Description

# Get assembly copyright
$type = [System.Reflection.AssemblyCopyrightAttribute]
$attribute = [System.Reflection.AssemblyCopyrightAttribute]::GetCustomAttribute($assembly, $type);
$copyright = $attribute.Copyright

Write-Host "Name: $name"
Write-Host "Version: $version"
Write-Host "Description: $description"
Write-Host "Copyright: $copyright"

# Create output directory
if(!(Test-Path -Path $outputPath )){
	New-Item -ItemType directory -Path $outputPath
}

# Build the package
&$nugetPath pack $nuspecPath -Properties "id=$name;version=$version;description=$description;copyright=$copyright;" -OutputDirectory $outputPath