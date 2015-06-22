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

# Uploads the given ZIP file to Coverity
function UploadCoverityScanResult([string]$token, [string]$email, [string]$message, [string]$version, [string]$zipPath, [string]$url) {
    # Create form
    Add-Type -AssemblyName "System.Net.Http"
    $client = New-Object Net.Http.HttpClient
    $client.Timeout = [TimeSpan]::FromMinutes(15)
    $form = New-Object Net.Http.MultipartFormDataContent
    
    # Token
    $formField = New-Object Net.Http.StringContent($token)
    $form.Add($formField, '"token"')
    # Email
    $formField = New-Object Net.Http.StringContent($email)
    $form.Add($formField, '"email"')
    # Version
    $formField = New-Object Net.Http.StringContent($version)
    $form.Add($formField, '"version"')
    # Description
    $formField = New-Object Net.Http.StringContent($message)
    $form.Add($formField, '"description"')
    # Zip
    $fs = New-Object IO.FileStream( $zipPath, [IO.FileMode]::Open, [IO.FileAccess]::Read)
    $formField = New-Object Net.Http.StreamContent($fs)
    $form.Add($formField, '"file"', (Get-ChildItem $zipPath).Name)
    
    # Submit form.
    $task = $client.PostAsync($url, $form)
    
    try {
      $task.Wait()
    } catch [AggregateException] {
      throw $_.Exception.InnerException
    }
    Write-Host "Upload finished. Status code: " $task.Result.StatusCode
    $fs.Close()
}