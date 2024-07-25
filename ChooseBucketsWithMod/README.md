# Handling negative hash codes when using mod to choose a bucket

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26257.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | BucketCount | KeyCount | Mean         | Error      | StdDev     | Median       | Allocated |
|----------------------------------- |------------ |--------- |-------------:|-----------:|-----------:|-------------:|----------:|
| **IndexViaAdditionAndTwoMods**         | **2**           | **2**        |     **39.91 ns** |   **0.260 ns** |   **0.231 ns** |     **39.94 ns** |         **-** |
| IndexViaMathAbs                    | 2           | 2        |     30.41 ns |   0.638 ns |   1.577 ns |     29.99 ns |         - |
| IndexViaHandlingNegativeExplicitly | 2           | 2        |     26.90 ns |   0.555 ns |   0.722 ns |     26.57 ns |         - |
| **IndexViaAdditionAndTwoMods**         | **2**           | **1000**     | **20,340.86 ns** | **190.286 ns** | **177.993 ns** | **20,329.05 ns** |         **-** |
| IndexViaMathAbs                    | 2           | 1000     | 15,174.54 ns | 232.553 ns | 217.530 ns | 15,122.66 ns |         - |
| IndexViaHandlingNegativeExplicitly | 2           | 1000     | 14,448.95 ns |  93.694 ns |  83.057 ns | 14,411.83 ns |         - |
| **IndexViaAdditionAndTwoMods**         | **100000**      | **2**        |     **39.45 ns** |   **0.616 ns** |   **0.633 ns** |     **39.31 ns** |         **-** |
| IndexViaMathAbs                    | 100000      | 2        |     29.99 ns |   0.606 ns |   1.429 ns |     29.34 ns |         - |
| IndexViaHandlingNegativeExplicitly | 100000      | 2        |     28.06 ns |   0.872 ns |   2.461 ns |     27.05 ns |         - |
| **IndexViaAdditionAndTwoMods**         | **100000**      | **1000**     | **19,860.89 ns** | **139.316 ns** | **130.316 ns** | **19,858.42 ns** |         **-** |
| IndexViaMathAbs                    | 100000      | 1000     | 15,005.24 ns | 288.210 ns | 331.904 ns | 14,921.53 ns |         - |
| IndexViaHandlingNegativeExplicitly | 100000      | 1000     | 14,731.55 ns | 238.423 ns | 223.021 ns | 14,693.69 ns |         - |
