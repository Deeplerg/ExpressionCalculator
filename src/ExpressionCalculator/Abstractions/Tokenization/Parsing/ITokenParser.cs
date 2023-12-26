using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization;

namespace ExpressionCalculator.Abstractions.Tokenization.Parsing;

public interface ITokenParser<T> where T : IToken
{
    bool CanParse(StringSlice input);
    TokenParsingResult<T> Parse(StringSlice currentInput);
}