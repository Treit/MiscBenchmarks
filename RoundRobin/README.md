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
| RoundRobinUsingListAndEnumerators  | 10    | 1.002 μs | 0.0093 μs | 0.0078 μs |  1.00 |    0.01 | 0.1106 |   1.82 KB |        1.00 |
| RoundRobinUsingQueue               | 10    | 2.786 μs | 0.0255 μs | 0.0239 μs |  2.78 |    0.03 | 0.2441 |   4.04 KB |        2.22 |
| RoundRobinUsingQueueAndEnumerators | 10    | 1.713 μs | 0.0280 μs | 0.0248 μs |  1.71 |    0.03 | 0.1259 |   2.09 KB |        1.15 |
| RoundRobinUsingSuperLinqInterleave | 10    | 1.284 μs | 0.0108 μs | 0.0096 μs |  1.28 |    0.01 | 0.1278 |    2.1 KB |        1.15 |
