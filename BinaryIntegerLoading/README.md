## Reading integers from a file on disk.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                  | Count   | Mean         | Error      | StdDev     | Median       | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------------------- |-------- |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|----------:|------------:|
| **ReadDataUsingBitConverter**                               | **100**     |     **60.99 μs** |   **1.191 μs** |   **1.957 μs** |     **60.46 μs** |  **0.95** |    **0.04** | **1.0376** |   **4.59 KB** |        **1.01** |
| ReadDataUsingBinaryPrimitivesAndSpan                    | 100     |     62.78 μs |   1.073 μs |   1.148 μs |     62.42 μs |  0.97 |    0.04 | 0.9766 |   4.55 KB |        1.00 |
| ReadDataUsingBinaryPrimitivesAndSpanWithReinterpretCast | 100     |     64.23 μs |   1.265 μs |   2.467 μs |     63.61 μs |  1.00 |    0.00 | 0.9766 |   4.55 KB |        1.00 |
|                                                         |         |              |            |            |              |       |         |        |           |             |
| **ReadDataUsingBitConverter**                               | **1000000** | **17,909.32 μs** | **354.623 μs** | **889.680 μs** | **17,486.83 μs** |  **3.50** |    **0.23** |      **-** |    **4.6 KB** |        **1.01** |
| ReadDataUsingBinaryPrimitivesAndSpan                    | 1000000 |  7,369.26 μs | 146.436 μs | 232.263 μs |  7,291.53 μs |  1.43 |    0.08 |      - |   4.56 KB |        1.00 |
| ReadDataUsingBinaryPrimitivesAndSpanWithReinterpretCast | 1000000 |  5,150.10 μs | 101.404 μs | 200.161 μs |  5,083.58 μs |  1.00 |    0.00 |      - |   4.56 KB |        1.00 |
