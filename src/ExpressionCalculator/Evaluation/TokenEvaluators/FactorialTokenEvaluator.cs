using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Tokenization.Tokens.Operators;

namespace ExpressionCalculator.Evaluation.TokenEvaluators;

public class FactorialTokenEvaluator(
        FactorialCache _cache)
    : UnaryOperationEvaluatorBase<FactorialToken>
{
    public override double Calculate(double value)
    {
        if (value == 0)
            return 1;
        
        if (value < 0)
            throw new ArgumentException("Cannot calculate factorial for negative numbers.");
        
        // Dirty. Could use Math.NET and gamma function to approximate factorial for non-integers.
        value = TruncateOrThrow(value);

        if(_cache.Contains(value))
            return _cache.Get(value);
        
        double result = 1;
        for (double i = 1; i <= value; i++)
        {
            if (_cache.Contains(i))
            {
                result = _cache.Get(i);
            }
            else
            {
                result *= i;
                _cache.Add(i, result);
            }
        }
        
        return result;
    }

    private double TruncateOrThrow(double value)
    {
        double truncatedValue = Math.Truncate(value);
        
        if(truncatedValue != value)
            throw new ArgumentException("Can only calculate factorial for integers.");

        return truncatedValue;
    }
}