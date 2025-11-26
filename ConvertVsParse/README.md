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
| **StringToIntUsingConvert**  | **10**     |        **68.97 ns** |     **0.477 ns** |     **0.446 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 10     |        68.90 ns |     0.504 ns |     0.472 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse | 10     |        69.50 ns |     0.824 ns |     0.731 ns |  1.01 |         - |          NA |
|                          |        |                 |              |              |       |           |             |
| **StringToIntUsingConvert**  | **100**    |       **755.31 ns** |     **3.723 ns** |     **3.483 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 100    |       785.28 ns |     3.754 ns |     3.328 ns |  1.04 |         - |          NA |
| StringToIntUsingTryParse | 100    |       787.52 ns |     4.961 ns |     4.641 ns |  1.04 |         - |          NA |
|                          |        |                 |              |              |       |           |             |
| **StringToIntUsingConvert**  | **10000**  |    **93,392.30 ns** |   **480.015 ns** |   **425.521 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 10000  |    93,770.61 ns |   417.525 ns |   390.553 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse | 10000  |    94,036.74 ns |   485.937 ns |   454.546 ns |  1.01 |         - |          NA |
|                          |        |                 |              |              |       |           |             |
| **StringToIntUsingConvert**  | **100000** | **1,001,286.91 ns** | **7,759.443 ns** | **7,258.188 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | 100000 | 1,033,302.68 ns | 8,226.814 ns | 7,695.367 ns |  1.03 |         - |          NA |
| StringToIntUsingTryParse | 100000 | 1,034,586.22 ns | 8,792.846 ns | 7,794.629 ns |  1.03 |         - |          NA |
