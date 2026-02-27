# CursorWebAPI

A small .NET Web API project intended for practicing an “AI-assisted” workflow in Cursor:
- Claude Opus for planning/architecture
- Sonnet/Codex for implementation and iteration

## Tech
- .NET: 8 (target framework: `net8.0`)
- Language: C#
- API style: Minimal API
- Persistence: EF Core + SQLite
- Testing: xUnit (unit + integration)

## Getting Started

### Prerequisites
- .NET SDK installed (`dotnet --info`)
- (Optional) Docker Desktop if you later add containerization

### Run the API
From the repo root:

```powershell
$dotnet = "$Env:ProgramFiles\dotnet\dotnet.exe"

& $dotnet restore
& $dotnet build
& $dotnet tool restore
& $dotnet tool run dotnet-ef database update --project .\src\CursorWebAPI\CursorWebAPI.csproj --startup-project .\src\CursorWebAPI\CursorWebAPI.csproj
& $dotnet run --project .\src\CursorWebAPI\CursorWebAPI.csproj
```

### Endpoints
- `GET /health`
- `GET /this-day/grateful-dead?date=MM-dd` (or `yyyy-MM-dd`, optional; defaults to today UTC)
- Swagger UI (Development): `GET /swagger`

### Run tests

```powershell
$dotnet = "$Env:ProgramFiles\dotnet\dotnet.exe"
& $dotnet test .\CursorWebAPI.sln
```
