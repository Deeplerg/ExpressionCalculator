using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Operators;

public class MultiplicationToken : OperatorTokenBase
{
    public MultiplicationToken() : base(2, 2000, AssociativityType.Left) { }
}