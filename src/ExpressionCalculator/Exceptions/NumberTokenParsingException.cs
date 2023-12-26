namespace ExpressionCalculator.Exceptions;

public class NumberTokenParsingException : ParsingException
{
    public NumberTokenParsingException(string message) : base(message)
    {
    }
}