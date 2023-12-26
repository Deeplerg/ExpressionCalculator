using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.ReversePolishNotation;

public interface IInfixToPostfixConverter
{
    IEnumerable<IToken> Convert(IEnumerable<IToken> tokens);
}