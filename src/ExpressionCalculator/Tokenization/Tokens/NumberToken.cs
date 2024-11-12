using System.Globalization;
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
    
    public string GetStringRepresentation() => Value.ToString(CultureInfo.CurrentCulture);
}