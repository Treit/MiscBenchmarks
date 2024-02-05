# Looping over an array vs. a list.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method           | Count  | Mean           | Error         | StdDev         | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |------- |---------------:|--------------:|---------------:|------:|--------:|----------:|------------:|
| **ForLoopArray**     | **10**     |       **4.588 ns** |     **0.1553 ns** |      **0.4479 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ForEachLoopArray | 10     |       3.803 ns |     0.1146 ns |      0.0895 ns |  0.77 |    0.06 |         - |          NA |
| ForLoopList      | 10     |      12.564 ns |     0.2873 ns |      0.7363 ns |  2.75 |    0.32 |         - |          NA |
| ForEachLoopList  | 10     |      11.612 ns |     0.2672 ns |      0.5695 ns |  2.50 |    0.26 |         - |          NA |
|                  |        |                |               |                |       |         |           |             |
| **ForLoopArray**     | **100000** | **143,946.879 ns** | **3,201.0649 ns** |  **9,388.1691 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ForEachLoopArray | 100000 | 141,808.327 ns | 3,249.5172 ns |  9,581.2748 ns |  0.99 |    0.09 |         - |          NA |
| ForLoopList      | 100000 | 152,587.442 ns | 4,053.0263 ns | 11,693.9075 ns |  1.07 |    0.11 |         - |          NA |
| ForEachLoopList  | 100000 | 148,974.359 ns | 2,979.3963 ns |  6,602.1363 ns |  1.03 |    0.07 |         - |          NA |
