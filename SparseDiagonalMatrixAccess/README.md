# Sparse positive diagonal matrix access

Compares dense multidimensional, jagged, flat row-major, and compressed diagonal storage when summing values from sparsely selected positive diagonals.

A positive diagonal with offset `d` contains coordinates `(row, row + d)`. The benchmark selects offsets `1, 1 + DiagonalStride, 1 + 2 * DiagonalStride, ...` while each offset is less than the matrix size.

```

BenchmarkDotNet v0.16.0-preview.1, Windows 11 (10.0.22631.7582/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 63.95 GB Total, 43.95 GB Available
.NET SDK 11.0.100-rc.1.26425.128
  [Host]     : .NET 11.0.0 (11.0.0-rc.1.26425.128, 11.0.26.42628), X64 RyuJIT x86-64-v3
  Job-IHFIKV : .NET 11.0.0 (11.0.0-rc.1.26425.128, 11.0.26.42628), X64 RyuJIT x86-64-v3

Runtime=.NET 11.0  

```
| Method                 | Size | DiagonalStride | Mean           | Error        | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |----- |--------------- |---------------:|-------------:|--------------:|------:|--------:|----------:|------------:|
| **SumMultiDimensional**    | **256**  | **8**              |     **4,734.3 ns** |     **42.37 ns** |      **39.64 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 256  | 8              |     2,950.4 ns |     15.40 ns |      14.40 ns |  0.62 |    0.01 |         - |          NA |
| SumFlat                | 256  | 8              |     1,681.1 ns |     20.05 ns |      17.77 ns |  0.36 |    0.00 |         - |          NA |
| SumCompressedDiagonals | 256  | 8              |     1,718.3 ns |     34.02 ns |      49.87 ns |  0.36 |    0.01 |         - |          NA |
|                        |      |                |                |              |               |       |         |           |             |
| **SumMultiDimensional**    | **256**  | **64**             |       **726.3 ns** |      **5.50 ns** |       **4.59 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 256  | 64             |       553.2 ns |     10.39 ns |      14.23 ns |  0.76 |    0.02 |         - |          NA |
| SumFlat                | 256  | 64             |       374.9 ns |      2.91 ns |       2.72 ns |  0.52 |    0.00 |         - |          NA |
| SumCompressedDiagonals | 256  | 64             |       254.9 ns |      4.96 ns |       5.91 ns |  0.35 |    0.01 |         - |          NA |
|                        |      |                |                |              |               |       |         |           |             |
| **SumMultiDimensional**    | **4096** | **8**              | **3,643,011.9 ns** | **66,554.08 ns** |  **58,998.46 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 4096 | 8              | 4,989,349.9 ns | 95,008.63 ns | 238,358.10 ns |  1.37 |    0.07 |         - |          NA |
| SumFlat                | 4096 | 8              | 4,282,541.3 ns | 70,687.51 ns |  66,121.14 ns |  1.18 |    0.03 |         - |          NA |
| SumCompressedDiagonals | 4096 | 8              |   381,119.4 ns |  3,359.66 ns |   3,142.63 ns |  0.10 |    0.00 |         - |          NA |
|                        |      |                |                |              |               |       |         |           |             |
| **SumMultiDimensional**    | **4096** | **64**             |   **486,942.1 ns** |  **9,513.44 ns** |   **8,898.88 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 4096 | 64             |   606,894.7 ns |  7,253.45 ns |   6,429.99 ns |  1.25 |    0.03 |         - |          NA |
| SumFlat                | 4096 | 64             |   577,481.6 ns |  9,992.91 ns |   9,347.38 ns |  1.19 |    0.03 |         - |          NA |
| SumCompressedDiagonals | 4096 | 64             |    47,586.4 ns |    528.82 ns |     468.78 ns |  0.10 |    0.00 |         - |          NA |
