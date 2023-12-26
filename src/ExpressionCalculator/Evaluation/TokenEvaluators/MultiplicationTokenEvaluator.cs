﻿using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class MultiplicationTokenEvaluator : BinaryOperationEvaluatorBase<MultiplicationToken>
{
    public override double Calculate(double left, double right)
    {
        return left * right;
    }
}