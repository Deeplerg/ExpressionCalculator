using ExpressionCalculator.Abstractions.Tokenization.Parsing;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Constants;

public class EulerTokenParser : ConstantTokenParserBase
{
    public EulerTokenParser() : base("e", Math.E)
    {
    }
}