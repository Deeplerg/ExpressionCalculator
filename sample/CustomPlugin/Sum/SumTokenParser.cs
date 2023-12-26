using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization;

namespace CustomPlugin.Sum;

[ParsingPriority(1_120_000)]
public class SumTokenParser : MatchingTokenParserBase<SumToken>
{
    public SumTokenParser() : base("sum")
    {
    }

    public override SumToken CreateToken()
    {
        return new SumToken();
    }
}