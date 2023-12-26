using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Tokenization.Parsers.Simple;

[ParsingPriority(1_000_000)]
public class AdditionTokenParser : MatchingTokenParserBase<AdditionToken>
{
    public AdditionTokenParser() : base("+")
    {
    }

    public override AdditionToken CreateToken()
    {
        return new AdditionToken();
    }
}