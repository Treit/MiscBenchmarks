# Int32VsInt64Addition


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26200.8655)
AMD Ryzen 9 7940HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.203
  [Host]    : .NET 10.0.7 (10.0.726.21808), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 10.0 : .NET 10.0.7 (10.0.726.21808), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method         | Count      | Mean             | Error           | StdDev          | Ratio | Allocated | Alloc Ratio |
|--------------- |----------- |-----------------:|----------------:|----------------:|------:|----------:|------------:|
| **AddInt32Values** | **1024**       |         **383.0 ns** |         **0.96 ns** |         **0.89 ns** |  **1.00** |         **-** |          **NA** |
| AddInt64Values | 1024       |         382.5 ns |         0.64 ns |         0.59 ns |  1.00 |         - |          NA |
|                |            |                  |                 |                 |       |           |             |
| **AddInt32Values** | **1048576**    |     **392,288.0 ns** |     **3,981.72 ns** |     **3,724.50 ns** |  **1.00** |         **-** |          **NA** |
| AddInt64Values | 1048576    |     392,171.7 ns |     4,945.54 ns |     4,626.06 ns |  1.00 |         - |          NA |
|                |            |                  |                 |                 |       |           |             |
| **AddInt32Values** | **1073741824** | **403,019,913.3 ns** | **3,463,859.51 ns** | **3,240,096.33 ns** |  **1.00** |         **-** |          **NA** |
| AddInt64Values | 1073741824 | 404,036,893.3 ns | 2,420,605.85 ns | 2,264,236.21 ns |  1.00 |         - |          NA |
