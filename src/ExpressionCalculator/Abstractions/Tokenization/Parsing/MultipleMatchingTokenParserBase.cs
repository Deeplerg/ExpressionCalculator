using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization;

namespace ExpressionCalculator.Abstractions.Tokenization.Parsing;

public abstract class MultipleMatchingTokenParserBase<T> : ITokenParser<T> where T : IToken
{
    public List<string> Tokens { get; init; }
    
    public MultipleMatchingTokenParserBase(IEnumerable<string> tokens)
    {
        Tokens = tokens.ToList();
    }
    
    public bool CanParse(StringSlice input)
    {
        foreach (string token in Tokens)
        {
            if (input.StartsWith(token))
                return true;
        }

        return false;
    }

    public TokenParsingResult<T> Parse(StringSlice currentInput)
    {
        string? matchedToken = null;
        foreach (string possibleToken in Tokens)
        {
            if (currentInput.StartsWith(possibleToken))
            {
                matchedToken = possibleToken;
                break;
            }
        }
        
        if (matchedToken is null)
            throw new InvalidOperationException("No matching token found");

        var token = CreateToken(matchedToken);
        
        return new TokenParsingResult<T>(
            Token: token,
            SkippedCharacters: matchedToken.Length);
    }

    public abstract T CreateToken(string matchedToken);
}