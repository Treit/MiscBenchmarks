Loop variables


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method      | Iterations | Mean             | Error          | StdDev         | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------ |----------- |-----------------:|---------------:|---------------:|------:|--------:|----------:|------------:|
| **IntegerLoop** | **10**         |         **2.915 ns** |      **0.0296 ns** |      **0.0277 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FloatLoop   | 10         |         3.199 ns |      0.0328 ns |      0.0274 ns |  1.10 |    0.01 |         - |          NA |
| DoubleLoop  | 10         |         3.208 ns |      0.0410 ns |      0.0384 ns |  1.10 |    0.02 |         - |          NA |
| DecimalLoop | 10         |        74.285 ns |      0.4595 ns |      0.4298 ns | 25.48 |    0.28 |         - |          NA |
|             |            |                  |                |                |       |         |           |             |
| **IntegerLoop** | **1000000**    |   **312,699.250 ns** |  **2,889.7350 ns** |  **2,561.6748 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FloatLoop   | 1000000    | 1,192,546.484 ns |  7,159.6134 ns |  6,697.1068 ns |  3.81 |    0.04 |         - |          NA |
| DoubleLoop  | 1000000    | 1,193,197.253 ns |  6,146.6293 ns |  5,749.5609 ns |  3.82 |    0.03 |         - |          NA |
| DecimalLoop | 1000000    | 7,181,725.180 ns | 24,506.3215 ns | 20,463.8883 ns | 22.97 |    0.19 |         - |          NA |
