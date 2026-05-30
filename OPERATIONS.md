# Operations

Grocery is designed around the daily rhythm of food-service operators.

## Planning Versus Execution

The production board answers: what is scheduled or expected?

The pull sheet answers: what is the kitchen actually making today?

That distinction is central. A schedule is not a production event. A cook still
needs to decide what is being made, what is carryover, what is unavailable, and
what substitutions are being used.

## Production Board

The production board is a planning surface:

- shows recipes by date and meal period
- reflects rotation-driven slots
- helps the operator decide what belongs on the day's pull sheet
- avoids treating scheduled work as completed work

## Pull Sheet

The pull sheet is the execution surface:

- ingredients are grouped by physical storage location
- storage locations are ordered by the actual kitchen walk path
- substitutions are handled at the point of execution
- completion creates the authoritative event record

The product treats walk order as a real operational concern. A scattered list
costs labor. A kitchen-path pull sheet saves it.

## Pull Completion

Completing a pull records:

- which production slot was completed
- which ingredients were actually pulled
- actual quantities and units
- member splits for grouped ingredients
- pinned nutrition snapshot
- pinned allergen snapshot
- optional notes

This event is the source of truth for that production run.

## Nutrition

Recipe nutrition is useful, but it is an estimate. It reflects the current
authored recipe and current ingredient data.

Completed production nutrition is different. It is pinned to the actual run. If
the recipe changes later, the completed run does not change.

## Allergens

Allergen data is conservative by design:

- sources are tracked
- allergens union across sources
- substitutions surface deltas
- the system avoids silent subtraction

## Vendor Variance

The same logical ingredient can come from multiple vendors with different SKUs,
pack sizes, units, costs, or nutrition values. Grocery models that reality
instead of forcing operators to choose between duplicate rows and misleading
merges.

## Operator Philosophy

The product does not try to remove operator agency. It tries to put the right
information at the right decision point so a working operator can move quickly
without losing auditability.
