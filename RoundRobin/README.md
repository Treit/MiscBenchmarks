# Making HashSets






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| RoundRobinUsingListAndEnumerators  | 10    | 1.026 μs | 0.0106 μs | 0.0099 μs |  1.00 |    0.01 | 0.1106 |   1.82 KB |        1.00 |
| RoundRobinUsingQueue               | 10    | 2.801 μs | 0.0194 μs | 0.0182 μs |  2.73 |    0.03 | 0.2441 |   4.04 KB |        2.22 |
| RoundRobinUsingQueueAndEnumerators | 10    | 1.634 μs | 0.0114 μs | 0.0107 μs |  1.59 |    0.02 | 0.1259 |   2.09 KB |        1.15 |
| RoundRobinUsingSuperLinqInterleave | 10    | 1.345 μs | 0.0134 μs | 0.0125 μs |  1.31 |    0.02 | 0.1278 |    2.1 KB |        1.15 |
