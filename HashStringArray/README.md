# Getting the string representations of many items by calling ToString() vs. caching the string value.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------------------------------- |---------- |---------- |------ |---------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| HashWithStringBuilder                              | .NET 10.0 | .NET 10.0 | 500   | 3.872 μs | 0.0537 μs | 0.0476 μs |  1.00 |    0.02 | 0.5493 | 0.0076 |   9.04 KB |        1.00 |
| HashWithStringDotJoin                              | .NET 10.0 | .NET 10.0 | 500   | 3.663 μs | 0.0692 μs | 0.0614 μs |  0.95 |    0.02 | 0.2594 |      - |   4.48 KB |        0.50 |
| HashWithMemoryMarshalCastAndStream                 | .NET 10.0 | .NET 10.0 | 500   | 4.923 μs | 0.0295 μs | 0.0261 μs |  1.27 |    0.02 | 0.3204 |      - |   5.32 KB |        0.59 |
| HashWithMemoryMarshalCastAndStreamPrecomputeLength | .NET 10.0 | .NET 10.0 | 500   | 4.916 μs | 0.0734 μs | 0.0687 μs |  1.27 |    0.02 | 0.1907 |      - |   3.16 KB |        0.35 |
|                                                    |           |           |       |          |           |           |       |         |        |        |           |             |
| HashWithStringBuilder                              | .NET 9.0  | .NET 9.0  | 500   | 3.860 μs | 0.0479 μs | 0.0448 μs |  1.00 |    0.02 | 0.5493 | 0.0076 |   9.04 KB |        1.00 |
| HashWithStringDotJoin                              | .NET 9.0  | .NET 9.0  | 500   | 3.717 μs | 0.0739 μs | 0.0691 μs |  0.96 |    0.02 | 0.2594 |      - |   4.48 KB |        0.50 |
| HashWithMemoryMarshalCastAndStream                 | .NET 9.0  | .NET 9.0  | 500   | 4.786 μs | 0.0565 μs | 0.0528 μs |  1.24 |    0.02 | 0.3204 |      - |   5.32 KB |        0.59 |
| HashWithMemoryMarshalCastAndStreamPrecomputeLength | .NET 9.0  | .NET 9.0  | 500   | 4.885 μs | 0.0564 μs | 0.0527 μs |  1.27 |    0.02 | 0.1907 |      - |   3.16 KB |        0.35 |
