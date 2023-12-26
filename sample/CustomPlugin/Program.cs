using System.Reflection;
using CustomPlugin.UnknownVariable;
using ExpressionCalculator;
using Microsoft.Extensions.DependencyInjection;

var calculatorBuilder = ExpressionCalculatorBuilder.Default;

calculatorBuilder.AddCustomServices(services =>
{
    services.AddSingleton<VariableValueStorage>();
});
calculatorBuilder.AddTokenParsersFromAssembly(Assembly.GetExecutingAssembly());

var calculator = calculatorBuilder.Build();

string expression = "5 + x + x2 + x2 + x3";
double result = calculator.Calculate(expression);
Console.WriteLine($"{expression} = {result}");