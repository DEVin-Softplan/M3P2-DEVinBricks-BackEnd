$ErrorActionPreference = 'SilentlyContinue'
try {dotnet tool install -g dotnet-reportgenerator-globaltool -ErrorAction}
finally {
dotnet test --collect:"XPlat Code Coverage"
cd .\TestResults
cd (gci * | sort LastWriteTime |select -last 1).Name
$ReportName = "-reports:coverage.cobertura.xml"
$TargetDir = "-targetdir:TestCoverageReport"
$ClassFilters = "-classfilters:-DEVinBricks.Migrations.*;-DEVinBricks.Repositories.Models.*;-DEVinBricks.Seeds.*;-DEVinBricks.Settings;-DEVinBricks.Controllers.Validacoes.*;-Program"
reportgenerator $ReportName $TargetDir $ClassFilters
TestCoverageReport/index.html
cd ../..
}