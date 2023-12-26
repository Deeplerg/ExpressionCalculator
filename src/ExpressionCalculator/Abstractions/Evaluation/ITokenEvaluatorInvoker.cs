using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation;

public interface ITokenEvaluatorInvoker
{
    double Evaluate(object evaluator, IEnumerable<IToken> input);
}