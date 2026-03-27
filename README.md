# Ayora

Production-ready modular ASP.NET Core 10 Web API foundation using **Dapper + SQL Server**.

## Structure

- `api/`: Visual Studio solution and all .NET projects (Clean Architecture)
- `sql/`: SQL Server schema (`main.sql`) and incremental changes (`alter/`)
- `json/`: Test request payloads matching the latest DTOs

## Key rules (always keep in sync)

- If you change DTOs, **update `json/*.json`** accordingly.
- If you change the schema, **update `sql/main.sql`** (full current schema) and add an incremental script under `sql/alter/` when appropriate.
- If you change solution/module structure or contracts, **update these READMEs** (root, `api/`, `sql/`, `json/`).

## Build

```bash
dotnet build api/Ayora.sln -c Release
```

