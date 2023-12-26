using ExpressionCalculator.Abstractions.Tokenization;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionCalculator.Tokenization;

public class ParserProvider : IParserProvider
{
    private readonly List<object> _parsers = new();

    public ParserProvider(
        IParserTypeCollection parserTypes,
        IServiceProvider serviceProvider)
    {
        var activatedParsers = ActivateParsers(parserTypes.GetAll(), serviceProvider);
        _parsers.AddRange(activatedParsers);
    }
    
    public IEnumerable<object> GetAllParsers()
    {
        return _parsers;
    }

    public ITokenParser<IToken> GetParserForToken<TToken>() where TToken : IToken
    {
        var tokenType = typeof(IToken);

        return (ITokenParser<IToken>)_parsers.First(t => ParserForTokenFilter(t, tokenType));
    }

    public object GetParser(Type parserType)
    {
        return _parsers.First(t => t.GetType() == parserType);
    }
    
    private IEnumerable<object> ActivateParsers(IEnumerable<Type> parserTypes, IServiceProvider serviceProvider)
    {
        foreach (var type in parserTypes)
        {
            yield return ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, type);
        }
    }

    private bool ParserForTokenFilter(object parser, Type tokenType)
    {
        var parserType = parser.GetType();
        
        return parserType.IsAssignableTo(typeof(ITokenParser<>).MakeGenericType(tokenType));
    }
}