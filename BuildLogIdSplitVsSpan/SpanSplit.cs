using System;

public static class ReadOnlySpanSplit
{
    /// <summary>Splits <paramref name="span"/> by first occurrence of <paramref name="divisor"/>.</summary>
    /// <remarks>If <paramref name="divisor"/> is not found, the first span will extend to the end, and the remaining
    /// section will be empty. <paramref name="divisor"/> will not be included in the splits.</remarks>
    /// <param name="span">The span to split.</param>
    /// <param name="divisor">The value at which to split <paramref name="span"/>.</param>
    /// <typeparam name="T">The type of values in the span.</typeparam>
    /// <returns>A <see cref="ReadOnlySpanSplit{T}"/> containing the split of the spans.</returns>
    public static ReadOnlySpanSplit<T> SplitFirst<T>(this ReadOnlySpan<T> span, T divisor) where T : IEquatable<T>
        => CreateSplit(span, span.IndexOf(divisor), 1);

    /// <inheritdoc cref="SplitFirst{T}(ReadOnlySpan{T}, T)"/>
    /// <remarks>If <paramref name="divisor"/> is not found, the first span will extend to the end, and the remaining
    /// section will be empty.<para/>
    /// <paramref name="divisor"/> will not be included in the splits.<para/>
    /// If <paramref name="divisor"/> is empty, it is treated as if the divisor was found at index 0.</remarks>
    public static ReadOnlySpanSplit<T> SplitFirst<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> divisor)
        where T : IEquatable<T>
        => CreateSplit(span, span.IndexOf(divisor), divisor.Length);

    /// <inheritdoc cref="SplitFirst{T}(ReadOnlySpan{T}, T)"/>
    /// <summary>Splits <paramref name="span"/> by the last occurrence of <paramref name="divisor"/>.</summary>
    public static ReadOnlySpanSplit<T> SplitLast<T>(this ReadOnlySpan<T> span, T divisor) where T : IEquatable<T>
        => CreateSplit(span, span.LastIndexOf(divisor), 1);

    /// <inheritdoc cref="SplitLast{T}(ReadOnlySpan{T}, T)"/>
    /// <remarks><inheritdoc cref="SplitFirst{T}(System.ReadOnlySpan{T},ReadOnlySpan{T})"/></remarks>
    public static ReadOnlySpanSplit<T> SplitLast<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> divisor)
        where T : IEquatable<T>
        => CreateSplit(span, span.LastIndexOf(divisor), divisor.Length);

    /// <summary>Creates a new <see cref="ReadOnlySpanSplit{T}"/>.</summary>
    /// <param name="left">The left side of the split.</param>
    /// <param name="right">The right side of the split.</param>
    /// <typeparam name="T">The type of values in the split.</typeparam>
    /// <returns>A new <see cref="ReadOnlySpanSplit{T}"/>.</returns>
    public static ReadOnlySpanSplit<T> Create<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right) => new(left, right);

    /// <summary>Creates a new <see cref="ReadOnlySpanSplit{T}"/>.</summary>
    /// <param name="span">The span to split.</param>
    /// <param name="index">The index to split at.</param>
    /// <param name="length">The length of the skipped split elements.</param>
    /// <typeparam name="T">The type of values in the split.</typeparam>
    /// <returns>A new <see cref="ReadOnlySpanSplit{T}"/>.</returns>
    static ReadOnlySpanSplit<T> CreateSplit<T>(ReadOnlySpan<T> span, int index, int length) => index switch
    {
        < 0 => Create(span, ReadOnlySpan<T>.Empty),
        _ => Create(span[..index], span[(index + length)..]),
    };
}

/// <summary>Represents a division of a <see cref="ReadOnlySpan{T}"/> into <see cref="Left"/> and <see cref="Right"/>
/// halves.</summary>
/// <param name="left">The left half of the split.</param>
/// <param name="right">The right half of the split.</param>
/// <typeparam name="T">The type of items in the split.</typeparam>
public readonly ref struct ReadOnlySpanSplit<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right)
{
    /// <summary>The left side of the split.</summary>
    public readonly ReadOnlySpan<T> Left = left;

    /// <summary>The right side of the split.</summary>
    public readonly ReadOnlySpan<T> Right = right;

    /// <summary>Deconstructs this instance into <paramref name="left"/> and <paramref name="right"/>.</summary>
    /// <param name="left">When this method returns, <see cref="Left"/>.</param>
    /// <param name="right">When this method returns, <see cref="Right"/>.</param>
    public void Deconstruct(out ReadOnlySpan<T> left, out ReadOnlySpan<T> right)
    {
        left = this.Left;
        right = this.Right;
    }
}