## Reversing a string



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|----------------------------------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **ReverseStringUsingLinqAndNew**       | **10**    |     **2,684.2 ns** |     **42.50 ns** |     **39.76 ns** |  **1.00** |    **0.02** |   **0.1602** |    **2720 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | 10    |     3,357.5 ns |     20.23 ns |     17.94 ns |  1.25 |    0.02 |   0.1602 |    2720 B |        1.00 |
| ReverseStringUsingExplicitCopy     | 10    |       437.1 ns |      8.50 ns |      7.53 ns |  0.16 |    0.00 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreate     | 10    |       301.4 ns |      3.12 ns |      2.91 ns |  0.11 |    0.00 |   0.0572 |     960 B |        0.35 |
| ReverseStringUsingArrayReverse     | 10    |       264.1 ns |      2.50 ns |      2.22 ns |  0.10 |    0.00 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreateKozi | 10    |       224.6 ns |      1.65 ns |      1.55 ns |  0.08 |    0.00 |   0.0572 |     960 B |        0.35 |
| RevereStringEnumerableKesa         | 10    |     2,219.5 ns |     31.30 ns |     27.75 ns |  0.83 |    0.02 |   0.1411 |    2400 B |        0.88 |
|                                    |       |                |              |              |       |         |          |           |             |
| **ReverseStringUsingLinqAndNew**       | **100**   |    **25,733.3 ns** |    **428.16 ns** |    **400.50 ns** |  **1.00** |    **0.02** |   **1.6174** |   **27200 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | 100   |    33,797.2 ns |    485.34 ns |    453.98 ns |  1.31 |    0.03 |   1.5869 |   27200 B |        1.00 |
| ReverseStringUsingExplicitCopy     | 100   |     4,130.9 ns |     78.59 ns |     69.67 ns |  0.16 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreate     | 100   |     2,943.0 ns |     27.36 ns |     25.59 ns |  0.11 |    0.00 |   0.5722 |    9600 B |        0.35 |
| ReverseStringUsingArrayReverse     | 100   |     2,630.3 ns |     44.54 ns |     41.66 ns |  0.10 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreateKozi | 100   |     2,129.3 ns |     20.67 ns |     18.33 ns |  0.08 |    0.00 |   0.5722 |    9600 B |        0.35 |
| RevereStringEnumerableKesa         | 100   |    23,005.8 ns |    365.31 ns |    341.71 ns |  0.89 |    0.02 |   1.4343 |   24000 B |        0.88 |
|                                    |       |                |              |              |       |         |          |           |             |
| **ReverseStringUsingLinqAndNew**       | **10000** | **2,318,209.1 ns** | **27,215.96 ns** | **24,126.24 ns** |  **1.00** |    **0.01** | **160.1563** | **2720000 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | 10000 | 3,247,292.6 ns | 28,792.47 ns | 26,932.49 ns |  1.40 |    0.02 | 160.1563 | 2720000 B |        1.00 |
| ReverseStringUsingExplicitCopy     | 10000 |   412,855.0 ns |  3,401.62 ns |  3,181.87 ns |  0.18 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreate     | 10000 |   294,757.3 ns |  4,934.86 ns |  4,616.08 ns |  0.13 |    0.00 |  57.1289 |  960000 B |        0.35 |
| ReverseStringUsingArrayReverse     | 10000 |   267,950.4 ns |  2,919.67 ns |  2,731.06 ns |  0.12 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreateKozi | 10000 |   294,757.8 ns |  5,396.29 ns |  5,047.69 ns |  0.13 |    0.00 |  57.1289 |  960000 B |        0.35 |
| RevereStringEnumerableKesa         | 10000 | 2,229,828.1 ns | 39,883.49 ns | 37,307.04 ns |  0.96 |    0.02 | 140.6250 | 2400000 B |        0.88 |
