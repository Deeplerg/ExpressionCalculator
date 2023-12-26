using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Operations;

[ParsingPriority(1_100_000)]
public class MultiplicationTokenParser : MatchingTokenParserBase<MultiplicationToken>
{
    public MultiplicationTokenParser() : base("*")
    {
    }

    public override MultiplicationToken CreateToken()
    {
        return new MultiplicationToken();
    }
}