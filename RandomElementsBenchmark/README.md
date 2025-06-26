# RandomElementsBenchmark
Picking n elements at random from a list without duplicates.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27887.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | SourceCount | SelectCount | Mean        | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------- |------------ |------------ |------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **CryptographicRngWithHashSet**          | **1000**        | **3**           |   **372.66 ns** |   **7.503 ns** |  **16.935 ns** |  **6.02** |    **0.30** | **0.0553** |     **240 B** |        **3.33** |
| SharedRandomWithHashSet              | 1000        | 3           |   110.05 ns |   2.249 ns |   5.475 ns |  1.78 |    0.10 | 0.0556 |     240 B |        3.33 |
| SharedRandomWithBoolArray            | 1000        | 3           |   111.92 ns |   2.294 ns |   5.036 ns |  1.81 |    0.09 | 0.2540 |    1096 B |       15.22 |
| SharedRandomWithStackAllocBoolArray  | 1000        | 3           |    88.19 ns |   2.232 ns |   6.186 ns |  1.42 |    0.10 | 0.0167 |      72 B |        1.00 |
| SharedRandomWithWithStackAllocBitSet | 1000        | 3           |    61.97 ns |   1.292 ns |   1.436 ns |  1.00 |    0.03 | 0.0167 |      72 B |        1.00 |
| SharedRandomWithBitArray             | 1000        | 3           |    60.86 ns |   1.279 ns |   1.835 ns |  0.98 |    0.04 | 0.0519 |     224 B |        3.11 |
|                                      |             |             |             |            |            |       |         |        |           |             |
| **CryptographicRngWithHashSet**          | **1000**        | **50**          | **6,266.93 ns** | **124.599 ns** | **307.977 ns** | **10.05** |    **0.59** | **0.7019** |    **3048 B** |       **11.91** |
| SharedRandomWithHashSet              | 1000        | 50          | 2,010.45 ns |  39.854 ns |  73.872 ns |  3.22 |    0.16 | 0.7057 |    3048 B |       11.91 |
| SharedRandomWithBoolArray            | 1000        | 50          |   594.47 ns |  11.710 ns |  13.939 ns |  0.95 |    0.04 | 0.2966 |    1280 B |        5.00 |
| SharedRandomWithStackAllocBoolArray  | 1000        | 50          |   602.79 ns |  11.942 ns |  22.430 ns |  0.97 |    0.05 | 0.0591 |     256 B |        1.00 |
| SharedRandomWithWithStackAllocBitSet | 1000        | 50          |   624.34 ns |  12.283 ns |  20.523 ns |  1.00 |    0.05 | 0.0591 |     256 B |        1.00 |
| SharedRandomWithBitArray             | 1000        | 50          |   604.86 ns |  12.167 ns |  17.056 ns |  0.97 |    0.04 | 0.0944 |     408 B |        1.59 |
