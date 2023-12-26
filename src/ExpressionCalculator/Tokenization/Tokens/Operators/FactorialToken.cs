using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Operators;

public class FactorialToken : OperatorTokenBase
{
    public FactorialToken() : base(1, 3000, AssociativityType.Left) { }
}