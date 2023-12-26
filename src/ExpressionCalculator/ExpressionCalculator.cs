using ExpressionCalculator.Abstractions.Evaluation.ReversePolishNotation;
using ExpressionCalculator.Abstractions.ReversePolishNotation;
using ExpressionCalculator.Abstractions.Tokenization;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Evaluation.ReversePolishNotation;
using ExpressionCalculator.ReversePolishNotation;
using ExpressionCalculator.Tokenization;
using ExpressionCalculator.Tokenization.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionCalculator;

public class ExpressionCalculator
{
    private readonly ILexer _lexer;
    private readonly IInfixToPostfixConverter _infixToPostfixConverter;
    private readonly IPostfixEvaluator _postfixEvaluator;
    
    internal ExpressionCalculator(IServiceProvider serviceProvider)
    {
        _lexer = serviceProvider.GetRequiredService<ILexer>();
        _infixToPostfixConverter = serviceProvider.GetRequiredService<IInfixToPostfixConverter>();
        _postfixEvaluator = serviceProvider.GetRequiredService<IPostfixEvaluator>();
    }
    
    public double Calculate(string input, CalculationStrategy strategy = CalculationStrategy.ReversePolishNotation)
    {
        return strategy switch
        {
            CalculationStrategy.ReversePolishNotation => CalculateReversePolishNotation(input),
            _ => throw new ArgumentOutOfRangeException(nameof(strategy), strategy, "Unknown calculation strategy")
        };
    }
    
    public IEnumerable<IToken> ConvertToReversePolishNotation(string input)
    {
        var infixTokens= _lexer.Tokenize(input);
        var postfixTokens = _infixToPostfixConverter.Convert(infixTokens);
        
        return postfixTokens;
    }
    
    private double CalculateReversePolishNotation(string input)
    {
        var postfixTokens = ConvertToReversePolishNotation(input);
        return _postfixEvaluator.Evaluate(postfixTokens);
    }
}