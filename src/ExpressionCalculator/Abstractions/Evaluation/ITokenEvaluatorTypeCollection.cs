using System.Reflection;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Abstractions.Evaluation;

public interface ITokenEvaluatorTypeCollection
{
    void Add(Type evaluatorType);
    void Add<TEvaluator, TToken>() 
        where TEvaluator : ITokenEvaluator<TToken> 
        where TToken : IToken;
    
    void AddFromAssembly(Assembly assembly);
    
    void Clear();
    
    IEnumerable<Type> GetAll();
}