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
            HandleToken(token, operations, output);
        }
        
        output.AddRange(operations);

        return output;
    }

    private void HandleToken(IToken token, Stack<IToken> operations, List<IToken> output)
    {
        switch (token)
        {
            case IOperatorToken operatorToken:
                HandleOperatorToken(operatorToken, operations, output);
                break;
                
            case IFunctionToken:
                operations.Push(token);
                break;
                
            case ArgumentSeparatorToken:
                HandleArgumentSeparatorToken(operations, output);
                break;
                
            case LeftBracketToken:
                operations.Push(token);
                break;
                
            case RightBracketToken:
                HandleRightBracketToken(operations, output);
                break;
                
            default:
                output.Add(token);
                break;
        }
    }

    private void HandleOperatorToken(IOperatorToken operatorToken, Stack<IToken> operations, List<IToken> output)
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

        operations.Push(operatorToken);
    }
    
    private void HandleArgumentSeparatorToken(Stack<IToken> operations, List<IToken> output)
    {
        while (operations.Count > 0 && !(operations.Peek() is LeftBracketToken))
        {
            output.Add(operations.Pop());
        }

        if (operations.Count == 0)
        {
            throw new InvalidOperationException("Mismatched brackets");
        }
    }
    
    private void HandleRightBracketToken(Stack<IToken> operations, List<IToken> output)
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
                
        if (operations.Count > 0 && operations.Peek() is IFunctionToken)
        {
            output.Add(operations.Pop());
        }
    }
}