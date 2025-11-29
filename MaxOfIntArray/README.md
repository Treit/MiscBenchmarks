# Finding max value of an array of ints







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method        | Job       | Runtime   | Count   | Mean          | Error        | StdDev       | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------- |---------- |---------- |-------- |--------------:|-------------:|-------------:|--------------:|------:|--------:|----------:|------------:|
| **MaxWithLoop**   | **.NET 10.0** | **.NET 10.0** | **1000**    |     **568.09 ns** |    **11.388 ns** |    **26.394 ns** |     **570.17 ns** | **11.03** |    **0.51** |         **-** |          **NA** |
| EnumerableMax | .NET 10.0 | .NET 10.0 | 1000    |      51.51 ns |     0.106 ns |     0.089 ns |      51.48 ns |  1.00 |    0.00 |         - |          NA |
|               |           |           |         |               |              |              |               |       |         |           |             |
| MaxWithLoop   | .NET 9.0  | .NET 9.0  | 1000    |     536.54 ns |    10.700 ns |    30.003 ns |     536.77 ns | 10.49 |    0.58 |         - |          NA |
| EnumerableMax | .NET 9.0  | .NET 9.0  | 1000    |      51.17 ns |     0.075 ns |     0.071 ns |      51.18 ns |  1.00 |    0.00 |         - |          NA |
|               |           |           |         |               |              |              |               |       |         |           |             |
| **MaxWithLoop**   | **.NET 10.0** | **.NET 10.0** | **1000000** | **314,325.43 ns** | **1,602.937 ns** | **1,499.388 ns** | **313,714.16 ns** |  **5.07** |    **0.44** |         **-** |          **NA** |
| EnumerableMax | .NET 10.0 | .NET 10.0 | 1000000 |  62,424.17 ns | 1,815.143 ns | 5,351.991 ns |  65,379.32 ns |  1.01 |    0.12 |         - |          NA |
|               |           |           |         |               |              |              |               |       |         |           |             |
| MaxWithLoop   | .NET 9.0  | .NET 9.0  | 1000000 | 313,948.52 ns | 1,795.201 ns | 1,499.074 ns | 313,522.56 ns |  5.13 |    0.44 |         - |          NA |
| EnumerableMax | .NET 9.0  | .NET 9.0  | 1000000 |  61,666.08 ns | 1,842.523 ns | 5,432.720 ns |  57,302.11 ns |  1.01 |    0.12 |         - |          NA |
