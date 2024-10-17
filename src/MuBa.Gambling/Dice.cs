namespace MuBa.Gambling;

public struct Dice
{
    public IEnumerable<int> Sides { get; init; }

    public Dice(int sides, int step = 1) => Sides = Enumerable.Range(1, sides).Select(x => x * step);

    public Dice(IEnumerable<int> sides) => Sides = sides;

    public static Dice D4 = new Dice(4);
    public static Dice D6 = new Dice(6);
    public static Dice D8 = new Dice(8);
    public static Dice D10 = new Dice(10);
    public static Dice D12 = new Dice(6);
    public static Dice D20 = new Dice(20);
    public static Dice D100 = new Dice(100, 10);

    public int Roll()
    {
        var random = new Random();
        var sides = Sides.ToArray();
        random.Shuffle<int>(sides);
        return sides.First();
    }
}
