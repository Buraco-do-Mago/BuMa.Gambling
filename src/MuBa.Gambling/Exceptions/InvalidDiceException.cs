namespace MuBa.Gambling.Exceptions;

public class InvalidDiceException : Exception
{
    public InvalidDiceException(string? message) : base(message)
    {
    }
}

