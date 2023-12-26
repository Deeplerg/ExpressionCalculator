using System.Reflection;
using ExpressionCalculator.Abstractions.Tokenization;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization;

public class ParserInvoker : IParserInvoker
{
    private delegate bool CanParseDelegate(StringSlice input);
    private delegate TokenParsingResult<IToken> ParseDelegate(StringSlice input);
    
    private readonly List<CanParseDelegate> _canParseDelegateCache = new();
    private readonly Dictionary<object, MethodInvoker> _parseInvokerCache = new();
    
    public ParserInvoker(IParserProvider parserProvider)
    {
        var parsers = parserProvider.GetAllParsers().ToList();
        
        _canParseDelegateCache.AddRange(GetCanParseDelegates(parsers));
        
        var pairs = GetParseMethodInvokerPairs(parsers);
        foreach (var pair in pairs)
        {
            _parseInvokerCache.Add(pair.Key, pair.Value);
        }
    }
    
    public bool CanParse(object parser, StringSlice input)
    {
        var @delegate = _canParseDelegateCache.FirstOrDefault(d => d.Target == parser);
        if (@delegate is null)
            throw new InvalidOperationException("Parser not found in cache");

        return @delegate(input);
    }

    public ITokenParsingResult<IToken> Parse(object parser, StringSlice input)
    {
        if (!_parseInvokerCache.TryGetValue(parser, out var invoker))
            throw new InvalidOperationException("Parser not found in cache");

        return (ITokenParsingResult<IToken>)invoker.Invoke(parser, input)!;
    }

    private IEnumerable<CanParseDelegate> GetCanParseDelegates(IEnumerable<object> parsers)
    {
        foreach (var parser in parsers)
        {
            yield return GetCanParseDelegate(parser);
        }
    }
    
    private IEnumerable<KeyValuePair<object, MethodInvoker>> GetParseMethodInvokerPairs(IEnumerable<object> parsers)
    {
        foreach (var parser in parsers)
        {
            var invoker = GetParseMethodInvoker(parser);
            yield return new KeyValuePair<object, MethodInvoker>(parser, invoker);
        }
    }
    
    private CanParseDelegate GetCanParseDelegate(object parser)
    {
        string methodName = nameof(ITokenParser<IToken>.CanParse);

        var method = GetMethodInfoOrThrow(parser, methodName);
        
        return (CanParseDelegate)method.CreateDelegate(typeof(CanParseDelegate), parser);
    }
    
    private MethodInvoker GetParseMethodInvoker(object parser)
    {
        string methodName = nameof(ITokenParser<IToken>.Parse);

        var method = GetMethodInfoOrThrow(parser, methodName);

        return MethodInvoker.Create(method);
    }
    
    private MethodInfo GetMethodInfoOrThrow(object parser, string methodName)
    {
        var type = parser.GetType();
        var method = type.GetMethod(methodName);
        
        if (method is null)
            throw new InvalidOperationException("Parser does not implement " + methodName);

        return method;
    }
}