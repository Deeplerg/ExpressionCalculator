using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Functions;

[ParsingPriority(1_120_000)]
public class SineTokenParser : MatchingTokenParserBase<SineToken>
{
    public SineTokenParser() : base("sin")
    {
    }

    public override SineToken CreateToken()
    {
        return new SineToken();
    }
}