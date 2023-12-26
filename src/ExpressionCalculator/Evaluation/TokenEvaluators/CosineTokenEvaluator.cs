using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class CosineTokenEvaluator : FunctionEvaluatorBase<CosineToken>
{
    public CosineTokenEvaluator() : base(1)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double value = arguments.Single();

        return Math.Cos(value);
    }
}