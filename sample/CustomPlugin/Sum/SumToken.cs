using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace CustomPlugin.Sum;

public class SumToken : FunctionTokenBase
{
    public SumToken() : base(argumentCount: 3) { }
}