namespace ExpressionCalculator.Abstractions.Tokenization.Tokens;

public abstract class FunctionTokenBase : IFunctionToken
{
    public FunctionTokenBase(int argumentCount)
    {
        ArgumentCount = argumentCount;
    }
    
    public int ArgumentCount { get; }
    
    public abstract string GetStringRepresentation();
}