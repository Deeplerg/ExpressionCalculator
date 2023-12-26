using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization;

namespace ExpressionCalculator.Abstractions.Tokenization.Parsing;

public abstract class MatchingTokenParserBase<T> : ITokenParser<T> where T : IToken
{
    public string Token { get; init; }
    
    public MatchingTokenParserBase(string token)
    {
        Token = token;
    }
    
    public bool CanParse(StringSlice input)
    {
        return input.StartsWith(Token);
    }

    public TokenParsingResult<T> Parse(StringSlice currentInput)
    {
        var token = CreateToken();
        return new TokenParsingResult<T>(
            Token: token,
            SkippedCharacters: Token.Length);
    }

    public abstract T CreateToken();
}