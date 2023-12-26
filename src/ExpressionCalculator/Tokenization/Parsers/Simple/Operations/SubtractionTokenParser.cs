using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Operations;

[ParsingPriority(1_000_000)]
public class SubtractionTokenParser : MatchingTokenParserBase<SubtractionToken>
{
    public SubtractionTokenParser() : base("-")
    {
    }

    public override SubtractionToken CreateToken()
    {
        return new SubtractionToken();
    }
}