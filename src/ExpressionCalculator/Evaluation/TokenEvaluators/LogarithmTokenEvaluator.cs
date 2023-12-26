using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class LogarithmTokenEvaluator : FunctionEvaluatorBase<LogarithmToken>
{
    public LogarithmTokenEvaluator() : base(argumentCount: 2)
    {
    }
    
    public override double Calculate(IEnumerable<double> arguments)
    {
        double @base = arguments.First();
        double value = arguments.Last();

        return Math.Log(value, @base);
    }
}