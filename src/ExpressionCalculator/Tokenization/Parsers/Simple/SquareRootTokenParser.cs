using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

public class SquareRootTokenParser : MatchingTokenParserBase<SquareRootToken>
{
    public SquareRootTokenParser() : base("sqrt")
    {
    }

    public override SquareRootToken CreateToken()
    {
        return new SquareRootToken();
    }
}