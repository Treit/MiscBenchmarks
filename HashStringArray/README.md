# Getting the string representations of many items by calling ToString() vs. caching the string value.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| HashWithStringBuilder                              | 500   | 3.794 μs | 0.0433 μs | 0.0405 μs |  1.00 |    0.01 | 0.5493 | 0.0076 |   9.04 KB |        1.00 |
| HashWithStringDotJoin                              | 500   | 3.967 μs | 0.0763 μs | 0.0749 μs |  1.05 |    0.02 | 0.2594 |      - |   4.48 KB |        0.50 |
| HashWithMemoryMarshalCastAndStream                 | 500   | 4.738 μs | 0.0465 μs | 0.0413 μs |  1.25 |    0.02 | 0.3204 |      - |   5.32 KB |        0.59 |
| HashWithMemoryMarshalCastAndStreamPrecomputeLength | 500   | 4.824 μs | 0.0517 μs | 0.0458 μs |  1.27 |    0.02 | 0.1907 |      - |   3.16 KB |        0.35 |
