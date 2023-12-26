using System.Reflection;
using ExpressionCalculator.Abstractions.Evaluation;
using ExpressionCalculator.Abstractions.Evaluation.ReversePolishNotation;
using ExpressionCalculator.Abstractions.ReversePolishNotation;
using ExpressionCalculator.Abstractions.Tokenization;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Abstractions.Tokenization.Tokens;
using ExpressionCalculator.Evaluation;
using ExpressionCalculator.Evaluation.ReversePolishNotation;
using ExpressionCalculator.ReversePolishNotation;
using ExpressionCalculator.Tokenization;
using ExpressionCalculator.Tokenization.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionCalculator;

public class ExpressionCalculatorBuilder
{
    private IServiceCollection _services;
    private IParserTypeCollection _parserCollection;
    private ITokenEvaluatorTypeCollection _evaluatorCollection;

    public ExpressionCalculatorBuilder()
    {
        _services = new ServiceCollection();
        _parserCollection = new PriorityBasedParserTypeCollection();
        _evaluatorCollection = new TokenEvaluatorTypeCollection();
    }

    public static ExpressionCalculatorBuilder Default
    {
        get
        {
            var builder = new ExpressionCalculatorBuilder();
            builder.AddDefaultInternalServices();
            return builder;
        }
    }
    
    public ExpressionCalculatorBuilder AddDefaultInternalServices()
    {
        AddTokenizationServices();
        AddReversePolishNotationConversion();
        AddEvaluationServices();
        
        return this;
    }
    
    public ExpressionCalculatorBuilder AddCustomServices(Action<IServiceCollection> configureServices)
    {
        configureServices(_services);
        
        return this;
    }
    
    public ExpressionCalculatorBuilder AddTokenParser(Type parserType)
    {
        _parserCollection.Add(parserType);
        return this;
    }
    
    public ExpressionCalculatorBuilder AddTokenParser<TParser, TToken>() 
        where TParser : ITokenParser<TToken> 
        where TToken : IToken
    {
        _parserCollection.Add<TParser, TToken>();
        return this;
    }
    
    public ExpressionCalculatorBuilder AddTokenParsersFromAssembly(Assembly assembly)
    {
        _parserCollection.AddFromAssembly(assembly);
        return this;
    }
    
    public ExpressionCalculatorBuilder AddTokenEvaluator(Type evaluatorType)
    {
        _evaluatorCollection.Add(evaluatorType);
        return this;
    }
    
    public ExpressionCalculatorBuilder AddTokenEvaluator<TEvaluator, TToken>() 
        where TEvaluator : ITokenEvaluator<TToken> 
        where TToken : IToken
    {
        _evaluatorCollection.Add<TEvaluator, TToken>();
        return this;
    }
    
    public ExpressionCalculatorBuilder AddTokenEvaluatorsFromAssembly(Assembly assembly)
    {
        _evaluatorCollection.AddFromAssembly(assembly);
        return this;
    }

    public ExpressionCalculator Build()
    {
        _services.AddSingleton<IParserTypeCollection>(_ => _parserCollection);
        _services.AddSingleton<ITokenEvaluatorTypeCollection>(_ => _evaluatorCollection);
        
        var serviceProvider = _services.BuildServiceProvider();

        var expressionCalculator = new ExpressionCalculator(serviceProvider);
        return expressionCalculator;
    }
    
    private ExpressionCalculatorBuilder AddTokenizationServices()
    {
        PopulateParserCollection(_parserCollection);
        
        _services.AddSingleton<IParserProvider, ParserProvider>();
        _services.AddSingleton<IParserInvoker, ParserInvoker>();
        _services.AddSingleton<ILexer, Lexer>();

        return this;
    }

    private ExpressionCalculatorBuilder AddReversePolishNotationConversion()
    {
        _services.AddTransient<IInfixToPostfixConverter, ShuntingYardInfixToPostfixConverter>();
        return this;
    }

    private ExpressionCalculatorBuilder AddEvaluationServices()
    {
        PopulateEvaluatorCollection(_evaluatorCollection);
        
        _services.AddSingleton<ITokenEvaluatorProvider, TokenEvaluatorProvider>();
        _services.AddSingleton<ITokenEvaluatorInvoker, TokenEvaluatorInvoker>();
        _services.AddSingleton<IPostfixEvaluator, PostfixEvaluator>();
        
        AddServicesForEvaluators();
        
        return this;
    }

    private void AddServicesForEvaluators()
    {
        _services.AddSingleton<FactorialCache>();
    }
    
    private void PopulateEvaluatorCollection(ITokenEvaluatorTypeCollection evaluatorCollection)
    {
        var assembly = GetInternalAssembly();
        evaluatorCollection.AddFromAssembly(assembly);
    }
    
    private void PopulateParserCollection(IParserTypeCollection parserCollection)
    {
        var assembly = GetInternalAssembly();
        parserCollection.AddFromAssembly(assembly);
    }
    
    private Assembly GetInternalAssembly()
    {
        return Assembly.GetAssembly(typeof(ExpressionCalculatorBuilder));
    }
}