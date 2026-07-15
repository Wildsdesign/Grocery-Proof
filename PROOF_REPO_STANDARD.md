# Wilds Proof Repo Standard

This is the working standard for public Wilds proof repositories. It was
defined from the MindServe proof pass and should be reused for Grocery-Proof and
MealMind-Proof unless a repo has a stronger local reason to differ.

## Purpose

A proof repo is not a code dump. It is a curated public artifact that lets a
technical reader evaluate product judgment, architecture judgment, delivery
discipline, and public/private boundary discipline.

## Required Shape

Every proof repo should answer five questions quickly:

1. What is this product or system?
2. What does this repo prove about the engineering behind it?
3. What architecture or operating decisions matter?
4. What is safe to show publicly?
5. What is intentionally withheld?

## Required Files

| File | Purpose |
| --- | --- |
| `README.md` | Entry point, evaluator path, proof contents, status |
| `WHAT_THIS_PROVES.md` | Short proof argument for a recruiter, founder, or technical evaluator |
| `PUBLIC_BOUNDARY.md` | Explicit safe-to-show and not-safe-to-show boundary |
| Architecture doc | Product-specific architecture shape |
| ADR or decision digest | Sanitized decisions with rationale |
| Operating or runbook doc | How the work is built, verified, operated, or handed off |
| Code excerpt index | Safe, non-runnable excerpts only when useful |
| `AGENTS.md` | Guardrails for future agents editing the proof repo |

## Copy Rules

Use:

- concrete product language
- short evaluator paths
- public-safe architecture summaries
- "what this proves" phrasing
- explicit omissions
- calm, boring, proof-heavy tone

Avoid:

- production source code
- cloneable endpoint maps
- database schemas unless deliberately sanitized
- secrets, resource names, private URLs, environment files
- customer, facility, employee, patient, or transaction data
- implementation internals that create commercial risk
- inflated claims that are not visible in the repo

## Code Excerpt Rules

Safe excerpts may show:

- naming style
- interface shape
- high-level use-case boundaries
- validation posture
- comments explaining architecture intent

Safe excerpts must not show:

- private business rules
- production query logic
- schema details
- route maps
- resource identifiers
- auth internals
- deploy configuration

## Done Criteria

A proof repo is ready when:

1. A cold reader understands the product in under one minute.
2. A technical evaluator can find architecture, ADR, security, and boundary
   material without guessing.
3. The repo makes a clear argument for the product and engineering behind it.
4. The repo cannot be mistaken for production source.
5. The public/private boundary is repeated in the README, `PUBLIC_BOUNDARY.md`,
   and `AGENTS.md`.
