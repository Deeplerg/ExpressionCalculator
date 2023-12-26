namespace ExpressionCalculator.Exceptions;

public class MatchingTokenParsingException : ParsingException
{
    public MatchingTokenParsingException(string message) : base(message)
    {
    }
}