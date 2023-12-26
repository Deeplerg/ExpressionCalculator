using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Abstractions.Evaluation.ReversePolishNotation;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Evaluation.ReversePolishNotation;

public class PostfixEvaluator(
        ITokenEvaluatorProvider _evaluatorProvider,
        ITokenEvaluatorInvoker _evaluatorInvoker)
    : IPostfixEvaluator
{
    public double Evaluate(IEnumerable<IToken> postfixTokens)
    {
        var stack = new Stack<IToken>();
        
        foreach (var token in postfixTokens)
        {
            if (token is NumberToken numberToken)
            {
                stack.Push(numberToken);
            }
            else if (token is IOperatorToken operatorToken)
            {
                int arity = operatorToken.Arity;
                var evaluator = _evaluatorProvider.GetEvaluatorForToken(operatorToken.GetType());
                
                if(stack.Count < arity)
                {
                    throw new InvalidOperationException(
                        "Not enough operands for operator " + operatorToken.GetType().Name);
                }
                
                var operands = new List<IToken>();
                for (int i = 0; i < arity; i++)
                {
                    var operand = stack.Pop();
                    
                    operands.Insert(0, operand);
                }

                double result = _evaluatorInvoker.Evaluate(evaluator, operands);
                stack.Push(new NumberToken(result));
            }
            else if (token is IFunctionToken functionToken)
            {
                int? argumentCount = functionToken.ArgumentCount;
                var evaluator = _evaluatorProvider.GetEvaluatorForToken(functionToken.GetType());
                
                if(argumentCount is not null && stack.Count < argumentCount)
                {
                    throw new InvalidOperationException(
                        "Not enough arguments for function " + functionToken.GetType().Name);
                }
                
                var arguments = new List<IToken>();
                for (int i = 0; i < argumentCount; i++)
                {
                    var argument = stack.Pop();
                    
                    arguments.Insert(0, argument);
                }

                double result = _evaluatorInvoker.Evaluate(evaluator, arguments);
                stack.Push(new NumberToken(result));
            }
        }

        if (stack.Count != 1 || stack.Peek() is not NumberToken resultToken)
        {
            throw new InvalidOperationException("Invalid postfix expression");
        }
        
        return resultToken.Value;
    }
}