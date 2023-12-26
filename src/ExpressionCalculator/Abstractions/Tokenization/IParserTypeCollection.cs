using System.Reflection;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Tokenization;

public interface IParserTypeCollection
{
    void Add(Type parserType);
    void Add<TParser, TToken>() 
        where TParser : ITokenParser<TToken> 
        where TToken : IToken;
    
    void AddFromAssembly(Assembly assembly);
    
    void Clear();
    
    IEnumerable<Type> GetAll();
}