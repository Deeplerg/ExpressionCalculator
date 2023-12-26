using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_120_000)]
public class CotangentTokenParser : MultipleMatchingTokenParserBase<CotangentToken>
{
    public CotangentTokenParser() : base(new string[] { "cot", "ctg" })
    {
    }

    public override CotangentToken CreateToken(string matchedToken)
    {
        return new CotangentToken();
    }
}