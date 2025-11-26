# Checking if a list contains exactly five pre-determined values in any order.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                                          | Count  | Mean        | Error     | StdDev      | Median      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------------ |------- |------------:|----------:|------------:|------------:|------:|--------:|----------:|------------:|
| ListIsExactlyFiveValuesHashSet                  | 100000 |    483.2 ns |  51.00 ns |   146.34 ns |    500.0 ns |  1.54 |    0.60 |         - |          NA |
| ListIsExactlyFiveValuesSetEquals                | 100000 |  4,260.4 ns | 226.73 ns |   635.76 ns |  4,100.0 ns | 13.57 |    3.87 |     176 B |          NA |
| ListIsExactlyFiveValuesBitmaskSetSetEquals      | 100000 |  5,267.4 ns | 219.16 ns |   628.82 ns |  5,200.0 ns | 16.78 |    4.53 |     224 B |          NA |
| ListIsExactlyFiveValuesBitmaskSetContains       | 100000 |    914.0 ns |  46.66 ns |   132.36 ns |    900.0 ns |  2.91 |    0.82 |         - |          NA |
| ListIsExactlyFiveValuesSuperLinqCollectionEqual | 100000 | 13,986.2 ns | 629.43 ns | 1,795.79 ns | 13,700.0 ns | 44.56 |   12.21 |    2152 B |          NA |
| ListIsExactlyFiveValuesPatternMatchingLulz      | 100000 |    330.9 ns |  26.22 ns |    74.81 ns |    300.0 ns |  1.05 |    0.35 |         - |          NA |
