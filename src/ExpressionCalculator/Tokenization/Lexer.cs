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
        var tokens = new List<IToken>();

        input = input.Replace(" ", string.Empty);
        
        for (int i = 0; i < input.Length; )
        {
            var slice = new StringSlice(input, i, input.Length);

            object? parser = _parsers.FirstOrDefault(p => _parserInvoker.CanParse(p, slice));
            if (parser is null)
                throw new ParsingException("No parser found for input: " + slice);

            var result = _parserInvoker.Parse(parser, slice);
            
            i += result.SkippedCharacters;
            tokens.Add(result.Token);
        }

        return tokens;
    }
}