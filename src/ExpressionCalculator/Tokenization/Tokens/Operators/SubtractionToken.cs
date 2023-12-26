using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Operators;

public class SubtractionToken : OperatorTokenBase
{
    public SubtractionToken() : base(2, 1000, AssociativityType.Left) { }
}