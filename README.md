# Grocery Proof

Curated technical proof artifact for Grocery, a Wilds, Inc. food-service
operations platform.

This repository is intentionally **not** the production source tree. It is a
public-reviewable artifact that shows product thinking, system architecture,
selected decision records, and representative code excerpts without exposing the
turnkey application, deployment configuration, private integration details, or
commercially valuable implementation surface.

## How To Read This Repo

Start here if you are evaluating Justin Wilds or Grocery technically:

1. Read [WHAT_THIS_PROVES.md](WHAT_THIS_PROVES.md) for the short evaluator view.
2. Read [ARCHITECTURE.md](ARCHITECTURE.md) for the system shape and layer boundaries.
3. Read [ADR_DIGEST.md](ADR_DIGEST.md) for decision discipline.
4. Read [SECURITY_AND_DATA.md](SECURITY_AND_DATA.md) for the data safety posture.
5. Read [OPERATIONS.md](OPERATIONS.md) for the operator workflows driving the design.
6. Read [CODE_EXCERPTS.md](CODE_EXCERPTS.md) and browse `code-samples/` for
   implementation style.
7. Read [PUBLIC_BOUNDARY.md](PUBLIC_BOUNDARY.md) before asking why production
   internals are not here.

## What Grocery Demonstrates

Grocery models the messy middle of enterprise food-service operations:

- recipe authoring and production planning
- inventory, storage locations, receiving, and vendor item variance
- nutrition and allergen source precedence
- pull-sheet execution in physical kitchen walk order
- integration boundaries with an existing host platform
- auditability, facility isolation, and operator-driven decision points

The core product idea is simple: operational software should fit how the work
actually happens, not force operators to reshape the work around the software.

## Technical Shape

The production system follows .NET Clean Architecture:

```text
Grocery.Domain          domain entities and invariants
Grocery.Application     commands, queries, validation, interfaces
Grocery.Infrastructure  EF Core, SQL Server, external services
Grocery.API             ASP.NET Core controllers, middleware, composition
Grocery.Client          React + TypeScript operator surfaces
```

Dependencies point inward. Controllers stay thin. Writes flow through command
handlers. External service clients live behind application interfaces.

## Proof Contents

| File | Purpose |
| --- | --- |
| `WHAT_THIS_PROVES.md` | Short evaluator guide: what the repo is evidence for |
| `ARCHITECTURE.md` | System shape, layer boundaries, workflow map |
| `ADR_DIGEST.md` | Selected architecture decisions and why they matter |
| `OPERATIONS.md` | Operator workflows Grocery is designed around |
| `SECURITY_AND_DATA.md` | Security, tenancy, audit, source-precedence posture |
| `CODE_EXCERPTS.md` | Guide to the included representative code samples |
| `code-samples/` | Sanitized excerpts showing style and implementation judgment |
| `PUBLIC_BOUNDARY.md` | What this proof repo intentionally excludes |
| `PROOF_REPO_STANDARD.md` | Reusable standard for Wilds public proof repos |

## What Is Deliberately Omitted

This proof repo does not include:

- full application source
- production Git history
- deployment workflows or infrastructure secrets
- real facility data
- private partner-specific integration contracts
- database migrations sufficient to recreate the application
- complete runnable frontend or backend

That boundary is intentional. The purpose is to prove the work, not give away
the product.

## Representative Strengths

- Clean Architecture discipline in a real enterprise workflow.
- ADR-driven product and technical decisions.
- Domain modeling around physical operations instead of generic CRUD.
- Safety-oriented rules: allergens union, derived data never silently overwrites
  authored data, and terminal production events pin the authoritative record.
- Operator-facing design choices rooted in actual food-service workflows.

## Status

Curated proof artifact. Production Grocery remains private.
