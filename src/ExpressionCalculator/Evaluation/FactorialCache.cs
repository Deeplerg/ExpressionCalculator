namespace ExpressionCalculator.Evaluation;

public class FactorialCache
{
    private readonly Dictionary<double, double> _cache = new();

    public double Get(double number)
    {
        return _cache[number];
    }

    public bool Contains(double number)
    {
        return _cache.ContainsKey(number);
    }
    
    public void Add(double number, double factorial)
    {
        _cache.Add(number, factorial);
    }
}