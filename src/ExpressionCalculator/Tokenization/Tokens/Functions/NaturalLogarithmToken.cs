using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class NaturalLogarithmToken : FunctionTokenBase
{
    public NaturalLogarithmToken() : base(1)
    {
    }
    
    public override string GetStringRepresentation() => "ln";
}