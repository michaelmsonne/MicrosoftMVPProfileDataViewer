param (
    [string]$OutputFolderPath
)

# Remove any double quotes from the provided $OutputFolderPath parameter
$OutputFolderPath = $OutputFolderPath -replace '"', ''

# Folder for old builds
$FolderName = Join-Path -Path $OutputFolderPath -ChildPath "Old"
if (Test-Path -Path $FolderName -PathType Container) {   
    Write-Host "Old folder for Debug builds exists"
    Get-ChildItem -Path "$OutputFolderPath\*Microsoft MVP Profile Data Viewer*Debug Build at*.exe" -Recurse | Move-Item -Destination $FolderName
    Write-Host "Moved files $OutputFolderPath\*Microsoft MVP Profile Data Viewer*Debug Build at*.exe to $FolderName"
} else {
    Write-Host "Old folder for Debug builds doesn't exist - Creating it..."
    # PowerShell Create directory if not exists
    New-Item -Path $FolderName -ItemType Directory
    Write-Host "Old folder for Debug builds doesn't exist - Created..."
}

# Delete old .exe files that are not needed anymore (2 seconds old or more)
Get-ChildItem -Path "$OutputFolderPath\*Microsoft MVP Profile Data Viewer*Debug Build at*" -File | Where-Object CreationTime -lt (Get-Date).AddSeconds(-2) | Remove-Item -Force

# Get the file version for the last build of Microsoft MVP Profile Data Viewer.exe
$FileVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$OutputFolderPath\Microsoft MVP Profile Data Viewer.exe").FileVersion

# Rename the file to include version and build time (keep original)
Get-ChildItem -Path "$OutputFolderPath\Microsoft MVP Profile Data Viewer.exe" | Where-Object {!$_.PSIsContainer -and $_.Extension -eq '.exe'} | ForEach-Object {
    $NewFileName = "{0} v. {1} - Debug Build at {2}{3}" -f $_.BaseName, $FileVersion, (Get-Date -Format "ddMMyyyy-HHmmss"), $_.Extension
    $NewFilePath = Join-Path -Path $OutputFolderPath -ChildPath $NewFileName
    Copy-Item -Path $_.FullName -Destination $NewFilePath -Force
    Write-Host "Copied" $_.FullName "to $NewFilePath"
}