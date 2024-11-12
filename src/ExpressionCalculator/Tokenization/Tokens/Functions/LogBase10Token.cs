using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Tokens.Functions;

public class LogBase10Token : FunctionTokenBase
{
    public LogBase10Token() : base(1)
    {
    }
    
    public override string GetStringRepresentation() => "lg";
}