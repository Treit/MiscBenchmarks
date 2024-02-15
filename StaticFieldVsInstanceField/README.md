# Instance vs. Static fields.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26058.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method             | Count | Mean        | Error     | StdDev     | Median      | Allocated |
|------------------- |------ |------------:|----------:|-----------:|------------:|----------:|
| **ReadInstanceField**  | **1**     |   **0.5213 ns** | **0.0467 ns** |  **0.0853 ns** |   **0.4973 ns** |         **-** |
| ReadStaticField    | 1     |   0.2363 ns | 0.0784 ns |  0.2147 ns |   0.1667 ns |         - |
| WriteInstanceField | 1     |   4.6627 ns | 0.1302 ns |  0.3607 ns |   4.5875 ns |         - |
| WriteStaticField   | 1     |   4.5224 ns | 0.1307 ns |  0.3750 ns |   4.4044 ns |         - |
| **ReadInstanceField**  | **100**   |  **42.8119 ns** | **1.5813 ns** |  **4.4600 ns** |  **41.2665 ns** |         **-** |
| ReadStaticField    | 100   |  45.5365 ns | 3.6983 ns | 10.9044 ns |  40.3625 ns |         - |
| WriteInstanceField | 100   | 433.4913 ns | 8.6763 ns | 11.2816 ns | 432.0242 ns |         - |
| WriteStaticField   | 100   | 416.2112 ns | 8.3589 ns | 19.7029 ns | 411.0767 ns |         - |
