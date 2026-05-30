namespace GroceryProof.Application.Common.Services;

public static class UnitConversion
{
    private enum Dimension { Weight, Volume, Count }

    private sealed record UnitDef(Dimension Dimension, double ToBaseMetric);

    private static readonly Dictionary<string, UnitDef> Units =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["g"] = new(Dimension.Weight, 1.0),
            ["oz"] = new(Dimension.Weight, 28.3495),
            ["lb"] = new(Dimension.Weight, 453.592),
            ["ml"] = new(Dimension.Volume, 1.0),
            ["floz"] = new(Dimension.Volume, 29.5735),
            ["cup"] = new(Dimension.Volume, 236.588),
            ["each"] = new(Dimension.Count, 1.0),
            ["slice"] = new(Dimension.Count, 1.0),
            ["patty"] = new(Dimension.Count, 1.0),
            ["bun"] = new(Dimension.Count, 1.0),
        };

    public sealed record ConversionResult(double Quantity, bool Success, string Note);

    public static string NormalizeReferenceUnit(string? rawUnit)
    {
        if (string.IsNullOrWhiteSpace(rawUnit)) return string.Empty;

        return rawUnit.Trim().ToUpperInvariant() switch
        {
            "GRM" or "GRAM" or "GRAMS" => "g",
            "OZA" or "OUNCE" or "OUNCES" => "oz",
            "LBR" or "POUND" or "POUNDS" => "lb",
            "MLT" or "MILLILITER" or "MILLILITERS" => "ml",
            "OZI" or "FL OZ" or "FLUID OUNCE" => "floz",
            _ => rawUnit.Trim().ToLowerInvariant(),
        };
    }

    public static ConversionResult Convert(
        double quantity,
        string? fromUnit,
        string? toUnit,
        double? gramsPerEach = null)
    {
        var from = NormalizeReferenceUnit(fromUnit);
        var to = NormalizeReferenceUnit(toUnit);

        if (from.Length == 0 || to.Length == 0)
            return new(quantity, false, "missing unit");

        if (string.Equals(from, to, StringComparison.OrdinalIgnoreCase))
            return new(quantity, true, "direct");

        if (!Units.TryGetValue(from, out var fromDef))
            return new(quantity, false, $"unknown unit '{from}'");

        if (!Units.TryGetValue(to, out var toDef))
            return new(quantity, false, $"unknown unit '{to}'");

        if (fromDef.Dimension == toDef.Dimension)
        {
            var baseQuantity = quantity * fromDef.ToBaseMetric;
            return new(baseQuantity / toDef.ToBaseMetric, true, $"{from} -> {to}");
        }

        // Approximation for weight-volume conversions where density is close to water.
        if ((fromDef.Dimension == Dimension.Weight && toDef.Dimension == Dimension.Volume)
            || (fromDef.Dimension == Dimension.Volume && toDef.Dimension == Dimension.Weight))
        {
            var gramsOrMl = quantity * fromDef.ToBaseMetric;
            return new(gramsOrMl / toDef.ToBaseMetric, true, $"water-equivalent: {from} -> {to}");
        }

        if (gramsPerEach is > 0)
        {
            if (fromDef.Dimension == Dimension.Count && toDef.Dimension != Dimension.Count)
            {
                var grams = quantity * fromDef.ToBaseMetric * gramsPerEach.Value;
                return new(grams / toDef.ToBaseMetric, true, $"count x {gramsPerEach}g -> {to}");
            }

            if (fromDef.Dimension != Dimension.Count && toDef.Dimension == Dimension.Count)
            {
                var grams = quantity * fromDef.ToBaseMetric;
                var eaches = grams / gramsPerEach.Value;
                return new(eaches / toDef.ToBaseMetric, true, $"{from} -> count");
            }
        }

        return new(quantity, false, $"cannot convert {fromDef.Dimension} -> {toDef.Dimension}");
    }
}
