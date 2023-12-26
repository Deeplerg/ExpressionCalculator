using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Functions;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class SquareRootTokenEvaluator : FunctionEvaluatorBase<SquareRootToken>
{
    public SquareRootTokenEvaluator() : base(1)
    {
    }

    public override double Calculate(IEnumerable<double> arguments)
    {
        double argument = arguments.Single();
        
        return Math.Sqrt(argument);
    }
}