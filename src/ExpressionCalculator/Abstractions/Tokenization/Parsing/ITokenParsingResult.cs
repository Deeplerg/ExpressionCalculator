using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Tokenization.Parsing;

public interface ITokenParsingResult<out TToken> where TToken : IToken
{
    TToken Token { get; }
    int SkippedCharacters { get; }
}