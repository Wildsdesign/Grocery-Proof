# Public Boundary

Grocery has real market value. This proof repo is intentionally strategic and
architectural rather than cloneable.

## Safe To Show

- Clean Architecture layer map and dependency direction
- high-level workflow descriptions (production, inventory, pull-sheet, receiving)
- ADR discipline and selected decision records
- sanitized code excerpts showing style, naming, and layer contracts
- allergen, nutrition, and unit-of-measure design posture
- domain invariant descriptions without schema
- operator-workflow descriptions grounded in real food-service operations

## Not Safe To Show Here

- production source code
- private integration contracts or partner-specific adapter details
- database schema or migrations sufficient to recreate the application
- full route or endpoint maps
- deployment workflows, infrastructure names, or connection strings
- real facility, vendor, or transaction data
- secret names, resource names, or environment files
- enough implementation detail to recreate or clone the product

## Why the Boundary Is Here

Grocery solves problems that most food-service software handles poorly. The
implementation is the asset. The proof shows the thinking behind it.
