using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.InvocationUtilities;

namespace ExpressionCalculator.Evaluation;

public class TokenEvaluatorInvoker : ITokenEvaluatorInvoker
{
    private delegate double EvaluateDelegate(IEnumerable<IToken> input);
    
    private readonly DelegateCache<EvaluateDelegate> _evaluateDelegateCache = new();
    
    public TokenEvaluatorInvoker(ITokenEvaluatorProvider evaluatorProvider)
    {
        var evaluators = evaluatorProvider.GetAll().ToList();
        
        _evaluateDelegateCache.AddDelegates(CreateEvaluateDelegates(evaluators));
    }
    
    public double Evaluate(object evaluator, IEnumerable<IToken> input)
    {
        var @delegate = _evaluateDelegateCache.FindDelegate(evaluator);

        return @delegate(input);
    }
    
    private IEnumerable<EvaluateDelegate> CreateEvaluateDelegates(IEnumerable<object> targets)
    {
        string methodName = nameof(ITokenEvaluator<IToken>.Evaluate);
        return DelegateCreationHelper.CreateDelegates<EvaluateDelegate>(targets, methodName);
    }
}