# Finding max value of an array of ints





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method        | Count   | Mean          | Error        | StdDev       | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------- |-------- |--------------:|-------------:|-------------:|--------------:|------:|--------:|----------:|------------:|
| **MaxWithLoop**   | **1000**    |     **521.98 ns** |    **10.455 ns** |    **27.175 ns** |     **524.43 ns** | **10.12** |    **0.52** |         **-** |          **NA** |
| EnumerableMax | 1000    |      51.59 ns |     0.202 ns |     0.179 ns |      51.61 ns |  1.00 |    0.00 |         - |          NA |
|               |         |               |              |              |               |       |         |           |             |
| **MaxWithLoop**   | **1000000** | **315,673.69 ns** | **2,149.025 ns** | **1,794.533 ns** | **316,586.43 ns** |  **4.75** |    **0.30** |         **-** |          **NA** |
| EnumerableMax | 1000000 |  66,702.16 ns | 1,330.376 ns | 3,774.055 ns |  68,113.92 ns |  1.00 |    0.09 |         - |          NA |
