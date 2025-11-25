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
| Method                         | Count | Mean          | Error         | StdDev       | Ratio | Allocated | Alloc Ratio |
|------------------------------- |------ |--------------:|--------------:|-------------:|------:|----------:|------------:|
| **CheckWithForEachSinglePass**     | **5**     |      **26.95 ns** |      **3.420 ns** |     **0.187 ns** |  **1.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 5     |      24.65 ns |      1.781 ns |     0.098 ns |  0.91 |         - |          NA |
|                                |       |               |               |              |       |           |             |
| **CheckWithForEachSinglePass**     | **50**    |     **139.91 ns** |     **17.767 ns** |     **0.974 ns** |  **1.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 50    |     153.63 ns |     29.219 ns |     1.602 ns |  1.10 |         - |          NA |
|                                |       |               |               |              |       |           |             |
| **CheckWithForEachSinglePass**     | **50000** | **125,472.60 ns** | **16,716.070 ns** |   **916.264 ns** |  **1.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 50000 | 134,008.65 ns | 18,775.864 ns | 1,029.168 ns |  1.07 |         - |          NA |
