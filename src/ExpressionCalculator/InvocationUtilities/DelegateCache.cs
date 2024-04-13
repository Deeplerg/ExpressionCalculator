using System.Reflection;

namespace ExpressionCalculator.InvocationUtilities;

public class DelegateCache<T> where T : Delegate
{
    private readonly List<T> _delegates = new();

    public void AddDelegates(IEnumerable<T> delegates)
    {
        _delegates.AddRange(delegates);
    }
    
    public void AddDelegate(T @delegate)
    {
        _delegates.Add(@delegate);
    }

    public T FindDelegate(object instance)
    {
        if(!TryFindDelegate(instance, out T? @delegate))
            throw new InvalidOperationException("Suitable delegate not found in cache");
        
        return @delegate!;
    }

    public bool TryFindDelegate(object instance, out T? @delegate)
    {
        @delegate = null;
        foreach (T d in _delegates)
        {
            if (d.Target != instance) continue;

            @delegate = d;
            return true;
        }
        
        return false;
    }
    
    private MethodInfo GetMethodInfoOrThrow(object target, string methodName)
    {
        var type = target.GetType();
        var method = type.GetMethod(methodName);
        
        if (method is null)
            throw new InvalidOperationException("Delegate target does not implement " + methodName);

        return method;
    }
}