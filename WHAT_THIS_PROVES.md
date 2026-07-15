# What This Proves

This repo exists for a technical evaluator who wants to understand the
engineering behind Grocery without receiving the private production source.

## The Short Version

Grocery demonstrates a domain model that most commercial food-service
software handles poorly:

- operations-grounded domain design (pull-sheet walk order, terminal events,
  kitchen production as a real bounded context)
- strict Clean Architecture discipline applied to messy enterprise workflows
- safety-first data rules enforced at the domain layer
- ADR-driven product and technical decisions, not accidental architecture
- adapter boundaries that isolate external dependency risk
- public proof discipline that protects private implementation value

## What To Look For

### 1. Product Judgment

Grocery is not a generic recipe database. It separates authoring, production
planning, execution, and audit jobs because those phases have different actors,
different invariants, and different risk profiles. That separation is reflected
in the architecture.

### 2. Architecture Judgment

Clean Architecture is easy to claim and hard to apply consistently. The layer
boundaries in Grocery — domain, application, infrastructure, API — are
maintained under real operational pressure: vendor item variance, cross-vendor
ingredient identity, unit-of-measure bridging, and pull-sheet walk order all
have to work without collapsing into a thick controller.

### 3. Safety Judgment

The allergen union rule, derived-data precedence, and terminal production event
locking are not features. They are safety constraints encoded into the domain.
The architecture enforces them so operators cannot accidentally bypass them.

### 4. Delivery Judgment

ADR discipline from the first meaningful decision means future operators and
agents can understand why the system works the way it does. The code comments in
the excerpts explain decisions, not mechanics.

### 5. Boundary Judgment

This repo shows enough to evaluate the work while excluding the private
integration contracts, schema, deployment artifacts, and implementation internals
that give Grocery its commercial value.

## What This Does Not Prove

This repo does not prove every implementation detail of Grocery. It is not a
runnable clone and should not become one.

For deeper evaluation, use this repo as a public architecture and operating
artifact, then request a guided technical walkthrough if a private review is
appropriate.
