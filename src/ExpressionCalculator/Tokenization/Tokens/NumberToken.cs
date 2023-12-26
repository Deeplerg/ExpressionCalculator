using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens;

public class NumberToken : IValueToken<double>
{
    public NumberToken()
    {
    }

    public NumberToken(double value)
    {
        Value = value;
    }
    
    public double Value { get; private set; }
}