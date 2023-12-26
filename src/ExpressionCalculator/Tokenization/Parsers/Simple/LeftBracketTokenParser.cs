using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_200_000)]
public class LeftBracketTokenParser : MatchingTokenParserBase<LeftBracketToken>
{
    public LeftBracketTokenParser() : base("(")
    {
    }

    public override LeftBracketToken CreateToken()
    {
        return new LeftBracketToken();
    }
}