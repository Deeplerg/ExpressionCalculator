using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Operations;

[ParsingPriority(1_110_000)]
public class FactorialTokenParser : MatchingTokenParserBase<FactorialToken>
{
    public FactorialTokenParser() : base("!")
    {
    }

    public override FactorialToken CreateToken()
    {
        return new FactorialToken();
    }
}