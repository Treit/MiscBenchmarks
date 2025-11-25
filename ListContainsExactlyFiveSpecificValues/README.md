# Checking if a list contains exactly five pre-determined values in any order.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                                          | Count  | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------------ |------- |------------:|----------:|----------:|------------:|------:|--------:|----------:|------------:|
| ListIsExactlyFiveValuesHashSet                  | 100000 |    604.1 ns |  49.98 ns | 145.00 ns |    600.0 ns |     ? |       ? |         - |           ? |
| ListIsExactlyFiveValuesSetEquals                | 100000 |  4,144.7 ns |  97.95 ns | 264.80 ns |  4,100.0 ns |     ? |       ? |     176 B |           ? |
| ListIsExactlyFiveValuesBitmaskSetSetEquals      | 100000 |  5,109.8 ns | 161.24 ns | 454.78 ns |  5,100.0 ns |     ? |       ? |     224 B |           ? |
| ListIsExactlyFiveValuesBitmaskSetContains       | 100000 |    876.6 ns |  36.50 ns | 104.14 ns |    900.0 ns |     ? |       ? |         - |           ? |
| ListIsExactlyFiveValuesSuperLinqCollectionEqual | 100000 | 13,525.0 ns | 281.07 ns | 792.77 ns | 13,500.0 ns |     ? |       ? |    2152 B |           ? |
| ListIsExactlyFiveValuesPatternMatchingLulz      | 100000 |    129.8 ns |  29.45 ns |  84.02 ns |    100.0 ns |     ? |       ? |         - |           ? |
