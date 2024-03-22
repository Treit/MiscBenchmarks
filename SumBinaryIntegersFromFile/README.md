## Reading integers from a file on disk.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                   | Count   | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |-------- |-------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **SumDataBitConverter**                      | **100**     |     **64.21 μs** |   **1.270 μs** |   **3.456 μs** |  **0.98** |    **0.07** | **0.9766** |   **4.59 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | 100     |     67.39 μs |   1.330 μs |   2.805 μs |  1.03 |    0.06 | 0.9766 |   4.55 KB |        1.00 |
| SumDataMemoryMarshalCast                 | 100     |     64.39 μs |   1.260 μs |   2.545 μs |  0.98 |    0.07 | 0.9766 |   4.55 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | 100     |     65.87 μs |   1.315 μs |   2.745 μs |  1.00 |    0.00 | 0.9766 |   4.55 KB |        1.00 |
|                                          |         |              |            |            |       |         |        |           |             |
| **SumDataBitConverter**                      | **1000000** | **18,198.52 μs** | **359.663 μs** | **819.134 μs** |  **3.84** |    **0.15** |      **-** |   **4.59 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | 1000000 |  7,895.97 μs | 155.735 μs | 284.769 μs |  1.65 |    0.08 |      - |   4.56 KB |        1.00 |
| SumDataMemoryMarshalCast                 | 1000000 |  5,362.87 μs | 102.488 μs | 122.005 μs |  1.12 |    0.02 |      - |   4.56 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | 1000000 |  4,843.76 μs |  59.564 μs |  46.503 μs |  1.00 |    0.00 |      - |   4.56 KB |        1.00 |
