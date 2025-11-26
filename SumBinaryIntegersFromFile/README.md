## Reading integers from a file on disk.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count   | Mean         | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |-------- |-------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **SumDataBitConverter**                      | **100**     |     **65.09 μs** |  **1.049 μs** |  **0.876 μs** |  **0.98** |    **0.02** | **0.2441** |   **4.57 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | 100     |     66.60 μs |  0.805 μs |  0.753 μs |  1.00 |    0.02 | 0.2441 |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCast                 | 100     |     66.61 μs |  0.998 μs |  0.934 μs |  1.00 |    0.02 | 0.2441 |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | 100     |     66.58 μs |  0.936 μs |  0.875 μs |  1.00 |    0.02 | 0.2441 |   4.54 KB |        1.00 |
|                                          |         |              |           |           |       |         |        |           |             |
| **SumDataBitConverter**                      | **1000000** | **10,679.86 μs** | **91.748 μs** | **85.821 μs** |  **3.96** |    **0.05** |      **-** |   **4.57 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | 1000000 |  5,067.98 μs | 48.430 μs | 45.302 μs |  1.88 |    0.02 |      - |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCast                 | 1000000 |  5,053.72 μs | 32.493 μs | 27.133 μs |  1.87 |    0.02 |      - |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | 1000000 |  2,699.45 μs | 27.486 μs | 24.366 μs |  1.00 |    0.01 |      - |   4.54 KB |        1.00 |
