@echo off
cls

echo Creating the module zip file..
powershell -command "Compress-Archive -Path .\Views\, .\module.config -DestinationPath .\Modules\_protected\MigrationManager\MigrationManager -CompressionLevel Optimal -Force"
echo.

echo Creating NuGet package..
echo.
nuget pack MigrationManager.Episerver.csproj -Build -Properties Configuration=Release -Verbosity detailed

echo.
echo.
echo So Long, and Thanks for All the Fish
