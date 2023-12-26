using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

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