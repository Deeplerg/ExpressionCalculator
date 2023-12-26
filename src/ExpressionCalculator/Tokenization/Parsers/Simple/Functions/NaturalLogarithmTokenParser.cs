using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Functions;

[ParsingPriority(1_120_000)]
public class NaturalLogarithmTokenParser : MatchingTokenParserBase<NaturalLogarithmToken>
{
    public NaturalLogarithmTokenParser() : base("ln")
    {
    }

    public override NaturalLogarithmToken CreateToken()
    {
        return new NaturalLogarithmToken();
    }
}