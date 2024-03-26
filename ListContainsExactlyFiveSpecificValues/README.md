# Checking if a list contains exactly five pre-determined values in any order.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-EVIISX : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                                          | Count  | Mean        | Error     | StdDev      | Median      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------------ |------- |------------:|----------:|------------:|------------:|------:|--------:|----------:|------------:|
| ListIsExactlyFiveValuesHashSet                  | 100000 |    917.0 ns |  93.85 ns |   276.73 ns |    900.0 ns |  3.57 |    1.43 |     400 B |        1.00 |
| ListIsExactlyFiveValuesSetEquals                | 100000 |  7,166.0 ns | 760.83 ns | 2,243.34 ns |  7,700.0 ns | 24.48 |    9.39 |     568 B |        1.42 |
| ListIsExactlyFiveValuesBitmaskSetSetEquals      | 100000 |  5,287.8 ns | 171.65 ns |   478.49 ns |  5,100.0 ns | 20.01 |    5.51 |     616 B |        1.54 |
| ListIsExactlyFiveValuesBitmaskSetContains       | 100000 |  1,008.5 ns |  52.08 ns |   148.58 ns |  1,000.0 ns |  3.88 |    1.42 |     400 B |        1.00 |
| ListIsExactlyFiveValuesSuperLinqCollectionEqual | 100000 | 14,106.7 ns | 281.30 ns |   263.13 ns | 14,000.0 ns | 60.94 |   24.10 |    2496 B |        6.24 |
| ListIsExactlyFiveValuesPatternMatchingLulz      | 100000 |    275.9 ns |  17.66 ns |    45.90 ns |    300.0 ns |  1.00 |    0.00 |     400 B |        1.00 |
