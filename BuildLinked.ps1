# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/p4g64.dungeonSavePoints/*" -Force -Recurse
dotnet publish "./p4g64.dungeonSavePoints.csproj" -c Release -o "$env:RELOADEDIIMODS/p4g64.dungeonSavePoints" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location