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
| **CheckTwoBooleansUsingTuple**      | **1**          |     **20.30 ns** |   **0.101 ns** |   **0.095 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | 1          |     66.51 ns |   0.746 ns |   0.698 ns |  3.28 |    0.04 |  0.0129 |     216 B |          NA |
|                                 |            |              |            |            |       |         |         |           |             |
| **CheckTwoBooleansUsingTuple**      | **1000**       | **17,600.19 ns** |  **99.950 ns** |  **93.494 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| CheckTwoBooleansUsingDictionary | 1000       | 66,154.46 ns | 762.388 ns | 675.837 ns |  3.76 |    0.04 | 12.8174 |  216000 B |          NA |
