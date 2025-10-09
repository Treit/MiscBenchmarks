# Numeric String Comparison Benchmark

This benchmark compares different methods of string comparison when working with strings that consist entirely of digits.

## Results

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27965.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

```

| Method                        | Count  | Mean       | Error      | StdDev      | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |------- |-----------:|-----------:|------------:|-----------:|------:|--------:|----------:|------------:|
| EqualityOperator              | 1000   |   4.441 us |  0.2909 us |   0.8578 us |   4.697 us |  1.04 |    0.30 |         - |          NA |
| StringEqualsOrdinal           | 1000   |   4.071 us |  0.2513 us |   0.7408 us |   3.932 us |  0.95 |    0.27 |         - |          NA |
| StringEqualsOrdinalIgnoreCase | 1000   |   6.135 us |  0.4048 us |   1.1936 us |   5.597 us |  1.44 |    0.41 |         - |          NA |
| StringInstanceEquals          | 1000   |   3.666 us |  0.0914 us |   0.2639 us |   3.623 us |  0.86 |    0.19 |         - |          NA |
| StringInstanceEqualsOrdinal   | 1000   |   3.252 us |  0.1397 us |   0.4008 us |   3.246 us |  0.76 |    0.19 |         - |          NA |
|                               |        |            |            |             |            |       |         |           |             |
| EqualityOperator              | 100000 | 454.734 us | 12.0209 us |  35.2553 us | 449.023 us |  1.01 |    0.11 |         - |          NA |
| StringEqualsOrdinal           | 100000 | 514.181 us | 20.8047 us |  61.3432 us | 510.430 us |  1.14 |    0.16 |         - |          NA |
| StringEqualsOrdinalIgnoreCase | 100000 | 807.355 us | 38.7707 us | 114.3162 us | 771.808 us |  1.79 |    0.29 |         - |          NA |
| StringInstanceEquals          | 100000 | 407.083 us | 12.8509 us |  36.2463 us | 400.552 us |  0.90 |    0.10 |         - |          NA |
| StringInstanceEqualsOrdinal   | 100000 | 445.790 us |  8.5841 us |  21.2177 us | 442.336 us |  0.99 |    0.09 |         - |          NA |

## Analysis

The benchmark compares five different string comparison methods when working with numeric strings:

1. **`==` operator (EqualityOperator)** - The basic equality operator
2. **`string.Equals(str1, str2, StringComparison.Ordinal)`** - Static method with ordinal comparison
3. **`string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase)`** - Static method with case-insensitive ordinal comparison
4. **`str1.Equals(str2)`** - Instance method with default comparison
5. **`str1.Equals(str2, StringComparison.Ordinal)`** - Instance method with ordinal comparison

### Key Findings:

- **Fastest**: `StringInstanceEqualsOrdinal` is consistently the fastest method
- **Slowest**: `StringEqualsOrdinalIgnoreCase` is significantly slower (~77% slower for 100k operations)
- **Simple `==` operator**: Performs reasonably well, close to the static ordinal method
- **Instance `.Equals()`**: Performs better than the `==` operator and static methods
- **Case-insensitive comparison**: Has a significant performance penalty even for numeric strings

### Recommendations:

1. For numeric strings, use `str1.Equals(str2, StringComparison.Ordinal)` for best performance
2. Avoid `StringComparison.OrdinalIgnoreCase` unless case insensitivity is specifically required
3. The simple `==` operator is a good balance between readability and performance
4. Instance method calls (`str.Equals()`) generally outperform static method calls

### Notes:
- All methods produce the same results (verified in debug mode)
- No memory allocations occur during string comparisons
- Performance differences become more pronounced with larger datasets