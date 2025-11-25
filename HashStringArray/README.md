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
| HashWithStringBuilder                              | 500   | 3.802 μs | 0.0177 μs | 0.0157 μs |  1.00 |    0.01 | 0.5531 | 0.0076 |   9.04 KB |        1.00 |
| HashWithStringDotJoin                              | 500   | 3.951 μs | 0.0778 μs | 0.1091 μs |  1.04 |    0.03 | 0.2670 |      - |   4.48 KB |        0.50 |
| HashWithMemoryMarshalCastAndStream                 | 500   | 4.740 μs | 0.0513 μs | 0.0480 μs |  1.25 |    0.01 | 0.3204 |      - |   5.32 KB |        0.59 |
| HashWithMemoryMarshalCastAndStreamPrecomputeLength | 500   | 4.945 μs | 0.0397 μs | 0.0332 μs |  1.30 |    0.01 | 0.1907 |      - |   3.16 KB |        0.35 |
