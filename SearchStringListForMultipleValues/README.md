# Searching for several items in a list of strings.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]   : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  ShortRun : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                         | Count | Mean          | Error         | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |------ |--------------:|--------------:|-----------:|------:|--------:|----------:|------------:|
| **CheckWithForEachSinglePass**     | **5**     |      **25.19 ns** |      **0.229 ns** |   **0.013 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 5     |      25.10 ns |      6.038 ns |   0.331 ns |  1.00 |    0.01 |         - |          NA |
|                                |       |               |               |            |       |         |           |             |
| **CheckWithForEachSinglePass**     | **50**    |     **140.96 ns** |     **16.053 ns** |   **0.880 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 50    |     154.67 ns |     65.505 ns |   3.591 ns |  1.10 |    0.02 |         - |          NA |
|                                |       |               |               |            |       |         |           |             |
| **CheckWithForEachSinglePass**     | **50000** | **125,228.52 ns** | **14,391.350 ns** | **788.838 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 50000 | 125,504.13 ns | 14,466.559 ns | 792.961 ns |  1.00 |    0.01 |         - |          NA |
