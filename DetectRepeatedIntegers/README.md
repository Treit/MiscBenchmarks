# Detect repeated elements
Benchmark from discussion: https://discord.com/channels/143867839282020352/143867839282020352/1207383950109179905





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Job       | Runtime   | Length | ElementToDuplicate | Mean             | Error          | StdDev         | Gen0     | Gen1     | Gen2     | Allocated |
|------------------------------------- |---------- |---------- |------- |------------------- |-----------------:|---------------:|---------------:|---------:|---------:|---------:|----------:|
| **Linq**                                 | **.NET 10.0** | **.NET 10.0** | **10**     | **Middle**             |        **429.38 ns** |       **3.792 ns** |       **3.547 ns** |   **0.0782** |        **-** |        **-** |    **1312 B** |
| Hazel_LINQ_Any_With_Count            | .NET 10.0 | .NET 10.0 | 10     | Middle             |        150.48 ns |       3.031 ns |       3.490 ns |   0.0525 |        - |        - |     880 B |
| Dictionary                           | .NET 10.0 | .NET 10.0 | 10     | Middle             |        183.56 ns |       1.813 ns |       1.696 ns |   0.0544 |        - |        - |     912 B |
| Aaron_Sane_HashSet_With_ShortCircuit | .NET 10.0 | .NET 10.0 | 10     | Middle             |         69.82 ns |       1.139 ns |       1.066 ns |   0.0138 |        - |        - |     232 B |
| Mtreit_A_HashSet                     | .NET 10.0 | .NET 10.0 | 10     | Middle             |         97.32 ns |       1.649 ns |       1.461 ns |   0.0176 |        - |        - |     296 B |
| Mtreit_B_BitArray                    | .NET 10.0 | .NET 10.0 | 10     | Middle             |         20.44 ns |       0.124 ns |       0.110 ns |   0.0019 |        - |        - |      32 B |
| Mtreit_C_LinearSearch                | .NET 10.0 | .NET 10.0 | 10     | Middle             |         16.49 ns |       0.159 ns |       0.141 ns |        - |        - |        - |         - |
| Linq                                 | .NET 9.0  | .NET 9.0  | 10     | Middle             |        404.31 ns |       3.012 ns |       2.670 ns |   0.0782 |        - |        - |    1312 B |
| Hazel_LINQ_Any_With_Count            | .NET 9.0  | .NET 9.0  | 10     | Middle             |        150.54 ns |       2.944 ns |       3.024 ns |   0.0525 |        - |        - |     880 B |
| Dictionary                           | .NET 9.0  | .NET 9.0  | 10     | Middle             |        161.27 ns |       1.921 ns |       1.703 ns |   0.0544 |        - |        - |     912 B |
| Aaron_Sane_HashSet_With_ShortCircuit | .NET 9.0  | .NET 9.0  | 10     | Middle             |         69.68 ns |       0.906 ns |       0.847 ns |   0.0138 |        - |        - |     232 B |
| Mtreit_A_HashSet                     | .NET 9.0  | .NET 9.0  | 10     | Middle             |         98.96 ns |       1.261 ns |       1.179 ns |   0.0176 |        - |        - |     296 B |
| Mtreit_B_BitArray                    | .NET 9.0  | .NET 9.0  | 10     | Middle             |         20.55 ns |       0.177 ns |       0.148 ns |   0.0019 |        - |        - |      32 B |
| Mtreit_C_LinearSearch                | .NET 9.0  | .NET 9.0  | 10     | Middle             |         16.59 ns |       0.159 ns |       0.149 ns |        - |        - |        - |         - |
| **Linq**                                 | **.NET 10.0** | **.NET 10.0** | **10000**  | **Middle**             |    **835,545.84 ns** |   **8,427.339 ns** |   **7,470.617 ns** |  **82.0313** |  **81.0547** |  **41.0156** | **1142494 B** |
| Hazel_LINQ_Any_With_Count            | .NET 10.0 | .NET 10.0 | 10000  | Middle             | 37,103,705.71 ns | 637,211.295 ns | 596,047.841 ns |        - |        - |        - |  880000 B |
| Dictionary                           | .NET 10.0 | .NET 10.0 | 10000  | Middle             |    311,168.74 ns |   3,023.495 ns |   2,828.179 ns | 222.1680 | 222.1680 | 222.1680 |  942083 B |
| Aaron_Sane_HashSet_With_ShortCircuit | .NET 10.0 | .NET 10.0 | 10000  | Middle             |     99,924.97 ns |     610.635 ns |     571.188 ns |  38.4521 |  38.4521 |  38.4521 |  161717 B |
| Mtreit_A_HashSet                     | .NET 10.0 | .NET 10.0 | 10000  | Middle             |    108,821.47 ns |     538.061 ns |     503.303 ns |  38.4521 |  38.4521 |  38.4521 |  161781 B |
| Mtreit_B_BitArray                    | .NET 10.0 | .NET 10.0 | 10000  | Middle             |     16,150.16 ns |     143.763 ns |     134.476 ns |   0.0610 |        - |        - |    1280 B |
| Mtreit_C_LinearSearch                | .NET 10.0 | .NET 10.0 | 10000  | Middle             |  2,771,777.11 ns |  39,867.665 ns |  37,292.239 ns |        - |        - |        - |         - |
| Linq                                 | .NET 9.0  | .NET 9.0  | 10000  | Middle             |    850,235.55 ns |  10,280.362 ns |   9,616.257 ns |  82.0313 |  81.0547 |  41.0156 | 1142494 B |
| Hazel_LINQ_Any_With_Count            | .NET 9.0  | .NET 9.0  | 10000  | Middle             | 36,898,110.37 ns | 697,490.979 ns | 652,433.495 ns |        - |        - |        - |  880000 B |
| Dictionary                           | .NET 9.0  | .NET 9.0  | 10000  | Middle             |    312,946.11 ns |   1,673.853 ns |   1,565.724 ns | 222.1680 | 222.1680 | 222.1680 |  942083 B |
| Aaron_Sane_HashSet_With_ShortCircuit | .NET 9.0  | .NET 9.0  | 10000  | Middle             |     99,453.12 ns |     747.672 ns |     662.792 ns |  38.4521 |  38.4521 |  38.4521 |  161717 B |
| Mtreit_A_HashSet                     | .NET 9.0  | .NET 9.0  | 10000  | Middle             |    114,680.72 ns |     648.680 ns |     575.038 ns |  38.4521 |  38.4521 |  38.4521 |  161781 B |
| Mtreit_B_BitArray                    | .NET 9.0  | .NET 9.0  | 10000  | Middle             |     16,159.28 ns |     126.824 ns |     118.631 ns |   0.0610 |        - |        - |    1280 B |
| Mtreit_C_LinearSearch                | .NET 9.0  | .NET 9.0  | 10000  | Middle             |  3,995,262.00 ns |  36,938.612 ns |  32,745.117 ns |        - |        - |        - |         - |
