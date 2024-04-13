using System.Collections;

namespace ExpressionCalculator.Tokenization;

/// <summary>
/// Supports iterating over a specific part of a <see cref="String"/>
/// Better than iterating over a <see cref="String"/> sliced with Substring
/// because <see cref="StringSlice"/> doesn't allocate a copy of the sliced <see cref="String"/>
/// and instead holds a reference to it.
/// </summary>
public class StringSlice : IEnumerable<char>
{
    private readonly string _source;
    private int _toIndex;
    private int _fromIndex;
    private int _length;

    /// <param name="source">The source string to slice</param>
    /// <param name="fromIndex">Inclusive lower bound</param>
    /// <param name="toIndex">Exclusive upper bound</param>
    public StringSlice(string source, int fromIndex, int toIndex)
    {
        _length = toIndex - fromIndex;
        if (_length < 0)
        {
            throw new InvalidOperationException($"Length must be a non-negative value. " +
                                                $"Actual value: {_length}");
        }

        _source = source;
        _fromIndex = fromIndex;
        _toIndex = toIndex;

        if (_toIndex > _source.Length)
        {
            throw new InvalidOperationException(
                $"{nameof(toIndex)} must be less than or equal to the length of the source string. " +
                $"Actual value: {_toIndex}");
        }
        if (_fromIndex < 0)
        {
            throw new InvalidOperationException(
                $"{nameof(fromIndex)} must be greater than or equal to 0. Actual value: {_fromIndex}");
        }
    }

    /// <summary>
    /// Slice a <see cref="StringSlice"/> (again).
    /// </summary>
    /// <param name="slice">The <see cref="StringSlice"/> to slice</param>
    /// <param name="fromIndex">Inclusive lower bound (in the slice, not in the source string)</param>
    /// <param name="toIndex">Exclusive upper bound (in the slice, not in the source string)</param>
    public StringSlice(StringSlice slice, int fromIndex, int toIndex)
        : this(
            source: slice._source,
            fromIndex: slice._fromIndex + fromIndex,
            toIndex: slice._fromIndex + toIndex)
    {
    }
    
    /// <summary>
    /// Slice a <see cref="StringSlice"/> (again).
    /// </summary>
    /// <param name="slice">The <see cref="StringSlice"/> to slice</param>
    /// <param name="fromIndex">Inclusive lower bound (in the slice, not in the source string)</param>
    public StringSlice(StringSlice slice, int fromIndex)
        : this(
            source: slice._source,
            fromIndex: slice._fromIndex + fromIndex,
            toIndex: slice._toIndex)
    {
    }
    
    public StringSlice(string source)
        : this(source, fromIndex: 0, toIndex: source.Length)
    {
    }

    //public int Length => _toIndex - _fromIndex;
    
    /// <summary>
    /// Length of the slice
    /// </summary>
    public int Length => _length;

    public int FromIndex
    {
        get => _fromIndex;
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException(
                    $"{nameof(FromIndex)} must be greater than or equal to 0. Actual value: {value}");
            }
            
            if(value > _toIndex)
            {
                throw new InvalidOperationException(
                    $"{nameof(FromIndex)} must be less than or equal to {nameof(ToIndex)}. " +
                    $"Actual value: {value}");
            }
            
            _fromIndex = value;
            _length = _toIndex - _fromIndex;
        }
    }
    
    public int ToIndex
    {
        get => _toIndex;
        set
        {
            if (value > _source.Length)
            {
                throw new InvalidOperationException(
                    $"{nameof(ToIndex)} must be less than or equal to the length of the source string. " +
                    $"Actual value: {value}");
            }
            
            if(value < _fromIndex)
            {
                throw new InvalidOperationException(
                    $"{nameof(ToIndex)} must be greater than or equal to {nameof(FromIndex)}. " +
                    $"Actual value: {value}");
            }
            
            _toIndex = value;
            _length = _toIndex - _fromIndex;
        }
    }
    
    public IEnumerator<char> GetEnumerator()
    {
        return new StringSliceEnumerator(_source, fromIndex: _fromIndex, toIndex: _toIndex);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public char this[int i]
    {
        get
        {
            if (i < 0 || i >= Length)
            {
                throw new IndexOutOfRangeException($"Index must be between 0 and {Length - 1}. " +
                                                   $"Actual value: {i}");
            }

            return _source[_fromIndex + i];
        }
    }
    
    public bool StartsWith(string value)
    {
        for (int i = 0; i < value.Length; i++)
        {
            if (this[i] != value[i])
                return false;
        }

        return true;
    }
    
    public bool StartsWith(char value)
    {
        return this[0] == value;
    }

    /// <summary>
    /// Returns the index of the first occurrence of <paramref name="value"/> in the slice.
    /// If the slice doesn't contain <paramref name="value"/>, returns -1.
    /// </summary>
    /// <param name="value"> The value to search for. </param>
    /// <returns>
    /// The index of the first occurrence of <paramref name="value"/> in the slice.
    /// If the slice doesn't contain <paramref name="value"/>, returns -1.
    ///  </returns>
    public int IndexOf(char value)
    {
        for (int i = 0; i < Length; i++)
        {
            if (this[i] == value)
                return i;
        }
        
        return -1;
    }

    public override string ToString()
    {
        return _source[_fromIndex.._toIndex];
    }
}