# Illustrating the overhead of unboxing


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27863.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                    | Count  | Mean         | Error       | StdDev       | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------- |------- |-------------:|------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **SumIntListWithoutUnboxing** | **1000**   |     **664.6 ns** |    **15.47 ns** |     **44.89 ns** |     **658.7 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | 1000   |   1,733.5 ns |    73.00 ns |    211.79 ns |   1,700.6 ns |  2.62 |    0.39 |         - |          NA |
|                           |        |              |             |              |              |       |         |           |             |
| **SumIntListWithoutUnboxing** | **100000** |  **73,564.7 ns** | **4,380.63 ns** | **12,847.62 ns** |  **68,596.4 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | 100000 | 194,759.3 ns | 8,590.42 ns | 25,058.67 ns | 190,436.4 ns |  2.72 |    0.55 |         - |          NA |
