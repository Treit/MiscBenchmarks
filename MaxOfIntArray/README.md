# Finding max value of an array of ints






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method        | Count   | Mean          | Error        | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------- |-------- |--------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **MaxWithLoop**   | **1000**    |     **531.27 ns** |    **10.642 ns** |    **28.221 ns** | **10.27** |    **0.54** |         **-** |          **NA** |
| EnumerableMax | 1000    |      51.75 ns |     0.242 ns |     0.202 ns |  1.00 |    0.01 |         - |          NA |
|               |         |               |              |              |       |         |           |             |
| **MaxWithLoop**   | **1000000** | **315,694.68 ns** | **2,130.458 ns** | **1,992.832 ns** |  **4.70** |    **0.27** |         **-** |          **NA** |
| EnumerableMax | 1000000 |  67,369.38 ns | 1,341.112 ns | 3,389.161 ns |  1.00 |    0.08 |         - |          NA |
