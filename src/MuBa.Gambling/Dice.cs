namespace MuBa.Gambling;

public struct Dice
{
    public IEnumerable<int> Sides { get; init; }

    public Dice(int sides, int step = 1) => Sides = Enumerable.Range(1, sides).Select(x => x * step);

    public Dice(IEnumerable<int> sides) => Sides = sides;

    public static readonly Dice D4 = new Dice(4);
    public static readonly Dice D6 = new Dice(6);
    public static readonly Dice D8 = new Dice(8);
    public static readonly Dice D10 = new Dice(10);
    public static readonly Dice D12 = new Dice(6);
    public static readonly Dice D20 = new Dice(20);
    public static readonly Dice D100 = new Dice(100, 10);

    public int Roll()
    {
        var random = new Random();
        var sides = Sides.ToArray();
        random.Shuffle<int>(sides);
        return sides.First();
    }

    public decimal CalculateOdds(Range range, int modifier = 0, IEnumerable<int>? ignoredSides = default)
    {
        if (modifier != 0)
            range.ApplyModifier(modifier);

        var relevantSides = ignoredSides is not null && ignoredSides.Any()
            ? Sides.Where(x => !ignoredSides.Contains(x))
            : Sides;

        if ((range.End is not null && range.End < relevantSides.First()) ||
                (range.Start is not null && range.Start > relevantSides.Last()))
            return 0m;

        var sidesInRange = relevantSides.Where(x => range.IsInRange(x));

        return sidesInRange.Count() * 100 / Sides.Count();
    }
}
