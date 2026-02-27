# Decisions (ADRs) — CursorWebAPI

This is a lightweight decision log. Keep entries short:
- Context
- Decision
- Consequences

---

## ADR-0001 — Use Cursor-driven “plan then implement” workflow
**Date:** 2026-02-26

**Context:** Goal is to develop a repeatable AI-assisted engineering workflow.

**Decision:** Use Opus for planning/architecture and Sonnet/Codex for implementation.

**Consequences:** Work will be structured into small commits and documented in this repo for better agent context.

---

## ADR-0002 — Repository structure
**Date:** 2026-02-26

**Context:** Agents perform better when the repository contains explicit context and conventions.

**Decision:** Start with documentation + `.cursorrules` first; add the .NET solution/projects after the workflow is established.

**Consequences:** Early commits are small and provide stable context; README will be updated once code exists.

---

## ADR-0003 — Testing framework
**Date:** 2026-02-26

**Context:** Need a default test framework and conventions.

**Decision:** Use xUnit for unit + integration tests.

**Consequences:** Standard .NET ecosystem support; easy integration with `dotnet test`.

---

## ADR-0004 — API style (Minimal API vs Controllers)
**Date:** 2026-02-26

**Context:** Need consistent endpoint style and conventions.

**Decision:** Use Minimal API.

**Consequences:** Affects routing conventions, validation approach, and structure.

---

## ADR-0005 — Persistence approach
**Date:** 2026-02-26

**Context:** Project may add storage later.

**Decision:** Use EF Core + SQLite (code-first migrations).

**Consequences:** Impacts architecture boundaries, migrations, and integration tests.
