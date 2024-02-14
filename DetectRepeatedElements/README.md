# Detect repeated elements
Benchmark from discussion: https://discord.com/channels/143867839282020352/143867839282020352/1207383950109179905


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26058.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                | Length | ElementToDuplicate | Mean              | Error            | StdDev           | Median            | Gen0     | Gen1     | Gen2     | Allocated |
|---------------------- |------- |------------------- |------------------:|-----------------:|-----------------:|------------------:|---------:|---------:|---------:|----------:|
| **Linq**                  | **10**     | **Middle**             |         **700.10 ns** |        **12.816 ns** |        **22.106 ns** |         **695.27 ns** |   **0.3166** |        **-** |        **-** |    **1368 B** |
| Hazel                 | 10     | Middle             |         587.66 ns |        16.189 ns |        46.966 ns |         579.86 ns |   0.3004 |        - |        - |    1296 B |
| Dictionary            | 10     | Middle             |         355.60 ns |         7.143 ns |        18.438 ns |         350.70 ns |   0.2298 |        - |        - |     992 B |
| Sane                  | 10     | Middle             |         131.16 ns |         2.881 ns |         8.125 ns |         128.33 ns |   0.0684 |        - |        - |     296 B |
| Mtreit_A_HashSet      | 10     | Middle             |         179.12 ns |         4.992 ns |        14.242 ns |         174.92 ns |   0.0758 |        - |        - |     328 B |
| Mtreit_B_BitArray     | 10     | Middle             |          40.16 ns |         0.832 ns |         1.457 ns |          40.03 ns |   0.0148 |        - |        - |      64 B |
| Mtreit_C_LinearSearch | 10     | Middle             |          35.04 ns |         0.731 ns |         1.738 ns |          34.58 ns |        - |        - |        - |         - |
| **Linq**                  | **10000**  | **Middle**             |   **2,116,378.23 ns** |    **87,788.460 ns** |   **258,846.255 ns** |   **2,105,642.19 ns** | **179.6875** | **136.7188** |  **50.7813** | **1142577 B** |
| Hazel                 | 10000  | Middle             | 261,174,600.00 ns | 4,664,635.506 ns | 4,135,077.877 ns | 260,725,325.00 ns |        - |        - |        - | 1203168 B |
| Dictionary            | 10000  | Middle             |     583,969.60 ns |    11,643.348 ns |    27,671.648 ns |     580,640.67 ns | 221.6797 | 221.6797 | 221.6797 |  942083 B |
| Sane                  | 10000  | Middle             |     172,828.85 ns |     4,157.086 ns |    11,792.962 ns |     169,834.91 ns |  38.3301 |  38.3301 |  38.3301 |  161781 B |
| Mtreit_A_HashSet      | 10000  | Middle             |     172,210.09 ns |     3,408.810 ns |     8,552.039 ns |     171,450.82 ns |  38.3301 |  38.3301 |  38.3301 |  161814 B |
| Mtreit_B_BitArray     | 10000  | Middle             |      17,728.50 ns |       340.139 ns |       781.526 ns |      17,387.49 ns |   0.2747 |        - |        - |    1312 B |
| Mtreit_C_LinearSearch | 10000  | Middle             |   4,781,250.84 ns |    58,959.715 ns |    52,266.252 ns |   4,763,301.17 ns |        - |        - |        - |       1 B |
