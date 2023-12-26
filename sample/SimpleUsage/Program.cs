using ExpressionCalculator;

var calculatorBuilder = ExpressionCalculatorBuilder.Default;
var calculator = calculatorBuilder.Build();

// works
//string expression = "(2 + sin(pi/3) * log(2; e^3) - tan(45*deg)) / (4! + ln(e^2) / sqrt(25) - cos(pi/4)^2) ^ (1/2)";

// works
//string expression = "sin(cos(tan(2^3))) + log(e^(sin(pi/4)); sqrt(1 + tan(pi/6)^2)) / (1 + cos(2 * pi/3))";

// works
string expression = "4+4*2/(1-5) + 3!! + log(3; 9*(3+6)) + lg(100)";

double result = calculator.Calculate(expression);

Console.WriteLine($"{expression} = {result}");