Remove-Item -Force RnvRestApi/rnvScotlandYard.db
cd SqliteAdapter/
dotnet ef migrations remove -s ../RnVRestApi/
dotnet ef migrations add InitialMigration -s ../RnVRestApi/
dotnet ef database update -s ../RnVRestApi/
cd ..