using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators.Functions;

public class TangentTokenEvaluator : FunctionEvaluatorBase<TangentToken>
{
    public TangentTokenEvaluator() : base(1)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double value = arguments.Single();

        return Math.Tan(value);
    }
}