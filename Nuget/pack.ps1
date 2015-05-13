$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
Write-Host "APPVEYOR_BUILD_VERSION: $env:APPVEYOR_BUILD_VERSION"

#$version = [System.Reflection.Assembly]::LoadFile("$root\PortableExtensions\bin\Release\PortableExtensions.dll").GetName().Version
#$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)
#Write-Host "Setting .nuspec version tag to $versionStr"

#$content = (Get-Content $root\Nuget\PortableExtensions.nuspec) 
#$content = $content -replace '\$version\$',$versionStr
#$content | Out-File $root\Nuget\PortableExtensions.compiled.nuspec

#& $root\Nuget\Nuget.exe pack $root\Nuget\PortableExtensions.compiled.nuspec
& $root\Nuget\Nuget.exe pack $root\Nuget\PortableExtensions.nuspec -Properties version=$env:APPVEYOR_BUILD_VERSION



Add-Type -AssemblyName System
Add-Type -AssemblyName System.Reflection

$assembly = [System.Reflection.Assembly]::LoadFile("$root\PortableExtensions\bin\Release\PortableExtensions.dll")
$name = $assembly.GetName().Name;
$version = $assembly.GetName().Version;

$type = [System.Reflection.AssemblyDescriptionAttribute]
$attribute = [System.Reflection.AssemblyDescriptionAttribute]::GetCustomAttribute($assembly, $type);
$description = $attribute.Description

$type = [System.Reflection.AssemblyCopyrightAttribute]
$attribute = [System.Reflection.AssemblyCopyrightAttribute]::GetCustomAttribute($assembly, $type);
$copyright = $attribute.Copyright

Write-Host $name
Write-Host $version
Write-Host $description
Write-Host $copyright