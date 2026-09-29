# Strided positive diagonal matrix access

Compares dense multidimensional, jagged, flat row-major, and compressed diagonal storage when summing values from positive diagonals selected at fixed intervals.

A positive diagonal with offset `d` contains coordinates `(row, row + d)`. The benchmark selects offsets `1, 1 + DiagonalStride, 1 + 2 * DiagonalStride, ...` while each offset is less than the matrix size.


```

BenchmarkDotNet v0.16.0-preview.1, Windows 11 (10.0.22631.7582/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 63.95 GB Total, 43.58 GB Available
.NET SDK 11.0.100-rc.1.26425.128
  [Host]     : .NET 11.0.0 (11.0.0-rc.1.26425.128, 11.0.26.42628), X64 RyuJIT x86-64-v3
  Job-IHFIKV : .NET 11.0.0 (11.0.0-rc.1.26425.128, 11.0.26.42628), X64 RyuJIT x86-64-v3

Runtime=.NET 11.0  

```
| Method                 | Size | DiagonalStride | Mean           | Error        | StdDev        | Median         | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |----- |--------------- |---------------:|-------------:|--------------:|---------------:|------:|--------:|----------:|------------:|
| **SumMultiDimensional**    | **256**  | **8**              |     **4,740.8 ns** |     **42.78 ns** |      **35.72 ns** |     **4,754.3 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 256  | 8              |     2,965.2 ns |     16.23 ns |      12.67 ns |     2,967.5 ns |  0.63 |    0.01 |         - |          NA |
| SumFlat                | 256  | 8              |     1,688.6 ns |     21.67 ns |      20.27 ns |     1,688.3 ns |  0.36 |    0.00 |         - |          NA |
| SumCompressedDiagonals | 256  | 8              |     1,744.9 ns |     14.42 ns |      13.49 ns |     1,744.9 ns |  0.37 |    0.00 |         - |          NA |
|                        |      |                |                |              |               |                |       |         |           |             |
| **SumMultiDimensional**    | **256**  | **64**             |       **719.0 ns** |      **5.31 ns** |       **4.43 ns** |       **720.1 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 256  | 64             |       542.3 ns |      8.95 ns |       7.93 ns |       542.4 ns |  0.75 |    0.01 |         - |          NA |
| SumFlat                | 256  | 64             |       362.9 ns |      2.94 ns |       2.75 ns |       363.7 ns |  0.50 |    0.00 |         - |          NA |
| SumCompressedDiagonals | 256  | 64             |       260.0 ns |      5.04 ns |       7.22 ns |       259.9 ns |  0.36 |    0.01 |         - |          NA |
|                        |      |                |                |              |               |                |       |         |           |             |
| **SumMultiDimensional**    | **4096** | **8**              | **3,600,008.7 ns** | **71,560.44 ns** | **204,165.97 ns** | **3,529,626.4 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 4096 | 8              | 4,304,684.9 ns | 75,756.39 ns | 111,042.74 ns | 4,293,379.7 ns |  1.20 |    0.07 |         - |          NA |
| SumFlat                | 4096 | 8              | 4,047,007.2 ns | 75,035.07 ns | 125,366.76 ns | 4,005,311.3 ns |  1.13 |    0.07 |         - |          NA |
| SumCompressedDiagonals | 4096 | 8              |   375,603.7 ns |  4,159.22 ns |   3,890.53 ns |   376,220.4 ns |  0.10 |    0.01 |         - |          NA |
|                        |      |                |                |              |               |                |       |         |           |             |
| **SumMultiDimensional**    | **4096** | **64**             |   **469,498.5 ns** |  **2,662.82 ns** |   **2,360.52 ns** |   **469,080.3 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| SumJagged              | 4096 | 64             |   550,388.4 ns |  7,312.35 ns |   6,839.98 ns |   551,831.0 ns |  1.17 |    0.02 |         - |          NA |
| SumFlat                | 4096 | 64             |   529,197.0 ns |  9,091.87 ns |  10,470.21 ns |   529,436.1 ns |  1.13 |    0.02 |         - |          NA |
| SumCompressedDiagonals | 4096 | 64             |    47,550.0 ns |    804.52 ns |     752.55 ns |    47,353.6 ns |  0.10 |    0.00 |         - |          NA |
