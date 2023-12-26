using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Functions;

[ParsingPriority(1_120_000)]
public class TangentTokenParser : MultipleMatchingTokenParserBase<TangentToken>
{
    public TangentTokenParser() : base(new string[] { "tan", "tg" })
    {
    }

    public override TangentToken CreateToken(string matchedToken)
    {
        return new TangentToken();
    }
}