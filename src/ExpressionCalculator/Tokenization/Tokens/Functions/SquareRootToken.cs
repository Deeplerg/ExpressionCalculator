using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class SquareRootToken : FunctionTokenBase
{
    public SquareRootToken() : base(1) { }
    
    public override string GetStringRepresentation() => "sqrt";
}