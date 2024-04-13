using System.Globalization;
using System.Text;
using ExpressionCalculator.Abstractions.Tokenization.Parsing;
using ExpressionCalculator.Exceptions;
using ExpressionCalculator.Tokenization.Tokens;

namespace ExpressionCalculator.Tokenization.Parsers;

[ParsingPriority(2_000_000)]
public class NumberTokenParser : ITokenParser<NumberToken>
{
    private readonly string _separator;
    
    public NumberTokenParser()
    {
        _separator = GetSeparator();
    }
    
    public bool CanParse(StringSlice input)
    {
        if (input.Length == 0)
            return false;

        return StartsWithInteger(input) || StartsWithSeparatorAndDigit(input);
    }

    public TokenParsingResult<NumberToken> Parse(StringSlice currentInput)
    {
        StringBuilder number = new();
        int charactersSkipped = 0;
        bool wasSeparatorParsed = false;
        
        if (TryParseSeparator(currentInput, out ParsingResult? beginsWithSeparatorResult))
        {
            number.Append("0");
            number.Append(beginsWithSeparatorResult!.Result);
            
            charactersSkipped += beginsWithSeparatorResult.CharactersSkipped;
            wasSeparatorParsed = true;
        }

        int i = charactersSkipped;
        var sliceFromCurrentPosition = new StringSlice(currentInput, i);
        for ( ; i < currentInput.Length; i = charactersSkipped)
        {
            sliceFromCurrentPosition.FromIndex += i;
            
            if (TryParseSeparator(sliceFromCurrentPosition, out ParsingResult? separatorResult))
            {
                if(wasSeparatorParsed)
                    throw new NumberTokenParsingException("Number cannot contain more than one separator");
                
                number.Append(separatorResult!.Result);
                charactersSkipped += separatorResult.CharactersSkipped;
                wasSeparatorParsed = true;
                
                continue;
            }
            
            if (TryParseDigits(sliceFromCurrentPosition, out ParsingResult? digitsResult))
            {
                number.Append(digitsResult!.Result);
                charactersSkipped += digitsResult.CharactersSkipped;
                
                continue;
            }
            
            break;
        }

        if (charactersSkipped == 0)
            throw new NumberTokenParsingException("Couldn't parse the number.");

        double parsedNumber = double.Parse(number.ToString());
        
        return new TokenParsingResult<NumberToken>(
            new NumberToken(parsedNumber),
            charactersSkipped);
    }

    private bool StartsWithInteger(StringSlice input)
        => char.IsDigit(input[0]);

    private bool StartsWithSeparatorAndDigit(StringSlice input)
    {
        string separator = _separator;
        char? firstCharacterAfterSeparator = null;
        if (input.Length > separator.Length)
            firstCharacterAfterSeparator = input[separator.Length];

        return StartsWithSeparator(input)
               && firstCharacterAfterSeparator is not null
               && char.IsDigit(firstCharacterAfterSeparator.Value);
    }

    private bool StartsWithSeparator(StringSlice input)
    {
        string separator = _separator;

        return input.StartsWith(separator);
    }

    private string GetSeparator()
        => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    
    /// <param name="input"><see cref="StringSlice"/> that begins with a separator</param>
    private bool TryParseSeparator(StringSlice input, out ParsingResult? result)
    {
        if (StartsWithSeparator(input))
        {
            string separator = _separator;

            result = new ParsingResult(
                Result: new StringBuilder(separator),
                CharactersSkipped: separator.Length);
            
            return true;
        }

        result = null;
        return false;
    }

    /// <param name="input"><see cref="StringSlice"/> that begins with a digit</param>
    private bool TryParseDigits(StringSlice input, out ParsingResult? result)
    {
        if (!StartsWithInteger(input))
        {
            result = null;
            return false;
        }
        
        var builder = new StringBuilder();
        
        for (int i = 0; i < input.Length; i++)
        {
            char element = input[i];

            if (char.IsDigit(element))
                builder.Append(element);
            else
                break;
        }
        
        result = new ParsingResult(
            Result: builder,
            CharactersSkipped: builder.Length);
        return true;
    }

    private record class ParsingResult(
        StringBuilder Result,
        int CharactersSkipped);
}