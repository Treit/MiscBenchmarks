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
| RoundRobinUsingListAndEnumerators  | 10    | 1.737 μs | 0.0229 μs | 0.0191 μs |  1.00 |    0.00 | 0.4845 |   2.05 KB |        1.00 |
| RoundRobinUsingQueue               | 10    | 4.742 μs | 0.0865 μs | 0.0962 μs |  2.74 |    0.06 | 0.9995 |   4.23 KB |        2.06 |
| RoundRobinUsingQueueAndEnumerators | 10    | 2.500 μs | 0.0409 μs | 0.0362 μs |  1.44 |    0.02 | 0.5379 |   2.27 KB |        1.11 |
| RoundRobinUsingSuperLinqInterleave | 10    | 2.192 μs | 0.0244 μs | 0.0191 μs |  1.26 |    0.02 | 0.5417 |   2.29 KB |        1.12 |
