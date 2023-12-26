using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionCalculator.Evaluation;

public class TokenEvaluatorProvider : ITokenEvaluatorProvider
{
    private readonly List<object> _evaluators = new();

    public TokenEvaluatorProvider(
        ITokenEvaluatorTypeCollection evaluatorTypes,
        IServiceProvider serviceProvider)
    {
        var activatedEvaluators = ActivateEvaluators(evaluatorTypes.GetAll(), serviceProvider);
        _evaluators.AddRange(activatedEvaluators);
    }
    
    public IEnumerable<object> GetAll()
    {
        return _evaluators;
    }

    public ITokenEvaluator<IToken> GetEvaluatorForToken<TToken>() where TToken : IToken
    {
        return (ITokenEvaluator<IToken>)GetEvaluatorForToken(typeof(IToken));
    }

    public object GetEvaluatorForToken(Type tokenType)
    {
        return _evaluators.First(t => EvaluatorForTokenFilter(t, tokenType));
    }

    public object GetEvaluator(Type evaluatorType)
    {
        return _evaluators.First(t => t.GetType() == evaluatorType);
    }
    
    private IEnumerable<object> ActivateEvaluators(IEnumerable<Type> evaluatorTypes, IServiceProvider serviceProvider)
    {
        foreach (var type in evaluatorTypes)
        {
            yield return ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, type);
        }
    }

    private bool EvaluatorForTokenFilter(object evaluator, Type tokenType)
    {
        var evaluatorType = evaluator.GetType();
        
        return evaluatorType.IsAssignableTo(typeof(ITokenEvaluator<>).MakeGenericType(tokenType));
    }
}