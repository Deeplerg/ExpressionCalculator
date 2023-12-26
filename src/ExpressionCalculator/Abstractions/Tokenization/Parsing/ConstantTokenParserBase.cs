using ExpressionCalculator.Tokenization;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Tokenization.Parsing;

public abstract class ConstantTokenParserBase : ITokenParser<NumberToken>
{
    private readonly string _constantName;
    private readonly double _constantValue;

    public ConstantTokenParserBase(string constantName, double constantValue)
    {
        _constantName = constantName;
        _constantValue = constantValue;
    }
    
    public bool CanParse(StringSlice input)
    {
        return input.StartsWith(_constantName);
    }

    public TokenParsingResult<NumberToken> Parse(StringSlice currentInput)
    {
        var token = new NumberToken(_constantValue);
        int charactersSkipped = _constantName.Length;
        
        return new TokenParsingResult<NumberToken>(token, charactersSkipped);
    }
}