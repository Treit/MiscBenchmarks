# Checking if any one of a series of values is null



```

BenchmarkDotNet v0.15.1, Windows 11 (10.0.27876.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                | Scenario   | Iterations | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------- |----------- |----------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **ExplicitNullChecks**    | **AllNonNull** | **1000**       |   **3,274.1 ns** |     **65.20 ns** |     **95.57 ns** |   **3,260.9 ns** |  **1.00** |    **0.04** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray      | AllNonNull | 1000       |  38,438.7 ns |    768.29 ns |  1,870.12 ns |  38,027.2 ns | 11.75 |    0.66 |  24.1089 |  104000 B |          NA |
| PatternMatchingSwitch | AllNonNull | 1000       |   4,057.1 ns |     66.79 ns |     55.77 ns |   4,061.3 ns |  1.24 |    0.04 |        - |         - |          NA |
|                       |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks**    | **AllNonNull** | **10000**      |  **31,631.6 ns** |    **427.91 ns** |    **379.33 ns** |  **31,611.6 ns** |  **1.00** |    **0.02** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray      | AllNonNull | 10000      | 380,765.8 ns |  7,988.45 ns | 22,791.51 ns | 375,227.2 ns | 12.04 |    0.73 | 240.7227 | 1040000 B |          NA |
| PatternMatchingSwitch | AllNonNull | 10000      |  41,312.2 ns |    816.07 ns |  1,340.82 ns |  40,849.6 ns |  1.31 |    0.04 |        - |         - |          NA |
|                       |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks**    | **LastNull**   | **1000**       |   **3,254.5 ns** |     **60.80 ns** |     **59.71 ns** |   **3,235.5 ns** |  **1.00** |    **0.03** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray      | LastNull   | 1000       |  41,060.9 ns |  1,208.39 ns |  3,467.09 ns |  40,593.6 ns | 12.62 |    1.08 |  24.1089 |  104000 B |          NA |
| PatternMatchingSwitch | LastNull   | 1000       |   3,967.0 ns |     77.32 ns |    214.25 ns |   3,922.4 ns |  1.22 |    0.07 |        - |         - |          NA |
|                       |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks**    | **LastNull**   | **10000**      |  **34,145.3 ns** |    **675.87 ns** |  **1,780.51 ns** |  **33,761.5 ns** |  **1.00** |    **0.07** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray      | LastNull   | 10000      | 426,368.3 ns | 13,013.39 ns | 37,337.86 ns | 414,460.3 ns | 12.52 |    1.26 | 240.2344 | 1040000 B |          NA |
| PatternMatchingSwitch | LastNull   | 10000      |  39,154.0 ns |    749.45 ns |  1,961.19 ns |  38,735.2 ns |  1.15 |    0.08 |        - |         - |          NA |
|                       |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks**    | **OneNull**    | **1000**       |     **620.7 ns** |     **12.85 ns** |     **36.65 ns** |     **613.7 ns** |  **1.00** |    **0.08** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray      | OneNull    | 1000       |  34,231.1 ns |    759.48 ns |  2,142.13 ns |  33,315.3 ns | 55.33 |    4.62 |  24.1089 |  104000 B |          NA |
| PatternMatchingSwitch | OneNull    | 1000       |   1,464.0 ns |     28.25 ns |     37.71 ns |   1,453.2 ns |  2.37 |    0.14 |        - |         - |          NA |
|                       |            |            |              |              |              |              |       |         |          |           |             |
| **ExplicitNullChecks**    | **OneNull**    | **10000**      |   **5,851.0 ns** |    **117.07 ns** |    **152.22 ns** |   **5,828.7 ns** |  **1.00** |    **0.04** |        **-** |         **-** |          **NA** |
| LinqAnyWithArray      | OneNull    | 10000      | 332,555.3 ns |  6,571.19 ns |  7,567.39 ns | 331,467.5 ns | 56.87 |    1.91 | 240.7227 | 1040000 B |          NA |
| PatternMatchingSwitch | OneNull    | 10000      |  14,466.9 ns |    279.29 ns |    218.05 ns |  14,463.0 ns |  2.47 |    0.07 |        - |         - |          NA |
