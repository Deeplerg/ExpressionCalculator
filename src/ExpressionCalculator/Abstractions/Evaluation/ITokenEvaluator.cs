using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation;

public interface ITokenEvaluator<T> where T : IToken
{
    double Evaluate(IEnumerable<IToken> tokens);
}