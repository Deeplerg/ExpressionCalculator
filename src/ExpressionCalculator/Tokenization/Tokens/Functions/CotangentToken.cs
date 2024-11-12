using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class CotangentToken : FunctionTokenBase
{
    public CotangentToken() : base(1)
    {
    }
    
    public override string GetStringRepresentation() => "cot";
}