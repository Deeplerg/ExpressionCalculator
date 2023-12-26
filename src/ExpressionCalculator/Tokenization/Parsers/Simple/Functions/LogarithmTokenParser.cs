using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Functions;

[ParsingPriority(1_120_000)]
public class LogarithmTokenParser : MatchingTokenParserBase<LogarithmToken>
{
    public LogarithmTokenParser() : base("log")
    {
    }

    public override LogarithmToken CreateToken()
    {
        return new LogarithmToken();
    }
}