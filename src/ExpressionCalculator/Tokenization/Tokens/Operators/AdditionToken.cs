using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Operators;

public class AdditionToken : OperatorTokenBase
{
    public AdditionToken() : base(2, 1000, AssociativityType.Left) { }
}