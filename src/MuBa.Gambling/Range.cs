namespace MuBa.Gambling;

public struct Range
{
    public int? Start { get; private set; }
    public int? End { get; private set; }

    public Range(int? start = default, int? end = default)
    {
        Start = start;
        End = end;
    }

    public static Range Endless() => new Range();

    public void ApplyModifier(int modifier)
    {
        if (Start is not null)
            Start += modifier;
        if (End is not null)
            End += modifier;
    }

    public bool IsInRange(int x)
    {
        var isGreaterThanStart = Start is null || x >= Start;
        var isLesserThanEnd = End is null || x <= End;
        return isGreaterThanStart && isLesserThanEnd;
    }
}
