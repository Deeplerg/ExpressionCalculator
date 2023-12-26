using System.Reflection;
using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Evaluation;

public class TokenEvaluatorTypeCollection : ITokenEvaluatorTypeCollection
{
    private List<Type> _evaluatorTypes = new();

    public void Add(Type evaluatorType)
    {
        _evaluatorTypes.Add(evaluatorType);
    }

    public void Add<TEvaluator, TToken>() where TEvaluator : ITokenEvaluator<TToken> where TToken : IToken
    {
        Add(typeof(TEvaluator));
    }

    public void AddFromAssembly(Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(EvaluatorFilter);

        foreach (var type in types)
        {
            Add(type);
        }
    }

    public void Clear()
    {
        _evaluatorTypes.Clear();
    }

    public IEnumerable<Type> GetAll()
    {
        return _evaluatorTypes;
    }

    private bool EvaluatorFilter(Type type)
    {
        return ImplementsITokenEvaluatorInterfaceFilter(type)
               && !type.IsAbstract
               && !type.IsInterface;
    }
    
    private bool ImplementsITokenEvaluatorInterfaceFilter(Type type)
    {
        return type.GetInterfaces()
            .Any(t => 
                t.IsGenericType 
                && t.GetGenericTypeDefinition() == typeof(ITokenEvaluator<>));
    }
}