# Detect repeated elements
Benchmark from discussion: https://discord.com/channels/143867839282020352/143867839282020352/1207383950109179905




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Length | ElementToDuplicate | Mean             | Error          | StdDev         | Median           | Gen0     | Gen1     | Gen2     | Allocated |
|------------------------------------- |------- |------------------- |-----------------:|---------------:|---------------:|-----------------:|---------:|---------:|---------:|----------:|
| **Linq**                                 | **10**     | **Middle**             |        **416.78 ns** |       **5.947 ns** |       **5.563 ns** |        **416.16 ns** |   **0.0782** |        **-** |        **-** |    **1312 B** |
| Hazel_LINQ_Any_With_Count            | 10     | Middle             |        124.98 ns |       2.086 ns |       1.951 ns |        124.84 ns |   0.0525 |        - |        - |     880 B |
| Dictionary                           | 10     | Middle             |        166.09 ns |       2.185 ns |       2.044 ns |        166.02 ns |   0.0544 |        - |        - |     912 B |
| Aaron_Sane_HashSet_With_ShortCircuit | 10     | Middle             |         68.78 ns |       0.692 ns |       0.647 ns |         68.91 ns |   0.0138 |        - |        - |     232 B |
| Mtreit_A_HashSet                     | 10     | Middle             |         93.56 ns |       0.801 ns |       0.710 ns |         93.64 ns |   0.0176 |        - |        - |     296 B |
| Mtreit_B_BitArray                    | 10     | Middle             |         20.10 ns |       0.175 ns |       0.155 ns |         20.10 ns |   0.0019 |        - |        - |      32 B |
| Mtreit_C_LinearSearch                | 10     | Middle             |         16.55 ns |       0.126 ns |       0.118 ns |         16.60 ns |        - |        - |        - |         - |
| **Linq**                                 | **10000**  | **Middle**             |    **863,772.99 ns** |  **16,516.958 ns** |  **19,020.953 ns** |    **869,808.89 ns** |  **82.0313** |  **81.0547** |  **41.0156** | **1142494 B** |
| Hazel_LINQ_Any_With_Count            | 10000  | Middle             | 37,063,463.27 ns | 379,194.008 ns | 336,145.611 ns | 37,203,085.71 ns |        - |        - |        - |  880000 B |
| Dictionary                           | 10000  | Middle             |    394,881.20 ns |  10,667.886 ns |  31,287.065 ns |    405,686.72 ns | 222.1680 | 222.1680 | 222.1680 |  942083 B |
| Aaron_Sane_HashSet_With_ShortCircuit | 10000  | Middle             |    120,373.35 ns |   3,119.959 ns |   9,199.270 ns |    123,050.98 ns |  38.3301 |  38.3301 |  38.3301 |  161717 B |
| Mtreit_A_HashSet                     | 10000  | Middle             |    136,023.81 ns |     984.478 ns |     872.714 ns |    135,885.53 ns |  38.3301 |  38.3301 |  38.3301 |  161781 B |
| Mtreit_B_BitArray                    | 10000  | Middle             |     16,306.00 ns |     143.074 ns |     126.831 ns |     16,366.09 ns |   0.0610 |        - |        - |    1280 B |
| Mtreit_C_LinearSearch                | 10000  | Middle             |  3,998,935.31 ns |  55,969.868 ns |  52,354.250 ns |  4,005,414.84 ns |        - |        - |        - |         - |
