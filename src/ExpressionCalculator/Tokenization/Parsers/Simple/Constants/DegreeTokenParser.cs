using ExpressionCalculator.Abstractions.Tokenization.Parsing;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Constants;

[ParsingPriority(1_900_000)]
public class DegreeTokenParser : ConstantTokenParserBase
{
    public DegreeTokenParser() : base("deg", Math.PI / 180)
    {
    }
}