using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens;

public class LeftBracketToken : IToken
{
    public string GetStringRepresentation() => "(";
}