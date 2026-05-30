# Code Excerpts

The `code-samples/` folder contains sanitized excerpts copied from the private
Grocery codebase or rewritten into non-runnable excerpts that preserve the
engineering idea without exposing the product.

## Included Samples

| File | What it demonstrates |
| --- | --- |
| `ValidationBehaviorExcerpt.cs` | MediatR pipeline validation and domain exception flow |
| `UnitConversionExcerpt.cs` | Practical domain math for units, USDA codes, and count-to-weight bridge logic |
| `PullCompletionApiExcerpt.cs` | Thin API controller over application command contracts |
| `DomainModelExcerpt.cs` | Entity modeling for production completion and cross-vendor ingredient identity |
| `NutritionRollupExcerpt.cs` | Rollup service shape: explicit facility scope, diagnostics, conversion, and persistence boundary |

## Reading Guidance

These are excerpts, not a runnable project. Some namespaces, comments, and
partner-specific names have been removed or generalized. The point is to show
style:

- clear layer boundaries
- explicit contracts
- operator-actionable errors
- source-aware domain logic
- code comments only where they explain a real decision

## Why Not Publish the Whole App?

Grocery has real commercial value. A public proof artifact should help a
technical evaluator trust the work without handing over a turnkey competitor.
