# Making HashSets



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27734.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| RoundRobinUsingListAndEnumerators  | 10    | 1.808 μs | 0.0353 μs | 0.0362 μs |  1.00 |    0.00 | 0.4845 |   2.05 KB |        1.00 |
| RoundRobinUsingListAndEnumerators2 | 10    | 1.727 μs | 0.0260 μs | 0.0217 μs |  0.95 |    0.02 | 0.4711 |   1.98 KB |        0.97 |
| RoundRobinUsingQueue               | 10    | 4.761 μs | 0.0790 μs | 0.0879 μs |  2.64 |    0.08 | 0.9995 |   4.23 KB |        2.06 |
| RoundRobinUsingQueueAndEnumerators | 10    | 2.524 μs | 0.0503 μs | 0.0855 μs |  1.39 |    0.05 | 0.5379 |   2.27 KB |        1.11 |
| RoundRobinUsingSuperLinqInterleave | 10    | 2.200 μs | 0.0302 μs | 0.0253 μs |  1.22 |    0.03 | 0.5417 |   2.29 KB |        1.12 |
