# Getting the string representation of enum values that have a lot of members.

This uses HttpStatusCode, which also has the characertistic that it starts at a high numeric value and is sparse with gaps between values. That means a simple array lookup by enum integer value is insufficient, but we can trade off memory with a sparse array to get good performance.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Job       | Runtime   | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------- |---------- |---------- |------------:|----------:|----------:|------------:|------:|--------:|-------:|----------:|------------:|
| HttpStatusCodeToStringRegularToString         | .NET 10.0 | .NET 10.0 | 1,430.41 ns | 26.450 ns | 24.742 ns | 1,435.48 ns | 21.63 |    1.30 | 0.0954 |    1608 B |          NA |
| HttpStatusCodeToStringSwitchExpression        | .NET 10.0 | .NET 10.0 |   386.59 ns |  7.718 ns | 13.916 ns |   386.23 ns |  5.85 |    0.40 |      - |         - |          NA |
| HttpStatusCodeToStringFrozenDictionaryLookup  | .NET 10.0 | .NET 10.0 |   127.64 ns |  1.919 ns |  1.795 ns |   127.78 ns |  1.93 |    0.11 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayLookup       | .NET 10.0 | .NET 10.0 |    66.35 ns |  1.395 ns |  3.723 ns |    66.89 ns |  1.00 |    0.08 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayDoubleLookup | .NET 10.0 | .NET 10.0 |    89.46 ns |  2.219 ns |  6.542 ns |    90.61 ns |  1.35 |    0.13 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArraySingleLookup | .NET 10.0 | .NET 10.0 |    85.42 ns |  2.730 ns |  8.048 ns |    81.34 ns |  1.29 |    0.14 |      - |         - |          NA |
|                                               |           |           |             |           |           |             |       |         |        |           |             |
| HttpStatusCodeToStringRegularToString         | .NET 9.0  | .NET 9.0  | 1,413.97 ns | 27.954 ns | 27.454 ns | 1,408.30 ns | 20.10 |    0.98 | 0.0954 |    1608 B |          NA |
| HttpStatusCodeToStringSwitchExpression        | .NET 9.0  | .NET 9.0  |   361.21 ns |  7.295 ns | 10.227 ns |   364.44 ns |  5.13 |    0.27 |      - |         - |          NA |
| HttpStatusCodeToStringFrozenDictionaryLookup  | .NET 9.0  | .NET 9.0  |   126.67 ns |  2.519 ns |  2.356 ns |   127.20 ns |  1.80 |    0.09 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayLookup       | .NET 9.0  | .NET 9.0  |    70.49 ns |  1.465 ns |  3.026 ns |    71.69 ns |  1.00 |    0.06 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArrayDoubleLookup | .NET 9.0  | .NET 9.0  |    78.20 ns |  1.618 ns |  2.046 ns |    78.51 ns |  1.11 |    0.06 |      - |         - |          NA |
| HttpStatusCodeToStringSparseArraySingleLookup | .NET 9.0  | .NET 9.0  |    90.03 ns |  2.545 ns |  7.505 ns |    92.88 ns |  1.28 |    0.12 |      - |         - |          NA |
