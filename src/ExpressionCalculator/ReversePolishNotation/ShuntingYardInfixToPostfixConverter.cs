using ExpressionCalculator.Abstractions.ReversePolishNotation;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.ReversePolishNotation;

public class ShuntingYardInfixToPostfixConverter : IInfixToPostfixConverter
{
    public IEnumerable<IToken> Convert(IEnumerable<IToken> tokens)
    {
        var operations = new Stack<IToken>();
        var output = new List<IToken>();

        foreach (var token in tokens)
        {
            if (token is IOperatorToken operatorToken)
            {
                while (operations.Count > 0)
                {
                    var top = operations.Peek();
                    if (top is IOperatorToken topOperatorToken &&
                        (operatorToken.Associativity == AssociativityType.Left && operatorToken.Precedence <= topOperatorToken.Precedence ||
                         operatorToken.Associativity == AssociativityType.Right && operatorToken.Precedence < topOperatorToken.Precedence))
                    {
                        output.Add(operations.Pop());
                    }
                    else
                    {
                        break;
                    }
                }

                operations.Push(token);
            }
            else if (token is LeftBracketToken)
            {
                operations.Push(token);
            }
            else if (token is RightBracketToken)
            {
                while (operations.Count > 0 && !(operations.Peek() is LeftBracketToken))
                {
                    output.Add(operations.Pop());
                }

                if (operations.Count == 0)
                {
                    throw new InvalidOperationException("Mismatched brackets");
                }

                operations.Pop();
            }
            else
            {
                output.Add(token);
            }
        }
        
        output.AddRange(operations);

        return output;
    }
}