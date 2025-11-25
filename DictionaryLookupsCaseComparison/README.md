# Dictionary lookups using different case comparison options.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Iterations | Mean            | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |----------- |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **DictonaryLookupUsingOrdinal**                    | **10**         |        **21.71 μs** |      **0.100 μs** |      **0.089 μs** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DictonaryLookupUsingOrdinalIgnoreCase          | 10         |        33.18 μs |      0.254 μs |      0.238 μs |  1.53 |    0.01 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | 10         |       454.58 μs |      4.571 μs |      4.276 μs | 20.94 |    0.21 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | 10         |       457.19 μs |      4.293 μs |      3.806 μs | 21.06 |    0.19 |         - |          NA |
|                                                |            |                 |               |               |       |         |           |             |
| **DictonaryLookupUsingOrdinal**                    | **100000**     |   **216,388.49 μs** |  **1,241.302 μs** |  **1,161.115 μs** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DictonaryLookupUsingOrdinalIgnoreCase          | 100000     |   306,643.15 μs |  1,727.022 μs |  1,530.960 μs |  1.42 |    0.01 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | 100000     | 4,638,360.63 μs | 74,613.134 μs | 69,793.172 μs | 21.44 |    0.33 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | 100000     | 4,591,253.15 μs | 40,148.407 μs | 37,554.845 μs | 21.22 |    0.20 |         - |          NA |
