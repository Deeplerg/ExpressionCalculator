using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Operations;

[ParsingPriority(1_100_000)]
public class DivisionTokenParser : MatchingTokenParserBase<DivisionToken>
{
    public DivisionTokenParser() : base("/")
    {
    }

    public override DivisionToken CreateToken()
    {
        return new DivisionToken();
    }
}