# ADR Digest

This digest summarizes selected architecture decisions from the private Grocery
repo. The full ADR set remains private until each record is reviewed for public
release.

## ADR-001: Clean Architecture

**Decision:** Use a layered .NET architecture with Domain at the center,
Application for use cases, Infrastructure for EF Core and external services,
API for HTTP composition, and React for the operator interface.

**Why it matters:** The product can evolve across UI, persistence, and
integration changes without collapsing domain behavior into controllers or
components.

## ADR-003: Direct DbContext over Repository

**Decision:** Use EF Core through an application-facing context interface rather
than wrapping it in a generic repository layer.

**Why it matters:** The system keeps expressive queries while still preserving
Clean Architecture boundaries.

## ADR-005: Pull Sheet as Cook-Driven Execution Surface

**Decision:** Recipes are not automatically treated as produced because they
appear on a schedule. The cook explicitly adds work to the pull sheet and
completes production from that execution surface.

**Why it matters:** The software respects the kitchen reality: staff, inventory,
carryover, substitutions, and management choices change the day.

## ADR-006: Allergen Union Model

**Decision:** Allergens union, never silently subtract. If any trusted source
flags an allergen, the system carries it forward until an authorized operator
resolves the underlying source.

**Why it matters:** False positives are safer than false negatives in food
service. The system surfaces uncertainty instead of hiding it.

## ADR-007: Entity Separation

**Decision:** Separate physical stock, recipe authorship, grouped ingredient
identity, and host-platform menu identity instead of forcing one table to serve
every purpose.

**Why it matters:** Collapsing these concepts creates silent data loss and
incorrect operational behavior.

## ADR-008: Enrichment Cascade

**Decision:** Nutrition and allergen enrichment belongs at the mutation layer.
When an item changes, dependent recipe estimates are recalculated from the write
path rather than from UI components.

**Why it matters:** Views display truth; they do not orchestrate domain cascades.

## ADR-010: Rotation-Driven Production Slots

**Decision:** Menu rotations generate production slots, but the pull sheet
remains the execution authority.

**Why it matters:** Planning and execution are related but distinct operator
jobs.

## ADR-013: Authored vs Derived Data

**Decision:** Every stored value should know where it came from. Authored data
has higher authority than derived data. Derived sources never silently overwrite
operator-authored values.

**Why it matters:** AI and external data are useful, but they cannot be allowed
to erase local knowledge.

## ADR-015: Visual Grammar by Operator Job

**Decision:** Scan surfaces and authoring surfaces use different UI grammars.
Fast operational scanning gets compact controls and state badges; deliberate
authoring gets clearer labels and stronger affordances.

**Why it matters:** UI shape follows cognitive work, not component-library
convenience.

## ADR-021: Nutrition Authority Model

**Decision:** Recipe nutrition is an estimate. Pull completion nutrition is the
authoritative event. Completed production creates pinned nutrition and allergen
snapshots for that run.

**Why it matters:** A recipe can change tomorrow. A completed production run
must remain historically true.
