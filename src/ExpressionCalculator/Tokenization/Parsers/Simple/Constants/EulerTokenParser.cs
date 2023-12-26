using ExpressionCalculator.Abstractions.Tokenization.Parsing;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Constants;

[ParsingPriority(1_900_000)]
public class EulerTokenParser : ConstantTokenParserBase
{
    public EulerTokenParser() : base("e", Math.E)
    {
    }
}