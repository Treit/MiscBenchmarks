## Convert.ToInt32 vs. int.Parse



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Count  | Mean            | Error        | StdDev       | Ratio | Allocated | Alloc Ratio |
|------------------------- |------- |----------------:|-------------:|-------------:|------:|----------:|------------:|
| **StringToIntUsingConvert**  | **10**     |        **68.76 ns** |     **0.701 ns** |     **0.655 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 10     |        68.64 ns |     0.586 ns |     0.548 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse | 10     |        68.97 ns |     0.485 ns |     0.453 ns |  1.00 |         - |          NA |
|                          |        |                 |              |              |       |           |             |
| **StringToIntUsingConvert**  | **100**    |       **750.74 ns** |     **3.483 ns** |     **3.258 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 100    |       782.83 ns |     4.838 ns |     4.526 ns |  1.04 |         - |          NA |
| StringToIntUsingTryParse | 100    |       781.68 ns |     2.973 ns |     2.635 ns |  1.04 |         - |          NA |
|                          |        |                 |              |              |       |           |             |
| **StringToIntUsingConvert**  | **10000**  |    **93,022.08 ns** |   **579.993 ns** |   **484.320 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 10000  |    93,499.67 ns |   596.803 ns |   498.357 ns |  1.01 |         - |          NA |
| StringToIntUsingTryParse | 10000  |    93,408.50 ns |   407.982 ns |   361.665 ns |  1.00 |         - |          NA |
|                          |        |                 |              |              |       |           |             |
| **StringToIntUsingConvert**  | **100000** |   **996,650.00 ns** | **7,781.140 ns** | **7,278.483 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 100000 | 1,028,137.57 ns | 7,396.863 ns | 6,919.030 ns |  1.03 |         - |          NA |
| StringToIntUsingTryParse | 100000 | 1,031,981.14 ns | 8,114.145 ns | 6,775.678 ns |  1.04 |         - |          NA |
