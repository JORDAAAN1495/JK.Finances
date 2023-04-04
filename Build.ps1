$Host.Ui.RawUI.WindowTitle = $MyInvocation.MyCommand

$SonarHost = [System.Environment]::GetEnvironmentVariable("SonarHost")
$SonarLogin = [System.Environment]::GetEnvironmentVariable("JK.Finances.SonarLogin")
$SonarProjectId = [System.Environment]::GetEnvironmentVariable("JK.Finances.SonarProjectId")
$CoverageReport = [System.Environment]::GetEnvironmentVariable("JK.Finances.CoverageReport")

dotnet tool install --global dotnet-sonarscanner

dotnet sonarscanner begin /k:$SonarProjectId /d:sonar.host.url=$SonarHost /d:sonar.login=$SonarLogin /d:sonar.cs.vscoveragexml.reportsPaths=$CoverageReport

dotnet build --no-incremental

dotnet-coverage collect "dotnet test" -f xml  -o $CoverageReport

dotnet sonarscanner end /d:sonar.login=$SonarLogin

pause