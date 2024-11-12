using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class TangentToken : FunctionTokenBase
{
    public TangentToken() : base(1)
    {
    }
    
    public override string GetStringRepresentation() => "tan";
}