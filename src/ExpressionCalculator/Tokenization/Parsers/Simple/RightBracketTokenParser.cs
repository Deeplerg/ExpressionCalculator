using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_200_000)]
public class RightBracketTokenParser : MatchingTokenParserBase<RightBracketToken>
{
    public RightBracketTokenParser() : base(")")
    {
    }

    public override RightBracketToken CreateToken()
    {
        return new RightBracketToken();
    }
}