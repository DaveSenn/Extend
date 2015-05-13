$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\PortableExtensions\bin\Release\PortableExtensions.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\Nuget\PortableExtensions.nuspec) 
$content = $content -replace '\$version\$',$versionStr
$content | Out-File $root\Nuget\PortableExtensions.compiled.nuspec

& $root\Nuget\Nuget.exe pack $root\Nuget\PortableExtensions.compiled.nuspec