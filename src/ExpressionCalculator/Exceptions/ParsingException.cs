namespace ExpressionCalculator.Exceptions;

public class ParsingException : Exception
{
    public ParsingException() : base()
    {
    }
    
    public ParsingException(string message) : base(message)
    {
    }
    
    public ParsingException(string message, Exception innerException) : base(message, innerException)
    {
    }
}