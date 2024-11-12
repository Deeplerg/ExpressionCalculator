using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class CosineToken : FunctionTokenBase
{
    public CosineToken() : base(1)
    {
    }
    
    public override string GetStringRepresentation() => "cos";
}