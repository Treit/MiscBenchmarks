# Getting the string representation of enum values that have a lot of members.

This uses HttpStatusCode, which also has the characertistic that it starts at a high numeric value and is sparse with gaps between values. That means a simple array lookup by enum integer value is insufficient, but we can trade off memory with a sparse array to get good performance.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Mean        | Error    | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------- |------------:|---------:|----------:|------:|--------:|-------:|----------:|------------:|
| HttpStatusCodeToStringRegularToString         | 1,590.84 ns | 8.319 ns |  7.375 ns | 20.57 |    0.48 | 0.0954 |    1608 B |          NA |
| HttpStatusCodeToStringSwitchExpression        |   398.46 ns | 7.938 ns | 10.865 ns |  5.15 |    0.18 |      - |         - |          NA |
| HttpStatusCodeToStringFrozenDictionaryLookup  |   121.63 ns | 2.409 ns |  2.253 ns |  1.57 |    0.05 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayLookup       |    77.39 ns | 1.533 ns |  1.765 ns |  1.00 |    0.03 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayDoubleLookup |    86.87 ns | 1.777 ns |  2.819 ns |  1.12 |    0.04 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArraySingleLookup |    76.31 ns | 1.574 ns |  2.879 ns |  0.99 |    0.04 |      - |         - |          NA |
