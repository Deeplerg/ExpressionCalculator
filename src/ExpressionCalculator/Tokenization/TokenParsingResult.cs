using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization;

public record class TokenParsingResult<T>
    (T Token, int SkippedCharacters)
    : ITokenParsingResult<T>
    where T : IToken
{
}