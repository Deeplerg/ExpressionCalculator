using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class DivisionTokenEvaluator : BinaryOperationEvaluatorBase<DivisionToken>
{
    public override double Calculate(double left, double right)
    {
        return left / right;
    }
}