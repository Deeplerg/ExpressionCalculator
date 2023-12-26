using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation;

public abstract class BinaryOperationEvaluatorBase<T> : ITokenEvaluator<T> where T : IToken
{
    public double Evaluate(IEnumerable<IToken> tokens)
    {
        var tokenList = tokens.ToList();
        
        if (!tokenList.All(t => t is NumberToken))
            throw new ArgumentException("All tokens must be " + nameof(NumberToken));

        if (tokenList.Count != 2)
            throw new ArgumentException("Can only evaluate two operands");

        var left = (NumberToken)tokenList[0];
        var right = (NumberToken)tokenList[1];

        return Calculate(left.Value, right.Value);
    }

    public abstract double Calculate(double left, double right);
}