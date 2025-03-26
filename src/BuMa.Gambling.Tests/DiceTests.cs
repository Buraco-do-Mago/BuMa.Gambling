namespace BuMa.Gambling.Tests;

public class DiceTests
{
    [Test]
    public void RollIsInRange()
    {
        var range = new Range(1, 6);
        var dice = Dice.D6;
        // but you aren't supposed to use random values for testing!!!!!!
        // - someone who hasn't touched real code in years
        var result = dice.Roll();
        Assert.That(range.IsInRange(result));
    }

    [Test]
    public void RollIsNotInRange()
    {
        var range = new Range(99, 100);
        var dice = Dice.D4;
        var result = dice.Roll();
        Assert.That(range.IsInRange(result), Is.False);
    }

    [Test]
    public void RollIsInEndlessRange()
    {
        var range = Range.Endless;
        var dices = new List<Dice>() { Dice.D4, Dice.D6, Dice.D8, Dice.D10, Dice.D12, Dice.D20, Dice.D100 };
        foreach (var dice in dices)
            Assert.That(range.IsInRange(dice.Roll()));
    }

    [Test]
    public void CalculateOddsOfEndlessRange()
    {
        var dice = Dice.D20;
        var range = Range.Endless;
        Assert.That(dice.CalculateOdds(range), Is.EqualTo(100));
    }

    [Test]
    public void CalculateOddsOfSpecificNumber()
    {
        var dice = Dice.D20;
        var range = new Range(1, 1);
        Assert.That(dice.CalculateOdds(range), Is.EqualTo(5));
    }

    [Test]
    public void CalculateOddsOfAllNumbersInRange()
    {
        var dice = Dice.D20;
        var range = new Range(1, 20);
        Assert.That(dice.CalculateOdds(range), Is.EqualTo(100));
    }

    [Test]
    public void CalculateOddsOfHalfRange()
    {
        var dice = Dice.D20;
        var range = new Range(2, 9);
        Assert.That(dice.CalculateOdds(range), Is.EqualTo(40));
    }

    [Test]
    public void ThrowsErrorWhileCreatingInvalidDice()
    {

    }
}
