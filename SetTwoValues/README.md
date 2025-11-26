# Setting and then checking two booleans.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Iterations | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------- |----------- |-------------:|-----------:|-----------:|------:|--------:|--------:|----------:|------------:|
| **CheckTwoBooleansUsingTuple**      | **1**          |     **20.17 ns** |   **0.119 ns** |   **0.112 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | 1          |     65.60 ns |   0.678 ns |   0.634 ns |  3.25 |    0.04 |  0.0129 |     216 B |          NA |
|                                 |            |              |            |            |       |         |         |           |             |
| **CheckTwoBooleansUsingTuple**      | **1000**       | **17,858.87 ns** |  **97.167 ns** |  **90.890 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | 1000       | 66,330.54 ns | 999.584 ns | 935.012 ns |  3.71 |    0.05 | 12.8174 |  216000 B |          NA |
