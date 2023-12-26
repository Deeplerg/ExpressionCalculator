namespace ExpressionCalculator.Tokenization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class ParsingPriorityAttribute : Attribute
{
    public int Priority { get; }

    public ParsingPriorityAttribute(int priority)
    {
        Priority = priority;
    }
}