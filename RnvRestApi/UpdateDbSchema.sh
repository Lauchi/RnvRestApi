#!/usr/bin/env bash
rm -f RnvRestApi/rnvScotlandYard.db
cd SqliteAdapter/
dotnet ef migrations remove -s ../RnVRestApi/
dotnet ef migrations add InitialMigration -s ../RnVRestApi/
dotnet ef database update -s ../RnVRestApi/