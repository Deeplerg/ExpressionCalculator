using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Evaluation.TokenEvaluators.Operations;

public class AdditionTokenEvaluator : BinaryOperationEvaluatorBase<AdditionToken>
{
    public override double Calculate(double left, double right)
    {
        return left + right;
    }
}