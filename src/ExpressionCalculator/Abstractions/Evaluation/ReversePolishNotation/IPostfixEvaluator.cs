using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation.ReversePolishNotation;

public interface IPostfixEvaluator
{
    double Evaluate(IEnumerable<IToken> postfixTokens);
}