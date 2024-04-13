using ExpressionCalculator.Abstractions.Tokenization;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Exceptions;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization;

public class Lexer : ILexer
{
    private readonly IParserInvoker _parserInvoker;
    private readonly List<object> _parsers;
    
    public Lexer(
        IParserProvider parserProvider,
        IParserInvoker parserInvoker)
    {
        _parserInvoker = parserInvoker;
        
        _parsers = parserProvider.GetAllParsers().ToList();
    }
    
    public IEnumerable<IToken> Tokenize(string input)
    {
        input = input.Replace(" ", string.Empty);
        
        var slice = new StringSlice(input);
        
        for (int i = 0; i < input.Length; )
        {
            slice.FromIndex = i;

            // expanded from LINQ FirstOrDefault to avoid allocations
            object? parser = null;
            foreach (var p in _parsers)
            {
                if (_parserInvoker.CanParse(p, slice))
                {
                    parser = p;
                    break;
                }
            }
            
            if (parser is null)
                throw new ParsingException("No parser found for input: " + slice);
            
            var result = _parserInvoker.Parse(parser, slice);
            
            i += result.SkippedCharacters;
            yield return result.Token;
        }
    }
}