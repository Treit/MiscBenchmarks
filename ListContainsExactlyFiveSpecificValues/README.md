# Checking if a list contains exactly five pre-determined values in any order.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                                          | Job       | Runtime   | Count  | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------------ |---------- |---------- |------- |------------:|----------:|----------:|------------:|------:|--------:|----------:|------------:|
| ListIsExactlyFiveValuesHashSet                  | .NET 10.0 | .NET 10.0 | 100000 |    513.5 ns |  29.59 ns |  85.37 ns |    500.0 ns |     ? |       ? |         - |           ? |
| ListIsExactlyFiveValuesSetEquals                | .NET 10.0 | .NET 10.0 | 100000 |  4,205.4 ns | 152.10 ns | 431.47 ns |  4,200.0 ns |     ? |       ? |     176 B |           ? |
| ListIsExactlyFiveValuesBitmaskSetSetEquals      | .NET 10.0 | .NET 10.0 | 100000 |  5,150.6 ns | 131.83 ns | 365.29 ns |  5,100.0 ns |     ? |       ? |     224 B |           ? |
| ListIsExactlyFiveValuesBitmaskSetContains       | .NET 10.0 | .NET 10.0 | 100000 |    920.6 ns |  39.15 ns | 113.59 ns |    900.0 ns |     ? |       ? |         - |           ? |
| ListIsExactlyFiveValuesSuperLinqCollectionEqual | .NET 10.0 | .NET 10.0 | 100000 | 13,465.6 ns | 311.91 ns | 869.48 ns | 13,400.0 ns |     ? |       ? |    2152 B |           ? |
| ListIsExactlyFiveValuesPatternMatchingLulz      | .NET 10.0 | .NET 10.0 | 100000 |    175.9 ns |  17.66 ns |  45.90 ns |    200.0 ns |     ? |       ? |         - |           ? |
|                                                 |           |           |        |             |           |           |             |       |         |           |             |
| ListIsExactlyFiveValuesHashSet                  | .NET 9.0  | .NET 9.0  | 100000 |    617.6 ns |  28.92 ns |  81.09 ns |    600.0 ns |  3.00 |    1.04 |         - |          NA |
| ListIsExactlyFiveValuesSetEquals                | .NET 9.0  | .NET 9.0  | 100000 |  3,926.3 ns | 112.10 ns | 321.63 ns |  3,900.0 ns | 19.05 |    6.32 |     176 B |          NA |
| ListIsExactlyFiveValuesBitmaskSetSetEquals      | .NET 9.0  | .NET 9.0  | 100000 |  5,440.4 ns | 167.53 ns | 477.97 ns |  5,400.0 ns | 26.40 |    8.80 |     224 B |          NA |
| ListIsExactlyFiveValuesBitmaskSetContains       | .NET 9.0  | .NET 9.0  | 100000 |    854.4 ns |  27.51 ns |  76.67 ns |    800.0 ns |  4.15 |    1.38 |         - |          NA |
| ListIsExactlyFiveValuesSuperLinqCollectionEqual | .NET 9.0  | .NET 9.0  | 100000 | 13,367.4 ns | 270.93 ns | 521.99 ns | 13,450.0 ns | 64.86 |   20.95 |    2152 B |          NA |
| ListIsExactlyFiveValuesPatternMatchingLulz      | .NET 9.0  | .NET 9.0  | 100000 |    224.0 ns |  22.35 ns |  64.47 ns |    200.0 ns |  1.09 |    0.48 |         - |          NA |
