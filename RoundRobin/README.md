# Making HashSets







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |---------- |---------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| RoundRobinUsingListAndEnumerators  | .NET 10.0 | .NET 10.0 | 10    | 1,000.2 ns | 16.97 ns | 19.54 ns |  1.00 |    0.03 | 0.1106 |   1.82 KB |        1.00 |
| RoundRobinUsingQueue               | .NET 10.0 | .NET 10.0 | 10    | 2,793.4 ns | 19.63 ns | 18.36 ns |  2.79 |    0.06 | 0.2441 |   4.04 KB |        2.22 |
| RoundRobinUsingQueueAndEnumerators | .NET 10.0 | .NET 10.0 | 10    | 1,838.9 ns | 10.08 ns |  9.43 ns |  1.84 |    0.04 | 0.1259 |   2.09 KB |        1.15 |
| RoundRobinUsingSuperLinqInterleave | .NET 10.0 | .NET 10.0 | 10    | 1,276.1 ns |  8.41 ns |  7.87 ns |  1.28 |    0.03 | 0.1278 |    2.1 KB |        1.15 |
|                                    |           |           |       |            |          |          |       |         |        |           |             |
| RoundRobinUsingListAndEnumerators  | .NET 9.0  | .NET 9.0  | 10    |   994.9 ns |  6.03 ns |  5.64 ns |  1.00 |    0.01 | 0.1106 |   1.82 KB |        1.00 |
| RoundRobinUsingQueue               | .NET 9.0  | .NET 9.0  | 10    | 3,006.1 ns |  9.14 ns |  8.55 ns |  3.02 |    0.02 | 0.2441 |   4.04 KB |        2.22 |
| RoundRobinUsingQueueAndEnumerators | .NET 9.0  | .NET 9.0  | 10    | 1,908.6 ns | 22.57 ns | 21.11 ns |  1.92 |    0.02 | 0.1259 |   2.09 KB |        1.15 |
| RoundRobinUsingSuperLinqInterleave | .NET 9.0  | .NET 9.0  | 10    | 1,336.6 ns |  8.46 ns |  7.91 ns |  1.34 |    0.01 | 0.1278 |    2.1 KB |        1.15 |
