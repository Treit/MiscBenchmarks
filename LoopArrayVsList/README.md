# Looping over an array vs. a list.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Count  | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **ForLoopArray**     | **10**     |      **4.256 ns** |     **0.0358 ns** |     **0.0335 ns** |      **4.260 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ForEachLoopArray | 10     |      4.229 ns |     0.0275 ns |     0.0257 ns |      4.235 ns |  0.99 |    0.01 |         - |          NA |
| ForLoopList      | 10     |      8.448 ns |     0.1530 ns |     0.1431 ns |      8.518 ns |  1.99 |    0.04 |         - |          NA |
| ForEachLoopList  | 10     |      8.692 ns |     0.0789 ns |     0.0699 ns |      8.702 ns |  2.04 |    0.02 |         - |          NA |
|                  |        |               |               |               |               |       |         |           |             |
| **ForLoopArray**     | **100000** | **65,672.043 ns** | **2,138.0890 ns** | **6,304.2040 ns** | **68,222.723 ns** |  **1.01** |    **0.15** |         **-** |          **NA** |
| ForEachLoopArray | 100000 | 67,580.115 ns | 1,339.7714 ns | 3,482.2443 ns | 68,553.503 ns |  1.04 |    0.13 |         - |          NA |
| ForLoopList      | 100000 | 71,611.658 ns | 1,221.3417 ns | 1,019.8756 ns | 71,265.320 ns |  1.10 |    0.13 |         - |          NA |
| ForEachLoopList  | 100000 | 75,759.762 ns |   668.8080 ns |   625.6034 ns | 76,048.938 ns |  1.17 |    0.13 |         - |          NA |
