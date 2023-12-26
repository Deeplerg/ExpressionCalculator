using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Tokenization;

public interface ILexer
{
    IEnumerable<IToken> Tokenize(string input);
}