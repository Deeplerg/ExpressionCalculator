using ExpressionCalculator.Abstractions.Evaluation;

namespace CustomPlugin.Sum;

public class SumTokenEvaluator : FunctionEvaluatorBase<SumToken>
{
    public SumTokenEvaluator() : base(argumentCount: 3)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        return arguments.Sum();
    }
}