using System.ComponentModel.DataAnnotations;

namespace GroceryProof.Domain.Entities;

public sealed class PullCompletion
{
    public string Id { get; set; } = string.Empty;
    public string FacilityId { get; set; } = string.Empty;
    public string? ProductionRunId { get; set; }
    public DateTime CompletedAt { get; set; }
    public string? CompletedBy { get; set; }
    public string? Notes { get; set; }

    public List<PullCompletionLine> Lines { get; set; } = new();
    public List<ProductionRunNutrition> NutritionSnapshots { get; set; } = new();
    public List<ProductionRunAllergen> AllergenSnapshots { get; set; } = new();
}

public sealed class PullCompletionLine
{
    public string Id { get; set; } = string.Empty;
    public string PullCompletionId { get; set; } = string.Empty;
    public string RecipeIngredientId { get; set; } = string.Empty;
    public decimal ActualQuantity { get; set; }
    public string ActualUnit { get; set; } = string.Empty;

    public List<PullCompletionMemberSplit> MemberSplits { get; set; } = new();
}

public sealed class PullCompletionMemberSplit
{
    public string Id { get; set; } = string.Empty;
    public string PullCompletionLineId { get; set; } = string.Empty;
    public string MemberItemId { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
}

public sealed class ItemGroup
{
    public string Id { get; set; } = string.Empty;
    public string FacilityId { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string BaseUnit { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    public bool NutritionVarianceApproved { get; set; }

    public List<Item> Members { get; set; } = new();
}

public sealed class Item
{
    public string Id { get; set; } = string.Empty;
    public string FacilityId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public decimal OnHand { get; set; }
}

public sealed class ProductionRunNutrition { }
public sealed class ProductionRunAllergen { }
