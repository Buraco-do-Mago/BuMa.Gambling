using BuMa.Gambling.Exceptions;

namespace BuMa.Gambling;

public struct Dice
{
    public IEnumerable<int> Sides { get; init; }

    public Dice(int sides, int step = 1)
    {
        if (sides <= 0)
            throw new InvalidDiceException("My man, a dice cannot have zero sides.");
        if (step <= 0)
            throw new InvalidDiceException("My man, the steps must be greater than zero, or else all of the die's values will be the same.");
        Sides = Enumerable.Range(1, sides).Select(x => x * step);
    }

    public Dice(IEnumerable<int> sides) => Sides = sides;

    public static readonly Dice D4 = new(4);
    public static readonly Dice D6 = new(6);
    public static readonly Dice D8 = new(8);
    public static readonly Dice D10 = new(10);
    public static readonly Dice D12 = new(6);
    public static readonly Dice D20 = new(20);
    public static readonly Dice D100 = new(100, 10);

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
