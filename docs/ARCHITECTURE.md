# Architecture — CursorWebAPI

## Purpose
CursorWebAPI is a small, intentionally simple .NET Web API repository used to practice a repeatable workflow:
- Strong boundaries and structure
- Incremental commits
- Testable design
- Clear operational basics (health checks, logging, config)

The repository now includes an initial .NET 8 Minimal API implementation plus unit/integration tests.

## Goals
- Provide a clean baseline Web API skeleton that can grow
- Keep architecture understandable for humans and AI agents
- Maintain a “green build” (`dotnet test`) once tests exist

## Non-Goals (for now)
- Complex distributed system concerns (service mesh, event streaming, etc.)
- Heavy enterprise patterns unless justified by requirements
- Premature abstractions

## High-Level Components (target architecture)

### 1) API Layer (HTTP)
Responsibility:
- Define endpoints/routes
- Validate inputs (lightweight)
- Translate requests into application commands/queries
- Return well-formed responses and proper status codes

Guidelines:
- Prefer thin endpoints/controllers.
- Business logic should not live directly in endpoint handlers.

### 2) Application Layer (Use Cases)
Responsibility:
- Implement business use cases (commands/queries)
- Orchestrate domain logic and persistence
- Enforce application-level rules

Patterns (choose as needed):
- Simple services (e.g., `FooService`)
- MediatR-style handlers (optional)
- Request/response DTOs

### 3) Domain Layer (Business Rules)
Responsibility:
- Core domain types and invariants
- Pure logic where possible

Guidelines:
- Keep domain types free of framework dependencies
- Favor immutability for domain entities/value objects when reasonable

### 4) Infrastructure Layer (Persistence/External Services)
Responsibility:
- Data access (EF Core/Dapper/etc.)
- External integrations (HTTP clients, queues, etc.)
- Hosting concerns, configuration, logging sinks

Guidelines:
- Hide implementation behind interfaces when it improves testability
- Prefer `HttpClientFactory` for outbound HTTP

## Suggested Project Layout (when you add code)
If you’re using a multi-project solution:

```text
src/
  CursorWebAPI.Api/            # HTTP entrypoint
  CursorWebAPI.Application/    # use cases
  CursorWebAPI.Domain/         # domain model
  CursorWebAPI.Infrastructure/ # data/integrations
tests/
  CursorWebAPI.UnitTests/
  CursorWebAPI.IntegrationTests/
```

If you start with a single project, keep folders that map to these concerns:
- `Api/`
- `Application/`
- `Domain/`
- `Infrastructure/`

## Cross-Cutting Concerns

### Configuration
- Use `appsettings.json` + environment overrides
- Bind options with `IOptions<T>`
- Validate options at startup when possible

### Logging
- Use structured logging
- Avoid logging secrets/PII
- Prefer meaningful event names/ids

### Health Checks
- `/health` endpoint
- Add checks for dependencies (db, external APIs) as they appear

### Error Handling
- Consistent error responses (ProblemDetails recommended)
- Don’t leak internal stack traces in production
- Use correlation IDs (optional)

## Testing Strategy (when tests exist)
- Unit tests for pure logic (domain/application)
- Integration tests for:
  - API endpoints
  - persistence layer (if present)
- Aim for fast feedback: tests should run locally in seconds

## Operational Notes
- Support local run with `dotnet run`
- Keep README updated with run/test instructions
- Add Docker later only if it serves the learning goal
