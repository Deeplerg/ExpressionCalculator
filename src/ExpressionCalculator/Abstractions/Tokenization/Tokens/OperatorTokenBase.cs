namespace ExpressionCalculator.Abstractions.Tokenization.Tokens;

public abstract class OperatorTokenBase : IOperatorToken
{
    public OperatorTokenBase(int arity, int precedence, AssociativityType associativity)
    {
        Arity = arity;
        Precedence = precedence;
        Associativity = associativity;
    }
    
    public int Arity { get; }
    public int Precedence { get; }
    public AssociativityType Associativity { get; }
}