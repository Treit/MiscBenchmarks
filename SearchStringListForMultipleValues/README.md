# Searching for several items in a list of strings.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26080.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]   : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  ShortRun : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                         | Count | Mean          | Error          | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |------ |--------------:|---------------:|-------------:|------:|--------:|----------:|------------:|
| **CheckWithForEachSinglePass**     | **5**     |      **36.93 ns** |       **5.679 ns** |     **0.311 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 5     |      89.92 ns |      10.224 ns |     0.560 ns |  2.44 |    0.03 |         - |          NA |
|                                |       |               |                |              |       |         |           |             |
| **CheckWithForEachSinglePass**     | **50**    |     **239.36 ns** |      **43.144 ns** |     **2.365 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 50    |     455.50 ns |      35.795 ns |     1.962 ns |  1.90 |    0.03 |         - |          NA |
|                                |       |               |                |              |       |         |           |             |
| **CheckWithForEachSinglePass**     | **50000** | **216,449.24 ns** | **125,790.571 ns** | **6,895.006 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | 50000 | 379,116.60 ns |  27,058.273 ns | 1,483.155 ns |  1.75 |    0.06 |         - |          NA |
