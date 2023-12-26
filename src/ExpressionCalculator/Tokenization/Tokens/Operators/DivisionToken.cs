using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Operators;

public class DivisionToken : OperatorTokenBase
{
    public DivisionToken() : base(2, 2000, AssociativityType.Left) { }
}