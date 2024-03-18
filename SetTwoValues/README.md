# Setting and then checking two booleans.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Iterations | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------- |----------- |--------------:|-------------:|-------------:|------:|--------:|--------:|----------:|------------:|
| **CheckTwoBooleansUsingTuple**      | **1**          |      **22.05 ns** |     **0.438 ns** |     **0.914 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | 1          |     122.73 ns |     2.465 ns |     2.421 ns |  5.61 |    0.37 |  0.0501 |     216 B |          NA |
|                                 |            |               |              |              |       |         |         |           |             |
| **CheckTwoBooleansUsingTuple**      | **1000**       |  **19,085.43 ns** |   **364.178 ns** |   **404.783 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | 1000       | 130,209.40 ns | 2,598.626 ns | 6,707.883 ns |  6.96 |    0.43 | 50.0488 |  216000 B |          NA |
