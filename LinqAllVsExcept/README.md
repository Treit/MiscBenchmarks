# Linq 'All' vs 'Except' to find if one list is a subset of another





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count | Mean             | Error           | StdDev          | Ratio  | RatioSD | Gen0     | Gen1     | Gen2    | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------ |-----------------:|----------------:|----------------:|-------:|--------:|---------:|---------:|--------:|----------:|------------:|
| **VerifySubsetUsingLinqAll**    | **.NET 10.0** | **.NET 10.0** | **10**    |         **267.0 ns** |         **3.72 ns** |         **3.82 ns** |   **0.80** |    **0.01** |   **0.0577** |        **-** |       **-** |     **968 B** |        **2.05** |
| VerifySubsetUsingLinqExcept | .NET 10.0 | .NET 10.0 | 10    |         335.5 ns |         4.41 ns |         4.12 ns |   1.00 |    0.02 |   0.0281 |        - |       - |     472 B |        1.00 |
|                             |           |           |       |                  |                 |                 |        |         |          |          |         |           |             |
| VerifySubsetUsingLinqAll    | .NET 9.0  | .NET 9.0  | 10    |         267.1 ns |         4.11 ns |         3.84 ns |   0.75 |    0.01 |   0.0577 |        - |       - |     968 B |        2.05 |
| VerifySubsetUsingLinqExcept | .NET 9.0  | .NET 9.0  | 10    |         355.0 ns |         3.22 ns |         3.01 ns |   1.00 |    0.01 |   0.0281 |        - |       - |     472 B |        1.00 |
|                             |           |           |       |                  |                 |                 |        |         |          |          |         |           |             |
| **VerifySubsetUsingLinqAll**    | **.NET 10.0** | **.NET 10.0** | **1000**  |   **1,311,168.5 ns** |    **13,623.62 ns** |    **12,076.98 ns** |  **48.63** |    **0.48** |   **3.9063** |        **-** |       **-** |   **88088 B** |        **3.95** |
| VerifySubsetUsingLinqExcept | .NET 10.0 | .NET 10.0 | 1000  |      26,963.9 ns |       137.81 ns |       122.16 ns |   1.00 |    0.01 |   1.3123 |   0.0916 |       - |   22312 B |        1.00 |
|                             |           |           |       |                  |                 |                 |        |         |          |          |         |           |             |
| VerifySubsetUsingLinqAll    | .NET 9.0  | .NET 9.0  | 1000  |   1,178,901.4 ns |     8,796.45 ns |     7,797.82 ns |  43.39 |    0.40 |   3.9063 |        - |       - |   88088 B |        3.95 |
| VerifySubsetUsingLinqExcept | .NET 9.0  | .NET 9.0  | 1000  |      27,170.1 ns |       199.35 ns |       186.47 ns |   1.00 |    0.01 |   1.3123 |   0.0916 |       - |   22312 B |        1.00 |
|                             |           |           |       |                  |                 |                 |        |         |          |          |         |           |             |
| **VerifySubsetUsingLinqAll**    | **.NET 10.0** | **.NET 10.0** | **10000** | **131,161,103.8 ns** | **1,734,423.90 ns** | **1,448,322.51 ns** | **314.19** |    **3.97** |        **-** |        **-** |       **-** |  **880088 B** |        **4.35** |
| VerifySubsetUsingLinqExcept | .NET 10.0 | .NET 10.0 | 10000 |     417,479.1 ns |     3,138.62 ns |     2,935.86 ns |   1.00 |    0.01 | 150.3906 | 150.3906 | 42.9688 |  202497 B |        1.00 |
|                             |           |           |       |                  |                 |                 |        |         |          |          |         |           |             |
| VerifySubsetUsingLinqAll    | .NET 9.0  | .NET 9.0  | 10000 | 131,938,398.1 ns | 1,639,361.07 ns | 1,368,940.74 ns | 316.94 |    3.77 |        - |        - |       - |  880088 B |        4.35 |
| VerifySubsetUsingLinqExcept | .NET 9.0  | .NET 9.0  | 10000 |     416,309.6 ns |     3,126.65 ns |     2,771.69 ns |   1.00 |    0.01 | 149.9023 | 149.9023 | 42.4805 |  202501 B |        1.00 |
