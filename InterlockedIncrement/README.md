# InterlockedIncrement


```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3


```
| Method                     | Count    | Mean             | Error          | StdDev         | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |--------- |-----------------:|---------------:|---------------:|------:|--------:|----------:|------------:|
| **PlainIncrement**             | **100**      |         **39.99 ns** |       **0.630 ns** |       **0.589 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| InterlockedIncrementMethod | 100      |        238.38 ns |       2.282 ns |       2.134 ns |  5.96 |    0.10 |         - |          NA |
|                            |          |                  |                |                |       |         |           |             |
| **PlainIncrement**             | **10000000** |  **3,175,195.73 ns** |  **25,784.115 ns** |  **24,118.477 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| InterlockedIncrementMethod | 10000000 | 23,933,154.27 ns | 163,980.820 ns | 153,387.760 ns |  7.54 |    0.07 |         - |          NA |
