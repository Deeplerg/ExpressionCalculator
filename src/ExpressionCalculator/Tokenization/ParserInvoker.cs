using ExpressionCalculator.Abstractions.Tokenization;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.InvocationUtilities;

namespace ExpressionCalculator.Tokenization;

public class ParserInvoker : IParserInvoker
{
    private delegate bool CanParseDelegate(StringSlice input);
    private delegate ITokenParsingResult<IToken> ParseDelegate(StringSlice input);

    private readonly DelegateCache<CanParseDelegate> _canParseDelegateCache = new();
    private readonly DelegateCache<ParseDelegate> _parseDelegateCache = new();
    
    public ParserInvoker(IParserProvider parserProvider)
    {
        var parsers = parserProvider.GetAllParsers().ToList();
        
        _canParseDelegateCache.AddDelegates(CreateCanParseDelegates(parsers));
        _parseDelegateCache.AddDelegates(CreateParseDelegates(parsers));
    }
    
    public ITokenParsingResult<IToken> Parse(object parser, StringSlice input)
    {
        var @delegate = _parseDelegateCache.FindDelegate(parser);

        return @delegate(input);
    }
    
    public bool CanParse(object parser, StringSlice input)
    {
        var @delegate = _canParseDelegateCache.FindDelegate(parser);
        
        return @delegate(input);
    }
    
    private IEnumerable<CanParseDelegate> CreateCanParseDelegates(IEnumerable<object> targets)
    {
        string methodName = nameof(ITokenParser<IToken>.CanParse);
        return DelegateCreationHelper.CreateDelegates<CanParseDelegate>(targets, methodName);
    }
    
    private IEnumerable<ParseDelegate> CreateParseDelegates(IEnumerable<object> targets)
    {
        string methodName = nameof(ITokenParser<IToken>.Parse);
        return DelegateCreationHelper.CreateDelegates<ParseDelegate>(targets, methodName);
    }
}