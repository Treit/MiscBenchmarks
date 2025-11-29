# Setting and then checking two booleans.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Iterations | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------- |---------- |---------- |----------- |-------------:|-----------:|-----------:|------:|--------:|--------:|----------:|------------:|
| **CheckTwoBooleansUsingTuple**      | **.NET 10.0** | **.NET 10.0** | **1**          |     **19.98 ns** |   **0.013 ns** |   **0.010 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | .NET 10.0 | .NET 10.0 | 1          |     63.37 ns |   0.607 ns |   0.567 ns |  3.17 |    0.03 |  0.0129 |     216 B |          NA |
|                                 |           |           |            |              |            |            |       |         |         |           |             |
| CheckTwoBooleansUsingTuple      | .NET 9.0  | .NET 9.0  | 1          |     20.19 ns |   0.015 ns |   0.013 ns |  1.00 |    0.00 |       - |         - |          NA |
| CheckTwoBooleansUsingDictionary | .NET 9.0  | .NET 9.0  | 1          |     63.51 ns |   0.446 ns |   0.417 ns |  3.15 |    0.02 |  0.0129 |     216 B |          NA |
|                                 |           |           |            |              |            |            |       |         |         |           |             |
| **CheckTwoBooleansUsingTuple**      | **.NET 10.0** | **.NET 10.0** | **1000**       | **17,747.22 ns** |  **21.364 ns** |  **18.939 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | .NET 10.0 | .NET 10.0 | 1000       | 64,589.29 ns | 564.356 ns | 527.899 ns |  3.64 |    0.03 | 12.8174 |  216000 B |          NA |
|                                 |           |           |            |              |            |            |       |         |         |           |             |
| CheckTwoBooleansUsingTuple      | .NET 9.0  | .NET 9.0  | 1000       | 17,590.10 ns |  34.853 ns |  32.602 ns |  1.00 |    0.00 |       - |         - |          NA |
| CheckTwoBooleansUsingDictionary | .NET 9.0  | .NET 9.0  | 1000       | 65,175.87 ns | 629.485 ns | 588.820 ns |  3.71 |    0.03 | 12.8174 |  216000 B |          NA |
