# Checking if a list contains exactly five pre-determined values in any order.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-OBSTTW : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                                     | Count  | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------- |------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|------------:|
| ListIsExactlyFiveValuesHashSet             | 100000 |   832.0 ns |  78.59 ns | 228.01 ns |   800.0 ns |  2.76 |    0.98 |     400 B |        1.00 |
| ListIsExactlyFiveValuesSetEquals           | 100000 | 4,368.8 ns | 106.77 ns | 302.88 ns | 4,300.0 ns | 14.42 |    4.29 |     568 B |        1.42 |
| ListIsExactlyFiveValuesBitmaskSetSetEquals | 100000 | 5,494.2 ns | 194.94 ns | 530.34 ns | 5,400.0 ns | 18.29 |    5.84 |     616 B |        1.54 |
| ListIsExactlyFiveValuesBitmaskSetContains  | 100000 |   908.1 ns |  29.41 ns |  80.02 ns |   900.0 ns |  3.03 |    0.95 |     400 B |        1.00 |
| ListIsExactlyFiveValuesPatternMatchingLulz | 100000 |   328.9 ns |  34.11 ns |  95.10 ns |   300.0 ns |  1.00 |    0.00 |     400 B |        1.00 |
