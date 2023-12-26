using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class NaturalLogarithmTokenEvaluator : FunctionEvaluatorBase<NaturalLogarithmToken>
{
    public NaturalLogarithmTokenEvaluator() : base(1)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double value = arguments.Single();

        return Math.Log(value);
    }
}