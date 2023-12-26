using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Operators;

public class PowerToken : OperatorTokenBase
{
    public PowerToken() : base(2, 4000, AssociativityType.Right) { }
}