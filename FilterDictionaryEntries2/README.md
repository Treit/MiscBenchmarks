# Filtering dictionary entries. The "create a HashSet from the dictionary keys" idea was from Ai :|


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27766.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Count | Mean             | Error          | StdDev         | Median           | Ratio    | RatioSD | Gen0        | Gen1       | Gen2    | Allocated    | Alloc Ratio |
|-------------------------------- |------ |-----------------:|---------------:|---------------:|-----------------:|---------:|--------:|------------:|-----------:|--------:|-------------:|------------:|
| **FilterUsingContainsKey**          | **100**   |         **1.687 μs** |      **0.0559 μs** |      **0.1621 μs** |         **1.634 μs** |     **1.00** |    **0.00** |      **0.4616** |          **-** |       **-** |      **1.95 KB** |        **1.00** |
| FilterUsingSelectToListContains | 100   |       144.448 μs |      2.7218 μs |      7.0743 μs |       142.945 μs |    85.33 |    8.30 |     30.2734 |          - |       - |    128.51 KB |       66.06 |
| FilterUsingHashSet              | 100   |         2.613 μs |      0.0515 μs |      0.0755 μs |         2.599 μs |     1.50 |    0.13 |      0.9003 |          - |       - |       3.8 KB |        1.95 |
|                                 |       |                  |                |                |                  |          |         |             |            |         |              |             |
| **FilterUsingContainsKey**          | **10000** |       **134.427 μs** |      **2.6406 μs** |      **4.6936 μs** |       **134.017 μs** |     **1.00** |    **0.00** |     **36.8652** |     **0.2441** |       **-** |    **157.03 KB** |        **1.00** |
| FilterUsingSelectToListContains | 10000 | 1,238,609.050 μs | 24,447.2897 μs | 51,567.6314 μs | 1,218,485.050 μs | 9,262.42 |  538.27 | 303000.0000 | 21000.0000 |       - | 1284454.3 KB |    8,179.61 |
| FilterUsingHashSet              | 10000 |       346.743 μs |      6.3275 μs |      9.4707 μs |       342.800 μs |     2.57 |    0.09 |     76.1719 |    38.0859 | 38.0859 |    315.08 KB |        2.01 |
