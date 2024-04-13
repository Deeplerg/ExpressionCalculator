using System.Reflection;

namespace ExpressionCalculator.InvocationUtilities;

public class DelegateCreationHelper
{
    public static IEnumerable<T> CreateDelegates<T>(IEnumerable<object> targets, string methodName)
        where T : Delegate
    {
        foreach (var target in targets)
        {
            yield return CreateDelegate<T>(target, methodName);
        }
    }
    
    public static T CreateDelegate<T>(object target, string methodName)
        where T : Delegate
    {
        var method = GetMethodInfoOrThrow(target, methodName);

        return (T)method.CreateDelegate(typeof(T), target);
    }
    
    private static MethodInfo GetMethodInfoOrThrow(object target, string methodName)
    {
        var type = target.GetType();
        var method = type.GetMethod(methodName);
        
        if (method is null)
            throw new InvalidOperationException("Delegate target does not implement " + methodName);

        return method;
    }
}