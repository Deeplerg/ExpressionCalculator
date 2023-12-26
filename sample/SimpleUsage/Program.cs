using ExpressionCalculator;

var calculatorBuilder = ExpressionCalculatorBuilder.Default;
var calculator = calculatorBuilder.Build();

string expression = "4+4*2/(1-5) + 5!";
double result = calculator.Calculate(expression);

Console.WriteLine($"{expression} = {result}");