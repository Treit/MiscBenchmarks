# Getting the string representation of enum values that have a lot of members.

This uses HttpStatusCode, which also has the characertistic that it starts at a high numeric value and is sparse with gaps between values. That means a simple array lookup by enum integer value is insufficient, but we can trade off memory with a sparse array to get good performance.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Mean        | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------- |------------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| HttpStatusCodeToStringRegularToString         | 1,620.32 ns | 9.944 ns | 9.301 ns | 24.43 |    1.17 | 0.0954 |    1608 B |          NA |
| HttpStatusCodeToStringSwitchExpression        |   377.99 ns | 7.351 ns | 9.559 ns |  5.70 |    0.31 |      - |         - |          NA |
| HttpStatusCodeToStringFrozenDictionaryLookup  |   125.12 ns | 2.573 ns | 2.860 ns |  1.89 |    0.10 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayLookup       |    66.46 ns | 1.396 ns | 3.064 ns |  1.00 |    0.07 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayDoubleLookup |    78.93 ns | 1.720 ns | 5.072 ns |  1.19 |    0.10 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArraySingleLookup |    93.71 ns | 1.945 ns | 5.550 ns |  1.41 |    0.11 |      - |         - |          NA |
