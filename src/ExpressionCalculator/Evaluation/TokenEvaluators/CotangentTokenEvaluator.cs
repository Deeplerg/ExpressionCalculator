using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class CotangentTokenEvaluator : FunctionEvaluatorBase<CotangentToken>
{
    public CotangentTokenEvaluator() : base(1)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double value = arguments.Single();

        return 1 / Math.Tan(value);
    }
}