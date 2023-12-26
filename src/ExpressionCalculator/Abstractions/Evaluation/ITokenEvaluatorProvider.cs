using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation;

public interface ITokenEvaluatorProvider
{
    IEnumerable<object> GetAll();
    ITokenEvaluator<IToken> GetEvaluatorForToken<TToken>() where TToken : IToken;
    object GetEvaluatorForToken(Type tokenType);
    object GetEvaluator(Type evaluatorType);
}