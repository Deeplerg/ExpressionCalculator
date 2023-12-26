using System.Reflection;
using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;

namespace ExpressionCalculator.Evaluation;

public class TokenEvaluatorInvoker : ITokenEvaluatorInvoker
{
    private delegate double EvaluateDelegate(IEnumerable<IToken> input);
    
    private readonly List<EvaluateDelegate> _evaluateDelegateCache = new();
    
    public TokenEvaluatorInvoker(ITokenEvaluatorProvider evaluatorProvider)
    {
        var evaluators = evaluatorProvider.GetAll().ToList();
        
        _evaluateDelegateCache.AddRange(GetEvaluateDelegates(evaluators));
    }
    
    public double Evaluate(object evaluator, IEnumerable<IToken> input)
    {
        var @delegate = _evaluateDelegateCache.FirstOrDefault(d => d.Target == evaluator);
        if (@delegate is null)
            throw new InvalidOperationException("Evaluator not found in cache");

        return @delegate(input);
    }

    private IEnumerable<EvaluateDelegate> GetEvaluateDelegates(IEnumerable<object> evaluators)
    {
        foreach (var evaluator in evaluators)
        {
            yield return GetEvaluateDelegate(evaluator);
        }
    }
    
    private EvaluateDelegate GetEvaluateDelegate(object evaluator)
    {
        string methodName = nameof(ITokenEvaluator<IToken>.Evaluate);

        var method = GetMethodInfoOrThrow(evaluator, methodName);
        
        return (EvaluateDelegate)method.CreateDelegate(typeof(EvaluateDelegate), evaluator);
    }
    
    private MethodInfo GetMethodInfoOrThrow(object evaluator, string methodName)
    {
        var type = evaluator.GetType();
        var method = type.GetMethod(methodName);
        
        if (method is null)
            throw new InvalidOperationException("Evaluator does not implement " + methodName);

        return method;
    }
}