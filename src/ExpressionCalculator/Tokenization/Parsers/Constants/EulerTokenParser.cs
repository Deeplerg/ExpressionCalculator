using ExpressionCalculator.Abstractions.Tokenization.Parsing;

namespace ExpressionCalculator.Tokenization.Parsers.Constants;

public class EulerTokenParser : ConstantTokenParserBase
{
    public EulerTokenParser() : base("e", Math.E)
    {
    }
}