using ExpressionCalculator.Abstractions.Tokenization.Parsing;

namespace ExpressionCalculator.Tokenization.Parsers.Constants;

public class DegreeTokenParser : ConstantTokenParserBase
{
    public DegreeTokenParser() : base("deg", Math.PI / 180)
    {
    }
}