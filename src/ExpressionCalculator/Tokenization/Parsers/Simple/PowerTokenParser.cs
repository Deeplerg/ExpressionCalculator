using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_105_000)]
public class PowerTokenParser : MultipleMatchingTokenParserBase<PowerToken>
{
    public PowerTokenParser() : base(new string[] { "^", "**" })
    {
    }
    
    public override PowerToken CreateToken(string matchedToken)
    {
        return new PowerToken();
    }
}