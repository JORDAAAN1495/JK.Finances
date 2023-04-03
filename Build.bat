@echo off

set login="sqp_8f9c66dbd692d17c153751b5a29eaab46a79b1f6"
set coveragePath="C:\sonarqube\coverage\jk.finances.coverage.xml"

dotnet tool install --global dotnet-sonarscanner

dotnet sonarscanner begin /k:"JORDAAAN1495_JK.Finances_AYdIDXXdO-NOVkGW90JI" /d:sonar.host.url="http://localhost:9000" /d:sonar.login=%login% /d:sonar.cs.vscoveragexml.reportsPaths=%coveragePath%

dotnet build --no-incremental

dotnet-coverage collect "dotnet test" -f xml  -o %coveragePath%

dotnet sonarscanner end /d:sonar.login=%login%

pause