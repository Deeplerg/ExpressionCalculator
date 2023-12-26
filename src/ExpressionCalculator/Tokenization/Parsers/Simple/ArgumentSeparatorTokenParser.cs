using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_300_000)]
public class ArgumentSeparatorTokenParser : MatchingTokenParserBase<ArgumentSeparatorToken>
{
    public ArgumentSeparatorTokenParser() : base(";")
    {
    }

    public override ArgumentSeparatorToken CreateToken()
    {
        return new ArgumentSeparatorToken();
    }
}