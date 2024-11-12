using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class SineToken : FunctionTokenBase
{
    public SineToken() : base(1)
    {
    }
    
    public override string GetStringRepresentation() => "sin";
}