using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Constants;

public class DegreeToken : IToken
{
    public string GetStringRepresentation() => "deg";
}