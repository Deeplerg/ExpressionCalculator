using System.Text;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Tokenization;
using ExpressionCalculator.Tokenization.Tokens;

namespace CustomPlugin.UnknownVariable;

[ParsingPriority(300_000)]
public class UnknownVariableParser : ITokenParser<NumberToken>
{
    private readonly VariableValueStorage _variableValues;

    public UnknownVariableParser(VariableValueStorage variableValues)
    {
        _variableValues = variableValues;
    }
    
    public bool CanParse(StringSlice input)
    {
        char firstCharacter = input[0];
        return char.IsLetter(firstCharacter);
    }

    public TokenParsingResult<NumberToken> Parse(StringSlice currentInput)
    {
        var parseVariableResult = ParseVariableName(currentInput);

        int skippedCharacters = parseVariableResult.SkippedCharacters;
        string variableName = parseVariableResult.VariableName;

        double value;
        if (_variableValues.ContainsVariable(variableName))
        {
            value = _variableValues.GetValue(variableName);
        }
        else
        {
            value = RetrieveValue(variableName);
            _variableValues.AddOrSetValue(variableName, value);
        }
        
        var numberToken = new NumberToken(value);
        var parsingResult = new TokenParsingResult<NumberToken>(numberToken, skippedCharacters);
        return parsingResult;
    }
    
    private (int SkippedCharacters, string VariableName) ParseVariableName(StringSlice input)
    {
        var nameBuilder = new StringBuilder();
        
        bool encounteredLetter = false;
        int skippedCharacters = 0;
        
        foreach (var e in input)
        {
            if (!encounteredLetter)
            {
                if (char.IsLetter(e))
                {
                    encounteredLetter = true;
                }
                else
                {
                    throw new InvalidOperationException("Variable name must start with a letter.");
                }
            }

            if (char.IsLetterOrDigit(e))
            {
                nameBuilder.Append(e);
                skippedCharacters++;
            }
            else
            {
                break;
            }
        }
            
        return (skippedCharacters, nameBuilder.ToString());
    }

    private double RetrieveValue(string variableName)
    {
        string answer = AskUserOrQuit($"Enter value for variable {variableName}: ");
        return double.Parse(answer);
    }

    private string AskUserOrQuit(string whatToAsk)
    {
        Console.Write(whatToAsk);
        
        string? answer = Console.ReadLine();
        if (answer is null)
        {
            Environment.Exit(0);
        }

        return answer;
    }
}