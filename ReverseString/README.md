## Reversing a string





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|----------------------------------- |---------- |---------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **ReverseStringUsingLinqAndNew**       | **.NET 10.0** | **.NET 10.0** | **10**    |     **2,499.2 ns** |     **45.05 ns** |     **42.14 ns** |  **1.00** |    **0.02** |   **0.1602** |    **2720 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | .NET 10.0 | .NET 10.0 | 10    |     3,370.2 ns |     10.44 ns |      8.15 ns |  1.35 |    0.02 |   0.1602 |    2720 B |        1.00 |
| ReverseStringUsingExplicitCopy     | .NET 10.0 | .NET 10.0 | 10    |       409.0 ns |      6.31 ns |      5.91 ns |  0.16 |    0.00 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreate     | .NET 10.0 | .NET 10.0 | 10    |       296.9 ns |      3.25 ns |      3.04 ns |  0.12 |    0.00 |   0.0572 |     960 B |        0.35 |
| ReverseStringUsingArrayReverse     | .NET 10.0 | .NET 10.0 | 10    |       255.9 ns |      1.26 ns |      1.12 ns |  0.10 |    0.00 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreateKozi | .NET 10.0 | .NET 10.0 | 10    |       220.5 ns |      1.13 ns |      1.00 ns |  0.09 |    0.00 |   0.0572 |     960 B |        0.35 |
| RevereStringEnumerableKesa         | .NET 10.0 | .NET 10.0 | 10    |     2,350.6 ns |     38.20 ns |     35.74 ns |  0.94 |    0.02 |   0.1411 |    2400 B |        0.88 |
|                                    |           |           |       |                |              |              |       |         |          |           |             |
| ReverseStringUsingLinqAndNew       | .NET 9.0  | .NET 9.0  | 10    |     2,583.0 ns |     40.95 ns |     38.30 ns |  1.00 |    0.02 |   0.1602 |    2720 B |        1.00 |
| ReverseStringUsingLinqAndJoin      | .NET 9.0  | .NET 9.0  | 10    |     3,463.3 ns |     22.71 ns |     18.96 ns |  1.34 |    0.02 |   0.1602 |    2720 B |        1.00 |
| ReverseStringUsingExplicitCopy     | .NET 9.0  | .NET 9.0  | 10    |       415.5 ns |      7.27 ns |      6.44 ns |  0.16 |    0.00 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreate     | .NET 9.0  | .NET 9.0  | 10    |       298.5 ns |      2.09 ns |      1.86 ns |  0.12 |    0.00 |   0.0572 |     960 B |        0.35 |
| ReverseStringUsingArrayReverse     | .NET 9.0  | .NET 9.0  | 10    |       258.0 ns |      1.10 ns |      1.03 ns |  0.10 |    0.00 |   0.1144 |    1920 B |        0.71 |
| ReverseStringUsingStringCreateKozi | .NET 9.0  | .NET 9.0  | 10    |       217.8 ns |      1.12 ns |      1.00 ns |  0.08 |    0.00 |   0.0572 |     960 B |        0.35 |
| RevereStringEnumerableKesa         | .NET 9.0  | .NET 9.0  | 10    |     2,201.5 ns |     23.06 ns |     19.26 ns |  0.85 |    0.01 |   0.1411 |    2400 B |        0.88 |
|                                    |           |           |       |                |              |              |       |         |          |           |             |
| **ReverseStringUsingLinqAndNew**       | **.NET 10.0** | **.NET 10.0** | **100**   |    **25,807.1 ns** |    **328.91 ns** |    **291.57 ns** |  **1.00** |    **0.02** |   **1.6174** |   **27200 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | .NET 10.0 | .NET 10.0 | 100   |    34,101.0 ns |    196.00 ns |    173.75 ns |  1.32 |    0.02 |   1.5869 |   27200 B |        1.00 |
| ReverseStringUsingExplicitCopy     | .NET 10.0 | .NET 10.0 | 100   |     4,136.2 ns |     46.50 ns |     43.49 ns |  0.16 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreate     | .NET 10.0 | .NET 10.0 | 100   |     2,936.4 ns |     51.83 ns |     48.49 ns |  0.11 |    0.00 |   0.5722 |    9600 B |        0.35 |
| ReverseStringUsingArrayReverse     | .NET 10.0 | .NET 10.0 | 100   |     2,563.5 ns |     15.53 ns |     14.53 ns |  0.10 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreateKozi | .NET 10.0 | .NET 10.0 | 100   |     2,112.6 ns |     17.44 ns |     16.31 ns |  0.08 |    0.00 |   0.5722 |    9600 B |        0.35 |
| RevereStringEnumerableKesa         | .NET 10.0 | .NET 10.0 | 100   |    23,881.7 ns |    226.49 ns |    189.13 ns |  0.93 |    0.01 |   1.4343 |   24000 B |        0.88 |
|                                    |           |           |       |                |              |              |       |         |          |           |             |
| ReverseStringUsingLinqAndNew       | .NET 9.0  | .NET 9.0  | 100   |    23,467.1 ns |    197.40 ns |    154.11 ns |  1.00 |    0.01 |   1.6174 |   27200 B |        1.00 |
| ReverseStringUsingLinqAndJoin      | .NET 9.0  | .NET 9.0  | 100   |    34,280.2 ns |    217.04 ns |    203.02 ns |  1.46 |    0.01 |   1.5869 |   27200 B |        1.00 |
| ReverseStringUsingExplicitCopy     | .NET 9.0  | .NET 9.0  | 100   |     4,074.6 ns |     48.65 ns |     43.13 ns |  0.17 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreate     | .NET 9.0  | .NET 9.0  | 100   |     2,915.5 ns |     27.27 ns |     25.51 ns |  0.12 |    0.00 |   0.5722 |    9600 B |        0.35 |
| ReverseStringUsingArrayReverse     | .NET 9.0  | .NET 9.0  | 100   |     2,610.7 ns |     24.06 ns |     22.51 ns |  0.11 |    0.00 |   1.1444 |   19200 B |        0.71 |
| ReverseStringUsingStringCreateKozi | .NET 9.0  | .NET 9.0  | 100   |     2,102.0 ns |     24.70 ns |     21.90 ns |  0.09 |    0.00 |   0.5722 |    9600 B |        0.35 |
| RevereStringEnumerableKesa         | .NET 9.0  | .NET 9.0  | 100   |    22,230.3 ns |    309.45 ns |    274.32 ns |  0.95 |    0.01 |   1.4343 |   24000 B |        0.88 |
|                                    |           |           |       |                |              |              |       |         |          |           |             |
| **ReverseStringUsingLinqAndNew**       | **.NET 10.0** | **.NET 10.0** | **10000** | **2,518,543.3 ns** | **49,414.32 ns** | **46,222.18 ns** |  **1.00** |    **0.03** | **160.1563** | **2720000 B** |        **1.00** |
| ReverseStringUsingLinqAndJoin      | .NET 10.0 | .NET 10.0 | 10000 | 3,217,559.5 ns | 33,988.78 ns | 31,793.13 ns |  1.28 |    0.03 | 160.1563 | 2720000 B |        1.00 |
| ReverseStringUsingExplicitCopy     | .NET 10.0 | .NET 10.0 | 10000 |   415,823.8 ns |  3,494.75 ns |  3,268.99 ns |  0.17 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreate     | .NET 10.0 | .NET 10.0 | 10000 |   290,918.7 ns |  1,727.52 ns |  1,348.73 ns |  0.12 |    0.00 |  57.1289 |  960000 B |        0.35 |
| ReverseStringUsingArrayReverse     | .NET 10.0 | .NET 10.0 | 10000 |   262,601.4 ns |  1,869.09 ns |  1,656.90 ns |  0.10 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreateKozi | .NET 10.0 | .NET 10.0 | 10000 |   292,342.2 ns |  3,114.69 ns |  2,913.48 ns |  0.12 |    0.00 |  57.1289 |  960000 B |        0.35 |
| RevereStringEnumerableKesa         | .NET 10.0 | .NET 10.0 | 10000 | 2,196,016.1 ns | 26,103.81 ns | 21,797.86 ns |  0.87 |    0.02 | 140.6250 | 2400000 B |        0.88 |
|                                    |           |           |       |                |              |              |       |         |          |           |             |
| ReverseStringUsingLinqAndNew       | .NET 9.0  | .NET 9.0  | 10000 | 2,302,294.0 ns | 34,705.09 ns | 34,085.04 ns |  1.00 |    0.02 | 160.1563 | 2720000 B |        1.00 |
| ReverseStringUsingLinqAndJoin      | .NET 9.0  | .NET 9.0  | 10000 | 3,325,606.8 ns | 38,629.92 ns | 34,244.41 ns |  1.44 |    0.02 | 160.1563 | 2720000 B |        1.00 |
| ReverseStringUsingExplicitCopy     | .NET 9.0  | .NET 9.0  | 10000 |   410,351.2 ns |  2,892.66 ns |  2,705.80 ns |  0.18 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreate     | .NET 9.0  | .NET 9.0  | 10000 |   289,802.8 ns |  2,707.87 ns |  2,532.94 ns |  0.13 |    0.00 |  57.1289 |  960000 B |        0.35 |
| ReverseStringUsingArrayReverse     | .NET 9.0  | .NET 9.0  | 10000 |   260,637.3 ns |  2,742.72 ns |  2,431.35 ns |  0.11 |    0.00 | 114.7461 | 1920000 B |        0.71 |
| ReverseStringUsingStringCreateKozi | .NET 9.0  | .NET 9.0  | 10000 |   294,387.3 ns |  4,394.98 ns |  4,111.06 ns |  0.13 |    0.00 |  57.1289 |  960000 B |        0.35 |
| RevereStringEnumerableKesa         | .NET 9.0  | .NET 9.0  | 10000 | 2,218,926.2 ns | 43,916.26 ns | 43,131.64 ns |  0.96 |    0.02 | 140.6250 | 2400000 B |        0.88 |
