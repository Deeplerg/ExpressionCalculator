namespace ExpressionCalculator.Abstractions.Tokenization.Tokens;

public class FunctionTokenBase : IFunctionToken
{
    public FunctionTokenBase(int? argumentCount)
    {
        ArgumentCount = argumentCount;
    }
    
    public int? ArgumentCount { get; }
}