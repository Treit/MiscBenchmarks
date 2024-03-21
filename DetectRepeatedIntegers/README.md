# Detect repeated elements
Benchmark from discussion: https://discord.com/channels/143867839282020352/143867839282020352/1207383950109179905



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26058.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | Length | ElementToDuplicate | Mean              | Error            | StdDev           | Gen0     | Gen1     | Gen2     | Allocated |
|------------------------------------- |------- |------------------- |------------------:|-----------------:|-----------------:|---------:|---------:|---------:|----------:|
| **Linq**                                 | **10**     | **Middle**             |         **711.36 ns** |        **19.938 ns** |        **58.474 ns** |   **0.3166** |        **-** |        **-** |    **1368 B** |
| Hazel_LINQ_Any_With_Count            | 10     | Middle             |         580.03 ns |        13.779 ns |        40.193 ns |   0.3004 |        - |        - |    1296 B |
| Dictionary                           | 10     | Middle             |         337.00 ns |         6.732 ns |        11.431 ns |   0.2298 |        - |        - |     992 B |
| Aaron_Sane_HashSet_With_ShortCircuit | 10     | Middle             |         119.03 ns |         2.389 ns |         2.453 ns |   0.0684 |        - |        - |     296 B |
| Mtreit_A_HashSet                     | 10     | Middle             |         204.04 ns |        10.648 ns |        30.723 ns |   0.0758 |        - |        - |     328 B |
| Mtreit_B_BitArray                    | 10     | Middle             |          39.20 ns |         0.702 ns |         0.751 ns |   0.0148 |        - |        - |      64 B |
| Mtreit_C_LinearSearch                | 10     | Middle             |          36.63 ns |         0.774 ns |         0.829 ns |        - |        - |        - |         - |
| **Linq**                                 | **10000**  | **Middle**             |   **2,123,193.75 ns** |    **75,887.538 ns** |   **218,952.899 ns** | **164.0625** | **128.9063** |  **62.5000** | **1142559 B** |
| Hazel_LINQ_Any_With_Count            | 10000  | Middle             | 285,991,905.81 ns | 5,279,432.737 ns | 9,785,767.090 ns |        - |        - |        - | 1200296 B |
| Dictionary                           | 10000  | Middle             |     513,849.38 ns |     8,748.928 ns |    10,075.278 ns | 221.6797 | 221.6797 | 221.6797 |  942083 B |
| Aaron_Sane_HashSet_With_ShortCircuit | 10000  | Middle             |     166,318.46 ns |     3,236.997 ns |     4,744.748 ns |  38.3301 |  38.3301 |  38.3301 |  161781 B |
| Mtreit_A_HashSet                     | 10000  | Middle             |     168,158.70 ns |     2,917.652 ns |     3,121.855 ns |  38.3301 |  38.3301 |  38.3301 |  161813 B |
| Mtreit_B_BitArray                    | 10000  | Middle             |      17,988.06 ns |       246.009 ns |       218.081 ns |   0.2747 |        - |        - |    1312 B |
| Mtreit_C_LinearSearch                | 10000  | Middle             |   5,089,271.41 ns |    84,013.201 ns |    78,586.001 ns |        - |        - |        - |       3 B |
