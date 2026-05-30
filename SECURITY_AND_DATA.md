# Security and Data Posture

This proof repo intentionally omits implementation details that would make the
private production product easy to clone or attack. The production system follows
security-minded defaults appropriate for enterprise food-service operations.

## Data Boundaries

- No real facility data is included here.
- No production seed data is included here.
- No private integration contract is included here.
- No deployment workflow, cloud resource name, secret name, or connection string
  is included here.

## Tenancy and Facility Context

The production system treats facility context as a server-side concern. Client
input is not trusted as the source of tenant authority.

Every facility-scoped query must be constrained by the authenticated facility
context.

## Authored Versus Derived Data

Grocery receives data from multiple places:

- operator-authored values
- host-platform values
- corporate or facility catalog values
- USDA or public reference data
- AI inference

The rule is source precedence, not last writer wins. Lower-authority derived data
does not silently overwrite authored data.

## Auditability

Important mutations are designed to produce an audit trail. The most important
example is production completion: a run records what actually happened rather
than allowing a later recipe edit to rewrite history.

## AI Safety Posture

AI is used as an assistant, not an authority:

- classify or suggest
- help map messy import data
- identify likely allergens or missing metadata
- surface uncertainty to the operator

The operator remains responsible for committing final business truth.

## Public Proof Boundary

This repository demonstrates:

- architecture
- representative implementation style
- domain decision quality
- security posture
- operational modeling

It does not provide:

- a runnable product
- complete schemas or migrations
- private integration details
- production source control history
- data sufficient to recreate a customer environment
