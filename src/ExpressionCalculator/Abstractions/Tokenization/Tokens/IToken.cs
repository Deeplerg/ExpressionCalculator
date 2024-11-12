namespace ExpressionCalculator.Abstractions.Tokenization.Tokens;

public interface IToken
{
    // can't enforce ToString without an abstract class
    string GetStringRepresentation();
}