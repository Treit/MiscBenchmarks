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
| **ReverseStringUsingLinqAndNew**       | **10**    |     **2,523.2 ns** |     **48.45 ns** |     **64.69 ns** |  **1.00** |    **0.04** |   **0.1602** |    **2720 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | 10    |     3,533.9 ns |     17.92 ns |     16.76 ns |  1.40 |    0.04 |   0.1602 |    2720 B |        1.00 |
| ReverseStringUsingExplicitCopy     | 10    |       428.2 ns |      8.32 ns |     14.13 ns |  0.17 |    0.01 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreate     | 10    |       305.0 ns |      4.93 ns |      4.12 ns |  0.12 |    0.00 |   0.0572 |     960 B |        0.35 |
| ReverseStringUsingArrayReverse     | 10    |       262.1 ns |      3.40 ns |      3.18 ns |  0.10 |    0.00 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreateKozi | 10    |       229.6 ns |      4.58 ns |      4.29 ns |  0.09 |    0.00 |   0.0572 |     960 B |        0.35 |
| RevereStringEnumerableKesa         | 10    |     2,310.2 ns |     25.30 ns |     22.43 ns |  0.92 |    0.02 |   0.1411 |    2400 B |        0.88 |
|                                    |       |                |              |              |       |         |          |           |             |
| **ReverseStringUsingLinqAndNew**       | **100**   |    **27,443.6 ns** |    **515.59 ns** |    **482.28 ns** |  **1.00** |    **0.02** |   **1.6174** |   **27200 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | 100   |    34,211.4 ns |    613.92 ns |    574.26 ns |  1.25 |    0.03 |   1.5869 |   27200 B |        1.00 |
| ReverseStringUsingExplicitCopy     | 100   |     4,197.0 ns |     83.30 ns |    102.30 ns |  0.15 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreate     | 100   |     2,963.0 ns |     28.31 ns |     26.48 ns |  0.11 |    0.00 |   0.5722 |    9600 B |        0.35 |
| ReverseStringUsingArrayReverse     | 100   |     2,604.3 ns |     26.00 ns |     23.04 ns |  0.09 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreateKozi | 100   |     2,143.8 ns |     33.92 ns |     31.73 ns |  0.08 |    0.00 |   0.5722 |    9600 B |        0.35 |
| RevereStringEnumerableKesa         | 100   |    22,288.2 ns |    187.39 ns |    166.11 ns |  0.81 |    0.02 |   1.4343 |   24000 B |        0.88 |
|                                    |       |                |              |              |       |         |          |           |             |
| **ReverseStringUsingLinqAndNew**       | **10000** | **2,471,600.0 ns** | **47,978.98 ns** | **44,879.57 ns** |  **1.00** |    **0.02** | **160.1563** | **2720000 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | 10000 | 3,335,359.4 ns | 35,329.78 ns | 33,047.50 ns |  1.35 |    0.03 | 160.1563 | 2720000 B |        1.00 |
| ReverseStringUsingExplicitCopy     | 10000 |   411,907.4 ns |  3,794.88 ns |  3,168.90 ns |  0.17 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreate     | 10000 |   296,014.6 ns |  3,887.61 ns |  3,636.47 ns |  0.12 |    0.00 |  57.1289 |  960000 B |        0.35 |
| ReverseStringUsingArrayReverse     | 10000 |   265,391.4 ns |  2,156.67 ns |  1,911.83 ns |  0.11 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreateKozi | 10000 |   297,692.4 ns |  4,189.57 ns |  3,918.93 ns |  0.12 |    0.00 |  57.1289 |  960000 B |        0.35 |
| RevereStringEnumerableKesa         | 10000 | 2,504,181.1 ns | 32,487.42 ns | 28,799.25 ns |  1.01 |    0.02 | 140.6250 | 2400000 B |        0.88 |
