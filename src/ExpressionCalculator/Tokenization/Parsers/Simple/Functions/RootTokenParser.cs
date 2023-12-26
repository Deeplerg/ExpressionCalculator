using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Functions;

[ParsingPriority(1_120_000)]
public class RootTokenParser : MatchingTokenParserBase<RootToken>
{
    public RootTokenParser() : base("root")
    {
    }

    public override RootToken CreateToken()
    {
        return new RootToken();
    }
}