using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_120_000)]
public class LogBase10TokenParser : MatchingTokenParserBase<LogBase10Token>
{
    public LogBase10TokenParser() : base("lg")
    {
    }

    public override LogBase10Token CreateToken()
    {
        return new LogBase10Token();
    }
}