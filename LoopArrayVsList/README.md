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
| **ForLoopArray**     | **10**     |      **4.216 ns** |     **0.0244 ns** |     **0.0216 ns** |      **4.221 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ForEachLoopArray | 10     |      4.223 ns |     0.0250 ns |     0.0234 ns |      4.227 ns |  1.00 |    0.01 |         - |          NA |
| ForLoopList      | 10     |      8.275 ns |     0.1425 ns |     0.1333 ns |      8.238 ns |  1.96 |    0.03 |         - |          NA |
| ForEachLoopList  | 10     |      8.602 ns |     0.0993 ns |     0.0929 ns |      8.591 ns |  2.04 |    0.02 |         - |          NA |
|                  |        |               |               |               |               |       |         |           |             |
| **ForLoopArray**     | **100000** | **63,427.877 ns** | **2,335.5447 ns** | **6,886.4068 ns** | **67,716.522 ns** |  **1.01** |    **0.16** |         **-** |          **NA** |
| ForEachLoopArray | 100000 | 64,298.475 ns | 2,345.2432 ns | 6,915.0029 ns | 67,868.451 ns |  1.03 |    0.16 |         - |          NA |
| ForLoopList      | 100000 | 72,357.262 ns |   680.3863 ns |   636.4337 ns | 72,174.133 ns |  1.16 |    0.13 |         - |          NA |
| ForEachLoopList  | 100000 | 75,858.456 ns |   751.9129 ns |   703.3398 ns | 75,932.178 ns |  1.21 |    0.14 |         - |          NA |
