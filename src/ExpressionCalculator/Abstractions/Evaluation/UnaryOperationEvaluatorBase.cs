using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation;

public abstract class UnaryOperationEvaluatorBase<T> : ITokenEvaluator<T> where T : IOperatorToken
{
    public double Evaluate(IEnumerable<IToken> tokens)
    {
        var tokenList = tokens.ToList();
        
        if (!tokenList.All(t => t is NumberToken))
            throw new ArgumentException("All tokens must be " + nameof(NumberToken));

        if (tokenList.Count != 1)
            throw new ArgumentException("Can only evaluate one operand.");

        var numberToken = (NumberToken)tokenList[0];

        return Calculate(numberToken.Value);
    }

    public abstract double Calculate(double value);
}