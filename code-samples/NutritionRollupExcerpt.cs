namespace GroceryProof.Infrastructure.Services;

public sealed class NutritionRollupService
{
    private readonly IGroceryDbContext _db;
    private readonly ICurrentUser _currentUser;

    public NutritionRollupService(IGroceryDbContext db, ICurrentUser currentUser)
    {
        _db = db;
        _currentUser = currentUser;
    }

    public Task<RecipeNutritionRollupResult?> CalculateAndSaveAsync(string recipeId)
        => CalculateAndSaveInternalAsync(recipeId, _currentUser.FacilityId);

    private async Task<RecipeNutritionRollupResult?> CalculateAndSaveInternalAsync(
        string recipeId,
        string facilityId)
    {
        // Facility scope is explicit on the query. Do not rely on caller-supplied
        // IDs or view-layer assumptions for tenant boundaries.
        var recipe = await _db.FindRecipeForRollupAsync(recipeId, facilityId);
        if (recipe is null) return null;

        var servings = recipe.DefaultServings > 0 ? recipe.DefaultServings : 1;
        var totals = new Dictionary<string, double>();
        var statuses = new List<IngredientRollupStatus>();

        foreach (var ingredient in recipe.Ingredients)
        {
            var status = RollupDiagnostics.StatusFor(ingredient);
            statuses.Add(status);

            if (status.State != IngredientRollupState.RolledUp)
                continue;

            var nutrition = RollupDiagnostics.ResolveNutrition(ingredient)!;
            var bridgeWeight = RollupDiagnostics.ResolveGramsPerEach(ingredient);

            var conversion = UnitConversion.Convert(
                ingredient.Quantity,
                ingredient.RecipeUnit,
                nutrition.ServingUnit,
                bridgeWeight);

            var servingScale = conversion.Quantity / nutrition.ServingSize;

            AddIfPresent(totals, "Calories", nutrition.Calories, servingScale);
            AddIfPresent(totals, "Protein", nutrition.Protein, servingScale);
            AddIfPresent(totals, "Sodium", nutrition.Sodium, servingScale);
        }

        await _db.UpsertRecipeNutritionAsync(recipe.Id, totals, servings, statuses);

        return new RecipeNutritionRollupResult(
            recipe.Id,
            statuses.Count(s => s.State == IngredientRollupState.RolledUp),
            statuses.Count);
    }

    private static void AddIfPresent(
        IDictionary<string, double> totals,
        string nutrient,
        double? value,
        double scale)
    {
        if (value is null) return;
        totals[nutrient] = totals.GetValueOrDefault(nutrient) + value.Value * scale;
    }
}

public interface IGroceryDbContext
{
    Task<Recipe?> FindRecipeForRollupAsync(string recipeId, string facilityId);
    Task UpsertRecipeNutritionAsync(
        string recipeId,
        IDictionary<string, double> totals,
        int servings,
        IReadOnlyList<IngredientRollupStatus> statuses);
}

public interface ICurrentUser
{
    string FacilityId { get; }
}

public sealed record RecipeNutritionRollupResult(string RecipeId, int RolledUpCount, int TotalCount);
public sealed record IngredientRollupStatus(IngredientRollupState State);
public enum IngredientRollupState { RolledUp, MissingNutrition, MissingUnit, ConversionFailed }

public sealed class Recipe
{
    public string Id { get; set; } = string.Empty;
    public int DefaultServings { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; } = new();
}

public sealed class RecipeIngredient
{
    public double Quantity { get; set; }
    public string RecipeUnit { get; set; } = string.Empty;
}

public static class RollupDiagnostics
{
    public static IngredientRollupStatus StatusFor(RecipeIngredient ingredient) => new(IngredientRollupState.RolledUp);
    public static Nutrition? ResolveNutrition(RecipeIngredient ingredient) => new();
    public static double? ResolveGramsPerEach(RecipeIngredient ingredient) => null;
}

public sealed class Nutrition
{
    public string ServingUnit { get; set; } = "g";
    public double ServingSize { get; set; } = 100;
    public double? Calories { get; set; }
    public double? Protein { get; set; }
    public double? Sodium { get; set; }
}

public static class UnitConversion
{
    public sealed record ConversionResult(double Quantity, bool Success, string Note);
    public static ConversionResult Convert(double qty, string from, string to, double? gramsPerEach)
        => new(qty, true, "excerpt");
}
