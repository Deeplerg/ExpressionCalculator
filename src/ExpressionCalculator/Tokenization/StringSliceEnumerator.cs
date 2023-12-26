using System.Collections;

namespace ExpressionCalculator.Tokenization;

internal class StringSliceEnumerator : IEnumerator<char>
{
    private const int resetPosition = -1;
    
    /// <summary>
    /// Refers to the current index in the slice, not in <see cref="_source"/>
    /// </summary>
    private int position = resetPosition;
    
    private readonly string _source;
    private readonly int _fromIndex;
    private readonly int _toIndex;
    
    /// <summary>
    /// Supports iterating over a specific part of a <see cref="String"/>
    /// </summary>
    /// <param name="source">The source string to slice</param>
    /// <param name="fromIndex">Inclusive lower bound</param>
    /// <param name="toIndex">Exclusive upper bound</param>
    public StringSliceEnumerator(string source, int fromIndex, int toIndex)
    {
        _source = source;
        _fromIndex = fromIndex;
        _toIndex = toIndex;
    }
    
    public void Reset()
    {
        position = resetPosition;
    }
    
    public bool MoveNext()
    {
        position++;
        
        int sliceLength = _toIndex - _fromIndex;
        bool wasSuccessful = position < sliceLength;
        
        return wasSuccessful;
    }

    public char Current
    {
        get
        {
            int sliceLength = _toIndex - _fromIndex;
            if (position >= sliceLength)
                throw new InvalidOperationException("Enumeration already finished.");
            
            if (position == resetPosition)
                throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");
        
            return _source[position + _fromIndex];
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        // nothing to dispose
    }
}