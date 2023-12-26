namespace ExpressionCalculator.Abstractions.Tokenization.Tokens;

public interface IValueToken<T> : IToken
{
    T Value { get; }
}