using System.Reflection;
using ExpressionCalculator.Abstractions.Tokenization;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionCalculator.Tokenization;

public class PriorityBasedParserTypeCollection : IParserTypeCollection
{
    private readonly int _defaultParsingPriority;
    private LinkedList<Type> _parserTypes = new();

    public PriorityBasedParserTypeCollection(int defaultParsingPriority = 10_000_000)
    {
        _defaultParsingPriority = defaultParsingPriority;
    }

    public void Add(Type parserType)
    {
        int priority = GetPriority(parserType);
        
        foreach(var node in _parserTypes)
        {
            var nodePriority = GetPriority(node);

            if (priority < nodePriority)
            {
                _parserTypes.AddBefore(_parserTypes.Find(node)!, parserType);
                return;
            }
            
            if (nodePriority == priority)
            {
                _parserTypes.AddAfter(_parserTypes.Find(node)!, parserType);
                return;
            }
        }
        
        _parserTypes.AddLast(parserType);
    }

    public void Add<TParser, TToken>() where TParser : ITokenParser<TToken> where TToken : IToken
    {
        Add(typeof(TParser));
    }

    public void AddFromAssembly(Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(ParserFilter);

        foreach (var type in types)
        {
            Add(type);
        }
    }

    public void Clear()
    {
        _parserTypes.Clear();
    }

    public IEnumerable<Type> GetAll()
    {
        return _parserTypes.Reverse();
    }

    private bool ParserFilter(Type type)
    {
        return ImplementsITokenParserInterfaceFilter(type)
               && !type.IsAbstract
               && !type.IsInterface;
    }
    
    private bool ImplementsITokenParserInterfaceFilter(Type type)
    {
        return type.GetInterfaces()
            .Any(t => 
                t.IsGenericType 
                && t.GetGenericTypeDefinition() == typeof(ITokenParser<>));
    }

    private int GetPriority(Type type)
    {
        if (type == typeof(object) || type.BaseType is null)
            return _defaultParsingPriority;
        
        var priorityAttributeType = typeof(ParsingPriorityAttribute);

        var attributeData = type
            .GetCustomAttributesData()
            .FirstOrDefault(d => d.AttributeType == priorityAttributeType);

        if (attributeData is not null)
        {
            return GetPriorityFromAttribute(attributeData);
        }
        
        return GetPriority(type.BaseType);
    }
    
    private int GetPriorityFromAttribute(CustomAttributeData attributeData)
    {
        var constructorArguments = attributeData.ConstructorArguments;
        var firstArgument = constructorArguments.First();
        return (int)firstArgument.Value!;
    }
}