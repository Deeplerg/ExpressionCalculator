using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class RootToken : FunctionTokenBase
{
    public RootToken() : base(2)
    {
    }
}