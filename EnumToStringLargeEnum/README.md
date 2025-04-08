# Getting the string representation of enum values that have a lot of members.

This uses HttpStatusCode, which also has the characertistic that it starts at a high numeric value and is sparse with gaps between values. That means a simple array lookup by enum integer value is insufficient, but we can trade off memory with a sparse array to get good performance.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27832.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                       | Mean       | Error    | StdDev   | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------------- |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|----------:|------------:|
| HttpStatusCodeToStringRegularToString        | 2,008.2 ns | 31.71 ns | 28.11 ns | 2,005.3 ns | 17.16 |    0.73 | 0.3700 |    1610 B |          NA |
| HttpStatusCodeToStringSwitchExpression       |   236.2 ns |  4.80 ns | 13.77 ns |   234.3 ns |  1.98 |    0.12 |      - |         - |          NA |
| HttpStatusCodeToStringFrozenDictionaryLookup |   294.0 ns |  5.15 ns |  7.05 ns |   292.8 ns |  2.55 |    0.10 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayLookup      |   116.0 ns |  2.36 ns |  4.00 ns |   114.1 ns |  1.00 |    0.00 |      - |         - |          NA |
