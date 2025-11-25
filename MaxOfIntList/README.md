# Finding max value of a list of ints




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method        | Count     | Mean             | Error          | StdDev         | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------- |---------- |-----------------:|---------------:|---------------:|------:|--------:|----------:|------------:|
| **MaxWithLoop**   | **1000**      |        **535.41 ns** |      **10.746 ns** |      **30.133 ns** |  **1.00** |    **0.08** |         **-** |          **NA** |
| EnumerableMax | 1000      |         51.47 ns |       0.106 ns |       0.094 ns |  0.10 |    0.01 |         - |          NA |
|               |           |                  |                |                |       |         |           |             |
| **MaxWithLoop**   | **100000000** | **33,503,442.92 ns** | **314,176.152 ns** | **293,880.568 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EnumerableMax | 100000000 | 17,682,293.33 ns | 154,438.495 ns | 144,461.864 ns |  0.53 |    0.01 |         - |          NA |
