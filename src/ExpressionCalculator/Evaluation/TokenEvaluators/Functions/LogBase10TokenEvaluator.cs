using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators.Functions;

public class LogBase10TokenEvaluator : FunctionEvaluatorBase<LogBase10Token>
{
    public LogBase10TokenEvaluator() : base(1)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double value = arguments.Single();

        return Math.Log10(value);
    }
}