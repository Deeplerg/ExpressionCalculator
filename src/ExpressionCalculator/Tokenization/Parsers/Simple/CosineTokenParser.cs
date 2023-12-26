using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_120_000)]
public class CosineTokenParser : MatchingTokenParserBase<CosineToken>
{
    public CosineTokenParser() : base("cos")
    {
    }

    public override CosineToken CreateToken()
    {
        return new CosineToken();
    }
}