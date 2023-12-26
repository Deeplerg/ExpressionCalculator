using ExpressionCalculator.Abstractions.Tokenization.Parsing;

namespace ExpressionCalculator.Tokenization.Parsers.Constants;

public class PiTokenParser : ConstantTokenParserBase
{
    public PiTokenParser() : base("pi", Math.PI)
    {
    }
}