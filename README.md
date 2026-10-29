# LAB5 MSSQL

A Windows Forms inventory application backed by Microsoft SQL Server. It supports product and category management, stock adjustments, sales, product search, and sales history.

## Requirements

- Windows with the .NET 10 x64 SDK/runtime
- x64 SQL Server LocalDB (installed with Visual Studio) or a reachable x64 SQL Server instance

## Configure the database

The default connection in `App.config` uses LocalDB and Windows authentication. Change the `MagazinDB` connection string for SQL Server Express or another instance. Alternatively, set the `LAB5_MSSQL_CONNECTION_STRING` environment variable; it overrides the config value.

Example for SQL Server Express:

```text
Server=localhost\SQLEXPRESS;Database=MagazinDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True
```

The application creates the `MagazinDB` database and its tables on first run with EF Core `EnsureCreated`. `CreateDatabase.sql` is also provided for administrators who want to provision the database manually. Do not use EF migrations with this project; the schema is initialized from the current model.

## Build and run

```powershell
dotnet restore .\LAB5_MSSQL\LAB5_MSSQL.csproj
dotnet build .\LAB5_MSSQL\LAB5_MSSQL.csproj
dotnet run --project .\LAB5_MSSQL\LAB5_MSSQL.csproj
```

