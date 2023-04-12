dotnet test .\src\FluentRegularExpression.Tests\ /p:AltCover=true,AltCoverTypeFilter="EmbeddedAttribute|Nullable|",AltCoverAssemblyExcludeFilter="xunit|AltCover|Tests"

dotnet reportgenerator "-reports:.\src\FluentRegularExpression.Tests\coverage.xml" "-targetdir:.\Reports" 