## Reading integers from a file on disk.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Job       | Runtime   | Count   | Mean         | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |---------- |---------- |-------- |-------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **SumDataBitConverter**                      | **.NET 10.0** | **.NET 10.0** | **100**     |     **64.26 μs** |  **0.293 μs** |  **0.244 μs** |  **0.98** |    **0.01** | **0.2441** |   **4.57 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | .NET 10.0 | .NET 10.0 | 100     |     64.77 μs |  0.596 μs |  0.528 μs |  0.99 |    0.01 | 0.2441 |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCast                 | .NET 10.0 | .NET 10.0 | 100     |     66.73 μs |  0.836 μs |  0.742 μs |  1.02 |    0.01 | 0.2441 |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | .NET 10.0 | .NET 10.0 | 100     |     65.25 μs |  0.547 μs |  0.512 μs |  1.00 |    0.01 | 0.2441 |   4.54 KB |        1.00 |
|                                          |           |           |         |              |           |           |       |         |        |           |             |
| SumDataBitConverter                      | .NET 9.0  | .NET 9.0  | 100     |     64.18 μs |  0.915 μs |  0.856 μs |  0.98 |    0.01 | 0.2441 |   4.56 KB |        1.01 |
| SumDataBinaryPrimitives                  | .NET 9.0  | .NET 9.0  | 100     |     66.35 μs |  0.823 μs |  0.770 μs |  1.01 |    0.01 | 0.2441 |   4.53 KB |        1.00 |
| SumDataMemoryMarshalCast                 | .NET 9.0  | .NET 9.0  | 100     |     66.34 μs |  0.945 μs |  0.884 μs |  1.01 |    0.01 | 0.2441 |   4.53 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | .NET 9.0  | .NET 9.0  | 100     |     65.77 μs |  0.512 μs |  0.454 μs |  1.00 |    0.01 | 0.2441 |   4.53 KB |        1.00 |
|                                          |           |           |         |              |           |           |       |         |        |           |             |
| **SumDataBitConverter**                      | **.NET 10.0** | **.NET 10.0** | **1000000** | **10,870.08 μs** | **94.661 μs** | **83.914 μs** |  **4.06** |    **0.04** |      **-** |   **4.57 KB** |        **1.01** |
| SumDataBinaryPrimitives                  | .NET 10.0 | .NET 10.0 | 1000000 |  4,969.83 μs | 24.595 μs | 19.202 μs |  1.86 |    0.01 |      - |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCast                 | .NET 10.0 | .NET 10.0 | 1000000 |  4,985.50 μs | 19.687 μs | 17.452 μs |  1.86 |    0.01 |      - |   4.54 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | .NET 10.0 | .NET 10.0 | 1000000 |  2,674.58 μs | 18.071 μs | 15.090 μs |  1.00 |    0.01 |      - |   4.54 KB |        1.00 |
|                                          |           |           |         |              |           |           |       |         |        |           |             |
| SumDataBitConverter                      | .NET 9.0  | .NET 9.0  | 1000000 | 10,585.03 μs | 13.680 μs | 11.423 μs |  3.94 |    0.06 |      - |   4.57 KB |        1.01 |
| SumDataBinaryPrimitives                  | .NET 9.0  | .NET 9.0  | 1000000 |  4,996.85 μs | 14.356 μs | 13.429 μs |  1.86 |    0.03 |      - |   4.53 KB |        1.00 |
| SumDataMemoryMarshalCast                 | .NET 9.0  | .NET 9.0  | 1000000 |  4,960.54 μs | 15.322 μs | 14.332 μs |  1.84 |    0.03 |      - |   4.53 KB |        1.00 |
| SumDataMemoryMarshalCastAndVectorizedSum | .NET 9.0  | .NET 9.0  | 1000000 |  2,689.66 μs | 52.299 μs | 46.362 μs |  1.00 |    0.02 |      - |   4.53 KB |        1.00 |
