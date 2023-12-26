using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators.Functions;

public class RootTokenEvaluator : FunctionEvaluatorBase<RootToken>
{
    public RootTokenEvaluator() : base(2)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double[] argumentsArray = arguments.ToArray();

        double argument = argumentsArray[0];
        double root = argumentsArray[1];

        return Math.Pow(argument, 1 / root);
    }
}