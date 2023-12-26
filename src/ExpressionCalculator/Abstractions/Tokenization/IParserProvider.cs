using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Tokenization;

public interface IParserProvider
{
    IEnumerable<object> GetAllParsers();
    ITokenParser<IToken> GetParserForToken<TToken>() where TToken : IToken;
    object GetParser(Type parserType);
}