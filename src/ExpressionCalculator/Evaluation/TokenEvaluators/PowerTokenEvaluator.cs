using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class PowerTokenEvaluator : BinaryOperationEvaluatorBase<PowerToken>
{
    public override double Calculate(double left, double right)
    {
        return Math.Pow(left, right);
    }
}