namespace ExpressionCalculator.Abstractions.Tokenization.Tokens;

public interface IOperatorToken : IToken
{
    int Arity { get; }
    int Precedence { get; }
    AssociativityType Associativity { get; }
}