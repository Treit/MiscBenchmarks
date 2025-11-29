# Finding max value of a list of ints






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method        | Job       | Runtime   | Count     | Mean             | Error          | StdDev         | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------- |---------- |---------- |---------- |-----------------:|---------------:|---------------:|------:|--------:|----------:|------------:|
| **MaxWithLoop**   | **.NET 10.0** | **.NET 10.0** | **1000**      |        **558.86 ns** |      **11.809 ns** |      **34.818 ns** |  **1.00** |    **0.09** |         **-** |          **NA** |
| EnumerableMax | .NET 10.0 | .NET 10.0 | 1000      |         51.50 ns |       0.109 ns |       0.091 ns |  0.09 |    0.01 |         - |          NA |
|               |           |           |           |                  |                |                |       |         |           |             |
| MaxWithLoop   | .NET 9.0  | .NET 9.0  | 1000      |        527.74 ns |      12.457 ns |      36.730 ns |  1.00 |    0.10 |         - |          NA |
| EnumerableMax | .NET 9.0  | .NET 9.0  | 1000      |         51.43 ns |       0.100 ns |       0.088 ns |  0.10 |    0.01 |         - |          NA |
|               |           |           |           |                  |                |                |       |         |           |             |
| **MaxWithLoop**   | **.NET 10.0** | **.NET 10.0** | **100000000** | **32,827,114.73 ns** |  **88,102.839 ns** |  **78,100.872 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EnumerableMax | .NET 10.0 | .NET 10.0 | 100000000 | 17,070,801.04 ns | 147,517.542 ns | 137,988.000 ns |  0.52 |    0.00 |         - |          NA |
|               |           |           |           |                  |                |                |       |         |           |             |
| MaxWithLoop   | .NET 9.0  | .NET 9.0  | 100000000 | 32,918,838.94 ns |  87,376.873 ns |  72,963.646 ns |  1.00 |    0.00 |         - |          NA |
| EnumerableMax | .NET 9.0  | .NET 9.0  | 100000000 | 16,931,246.46 ns | 134,121.102 ns | 125,456.962 ns |  0.51 |    0.00 |         - |          NA |
