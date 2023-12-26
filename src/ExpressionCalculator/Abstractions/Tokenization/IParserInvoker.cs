using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization;

namespace ExpressionCalculator.Abstractions.Tokenization;

public interface IParserInvoker
{
    bool CanParse(object parser, StringSlice input);
    ITokenParsingResult<IToken> Parse(object parser, StringSlice input);
}