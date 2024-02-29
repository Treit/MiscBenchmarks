# Finding max value of an array of ints




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method        | Count   | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------- |-------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **MaxWithLoop**   | **1000**    |     **394.86 ns** |      **7.926 ns** |     **21.429 ns** |     **387.45 ns** |  **7.63** |    **0.36** |         **-** |          **NA** |
| EnumerableMax | 1000    |      52.69 ns |      0.865 ns |      0.767 ns |      52.55 ns |  1.00 |    0.00 |         - |          NA |
|               |         |               |               |               |               |       |         |           |             |
| **MaxWithLoop**   | **1000000** | **393,478.85 ns** | **13,379.548 ns** | **38,603.055 ns** | **381,792.50 ns** |  **3.05** |    **0.43** |         **-** |          **NA** |
| EnumerableMax | 1000000 | 130,437.69 ns |  4,334.770 ns | 12,713.131 ns | 128,087.89 ns |  1.00 |    0.00 |         - |          NA |
