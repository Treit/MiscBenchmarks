# List\<T> vs ReadOnlyMemory\<T> Benchmark

Comparing the performance of `List<T>` vs `ReadOnlyMemory<T>` and `Memory<T>` for various operations.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27887.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                     | Count | Mean         | Error      | StdDev     | Median       | Ratio  | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|-------:|----------:|------------:|
| **ReadList**                   | **100**   |     **65.96 ns** |   **1.355 ns** |   **3.867 ns** |     **64.95 ns** |   **1.00** |    **0.08** |      **-** |      **-** |         **-** |          **NA** |
| ReadReadOnlyMemory         | 100   |     40.33 ns |   0.838 ns |   1.060 ns |     40.33 ns |   0.61 |    0.04 |      - |      - |         - |          NA |
| ReadMemory                 | 100   |     40.42 ns |   0.842 ns |   1.701 ns |     40.15 ns |   0.61 |    0.04 |      - |      - |         - |          NA |
| ReadListForeach            | 100   |     66.90 ns |   1.291 ns |   3.556 ns |     65.70 ns |   1.02 |    0.08 |      - |      - |         - |          NA |
| ReadReadOnlyMemoryForeach  | 100   |     40.87 ns |   0.849 ns |   1.371 ns |     40.59 ns |   0.62 |    0.04 |      - |      - |         - |          NA |
| WriteList                  | 100   |    119.69 ns |   2.443 ns |   5.992 ns |    117.53 ns |   1.82 |    0.14 |      - |      - |         - |          NA |
| WriteMemory                | 100   |     46.09 ns |   0.934 ns |   1.369 ns |     45.96 ns |   0.70 |    0.04 |      - |      - |         - |          NA |
| RandomAccessList           | 100   | 10,124.82 ns | 185.622 ns | 320.190 ns | 10,050.24 ns | 153.99 |    9.81 |      - |      - |         - |          NA |
| RandomAccessReadOnlyMemory | 100   | 10,322.85 ns | 141.584 ns | 125.511 ns | 10,317.11 ns | 157.00 |    8.90 |      - |      - |         - |          NA |
| CreateList                 | 100   |    196.52 ns |   4.010 ns |   8.190 ns |    195.99 ns |   2.99 |    0.21 | 0.1056 |      - |     456 B |          NA |
| CreateReadOnlyMemory       | 100   |     74.01 ns |   1.310 ns |   1.509 ns |     74.02 ns |   1.13 |    0.07 | 0.0982 |      - |     424 B |          NA |
|                            |       |              |            |            |              |        |         |        |        |           |             |
| **ReadList**                   | **10000** |  **5,641.73 ns** | **111.117 ns** | **231.943 ns** |  **5,562.43 ns** |   **1.00** |    **0.06** |      **-** |      **-** |         **-** |          **NA** |
| ReadReadOnlyMemory         | 10000 |  3,687.76 ns |  69.898 ns |  61.963 ns |  3,680.94 ns |   0.65 |    0.03 |      - |      - |         - |          NA |
| ReadMemory                 | 10000 |  3,858.20 ns |  72.087 ns | 161.232 ns |  3,825.22 ns |   0.68 |    0.04 |      - |      - |         - |          NA |
| ReadListForeach            | 10000 |  5,834.21 ns | 116.549 ns | 201.042 ns |  5,773.64 ns |   1.04 |    0.05 |      - |      - |         - |          NA |
| ReadReadOnlyMemoryForeach  | 10000 |  3,771.46 ns |  73.012 ns |  78.123 ns |  3,760.07 ns |   0.67 |    0.03 |      - |      - |         - |          NA |
| WriteList                  | 10000 | 13,070.63 ns | 127.444 ns | 119.211 ns | 13,028.28 ns |   2.32 |    0.09 |      - |      - |         - |          NA |
| WriteMemory                | 10000 |  3,765.21 ns |  75.276 ns | 152.062 ns |  3,726.58 ns |   0.67 |    0.04 |      - |      - |         - |          NA |
| RandomAccessList           | 10000 | 11,480.24 ns | 226.035 ns | 358.516 ns | 11,358.00 ns |   2.04 |    0.10 |      - |      - |         - |          NA |
| RandomAccessReadOnlyMemory | 10000 | 10,116.57 ns |  96.886 ns |  85.887 ns | 10,127.16 ns |   1.80 |    0.07 |      - |      - |         - |          NA |
| CreateList                 | 10000 | 17,448.01 ns | 307.368 ns | 256.667 ns | 17,441.54 ns |   3.10 |    0.13 | 9.2468 | 1.0071 |   40056 B |          NA |
| CreateReadOnlyMemory       | 10000 |  6,183.75 ns |  88.917 ns |  83.173 ns |  6,180.90 ns |   1.10 |    0.05 | 9.1705 | 1.1444 |   40024 B |          NA |
