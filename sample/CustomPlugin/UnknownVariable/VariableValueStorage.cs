namespace CustomPlugin.UnknownVariable;

public class VariableValueStorage
{
    private readonly Dictionary<string, double> _variables = new();

    public bool ContainsVariable(string variableName)
    {
        return _variables.ContainsKey(variableName);
    }
    
    public double GetValue(string variableName)
    {
        return _variables[variableName];
    }
    
    public void AddOrSetValue(string variableName, double value)
    {
        if(ContainsVariable(variableName))
        {
            _variables[variableName] = value;
        }
        else
        {
            _variables.Add(variableName, value);
        }
    }
}