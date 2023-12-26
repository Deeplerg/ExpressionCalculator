using ExpressionCalculator.Abstractions.Tokenization.Parsing;

namespace ExpressionCalculator.Tokenization.Parsers.Simple.Constants;

[ParsingPriority(1_900_000)]
public class PiTokenParser : ConstantTokenParserBase
{
    public PiTokenParser() : base("pi", Math.PI)
    {
    }
}