# Load needed assemblies
Add-Type -AssemblyName System
Add-Type -AssemblyName System.Reflection

# Get path to repository root
$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
Write-Host "Root is set to: $root"

# Load the built assembly
$assembly = [System.Reflection.Assembly]::LoadFile("$root\PortableExtensions\bin\Release\PortableExtensions.dll")
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

# Build the package
& $root\Nuget\Nuget.exe pack $root\Nuget\PortableExtensions.nuspec -Properties "id=$name;version=$version;description=$description;copyright=$copyright;"