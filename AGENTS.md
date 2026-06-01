# AGENTS.md - Grocery Proof

This repository is a curated public-proof artifact for Grocery. It is not the
production repository and must not become a runnable clone.

## Proof Repo Shape

Every file in this repo answers one or more of five evaluator questions:

1. What is this product or system?
2. What does this repo prove about Justin's work?
3. What architecture or operating decisions matter?
4. What is safe to show publicly?
5. What is intentionally withheld?

The required files for a complete Wilds proof repo are:

| File | Purpose |
| --- | --- |
| `README.md` | Entry point, evaluator path, proof contents, status |
| `WHAT_THIS_PROVES.md` | Short proof argument for a recruiter or technical evaluator |
| `PUBLIC_BOUNDARY.md` | Explicit safe-to-show and not-safe-to-show boundary |
| `ARCHITECTURE.md` | Product-specific system shape |
| `ADR_DIGEST.md` | Sanitized decisions with rationale |
| `OPERATIONS.md` | How the work is built, verified, or operated |
| `CODE_EXCERPTS.md` | Safe, non-runnable excerpt index |
| `PROOF_REPO_STANDARD.md` | Reusable Wilds proof-repo standard |
| `AGENTS.md` | This file: guardrails for future agents |

## Hard Rules

- Do not copy full source files from the private Grocery repo.
- Do not add deployment workflows, resource names, connection strings, secret
  names, or real fixture data.
- Do not add private partner names or integration contracts.
- Do not add enough schema, migration, or adapter detail to recreate the
  production product.
- Keep code samples excerpted, sanitized, and non-runnable unless Justin
  explicitly approves otherwise.
- The public/private boundary is defined in `PUBLIC_BOUNDARY.md`. It must be
  respected in every file and excerpt.

## Purpose

Show engineering judgment:

- Clean Architecture discipline in a real enterprise workflow
- domain modeling around physical operations, not generic CRUD
- ADR discipline
- safety-oriented rules enforced at the domain layer
- operator-centered workflow design
- representative implementation style

## Source Of Truth

Private Grocery remains the implementation source of truth. This proof repo is a
portfolio artifact.
