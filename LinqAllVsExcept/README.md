# Linq 'All' vs 'Except' to find if one list is a subset of another




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean             | Error           | StdDev          | Ratio  | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|---------------------------- |------ |-----------------:|----------------:|----------------:|-------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **VerifySubsetUsingLinqAll**    | **10**    |         **266.5 ns** |         **3.57 ns** |         **3.34 ns** |   **0.78** |    **0.01** |  **0.0577** |       **-** |       **-** |     **968 B** |        **2.05** |
| VerifySubsetUsingLinqExcept | 10    |         341.6 ns |         3.86 ns |         3.61 ns |   1.00 |    0.01 |  0.0281 |       - |       - |     472 B |        1.00 |
|                             |       |                  |                 |                 |        |         |         |         |         |           |             |
| **VerifySubsetUsingLinqAll**    | **1000**  |   **1,380,906.9 ns** |    **27,340.94 ns** |    **40,076.00 ns** |  **51.26** |    **1.55** |  **3.9063** |       **-** |       **-** |   **88088 B** |        **3.95** |
| VerifySubsetUsingLinqExcept | 1000  |      26,942.5 ns |       301.34 ns |       281.87 ns |   1.00 |    0.01 |  1.3123 |  0.0916 |       - |   22312 B |        1.00 |
|                             |       |                  |                 |                 |        |         |         |         |         |           |             |
| **VerifySubsetUsingLinqAll**    | **10000** | **130,149,718.8 ns** | **1,284,772.80 ns** | **1,003,066.10 ns** | **260.49** |    **6.61** |       **-** |       **-** |       **-** |  **880088 B** |        **4.35** |
| VerifySubsetUsingLinqExcept | 10000 |     499,900.4 ns |     9,928.89 ns |    11,434.12 ns |   1.00 |    0.03 | 49.8047 | 49.8047 | 49.8047 |  202329 B |        1.00 |
