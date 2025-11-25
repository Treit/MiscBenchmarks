## Reading integers from a file on disk.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count   | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |-------- |-------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **SumDataBitConverter**                      | **100**     |     **70.50 μs** |   **0.893 μs** |   **0.835 μs** |  **0.95** |    **0.02** | **0.2441** |   **4.57 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | 100     |     75.13 μs |   0.834 μs |   0.780 μs |  1.01 |    0.02 | 0.2441 |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCast                 | 100     |     73.62 μs |   1.453 μs |   2.765 μs |  0.99 |    0.04 | 0.2441 |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | 100     |     74.30 μs |   1.361 μs |   1.206 μs |  1.00 |    0.02 | 0.2441 |   4.54 KB |        1.00 |
|                                          |         |              |            |            |       |         |        |           |             |
| **SumDataBitConverter**                      | **1000000** | **11,645.99 μs** | **233.101 μs** | **334.307 μs** |  **3.07** |    **0.16** |      **-** |   **4.57 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | 1000000 |  6,185.51 μs |  25.583 μs |  23.931 μs |  1.63 |    0.07 |      - |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCast                 | 1000000 |  6,100.52 μs | 121.754 μs | 291.714 μs |  1.61 |    0.10 |      - |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | 1000000 |  3,805.59 μs |  74.584 μs | 140.087 μs |  1.00 |    0.06 |      - |   4.54 KB |        1.00 |
