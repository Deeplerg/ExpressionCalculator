using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation;

public abstract class FunctionEvaluatorBase<T> : ITokenEvaluator<T> where T : IFunctionToken
{
    private readonly int _argumentCount;

    public FunctionEvaluatorBase(int argumentCount)
    {
        _argumentCount = argumentCount;
    }
    
    public double Evaluate(IEnumerable<IToken> tokens)
    {
        var tokenList = tokens.ToList();
        
        if (!tokenList.All(t => t is NumberToken))
            throw new ArgumentException("All tokens must be " + nameof(NumberToken));

        if (tokenList.Count != _argumentCount)
            throw new ArgumentException($"Can only evaluate {_argumentCount} arguments.");

        var numberTokens = tokens.Cast<NumberToken>();
        var numbers = numberTokens.Select(t => t.Value);

        return Calculate(numbers);
    }

    public abstract double Calculate(IEnumerable<double> arguments);
}