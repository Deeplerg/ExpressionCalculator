using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators.Functions;

public class SineTokenEvaluator : FunctionEvaluatorBase<SineToken>
{
    public SineTokenEvaluator() : base(1)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double value = arguments.Single();

        return Math.Sin(value);
    }
}