using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Functions;

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