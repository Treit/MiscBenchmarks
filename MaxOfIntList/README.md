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
| **MaxWithLoop**   | **1000**      |        **513.02 ns** |      **10.233 ns** |      **26.416 ns** |  **1.00** |    **0.07** |         **-** |          **NA** |
| EnumerableMax | 1000      |         51.77 ns |       0.207 ns |       0.173 ns |  0.10 |    0.01 |         - |          NA |
|               |           |                  |                |                |       |         |           |             |
| **MaxWithLoop**   | **100000000** | **33,639,577.78 ns** | **456,780.430 ns** | **427,272.698 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| EnumerableMax | 100000000 | 18,024,239.79 ns | 161,397.614 ns | 150,971.428 ns |  0.54 |    0.01 |         - |          NA |
