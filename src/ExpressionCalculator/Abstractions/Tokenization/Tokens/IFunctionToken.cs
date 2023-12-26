namespace ExpressionCalculator.Abstractions.Tokenization.Tokens;

public interface IFunctionToken : IToken
{
    int? ArgumentCount { get; }
}