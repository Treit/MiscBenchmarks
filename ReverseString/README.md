## Reversing a string


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                             Method | Count |           Mean |        Error |       StdDev | Ratio | RatioSD |     Gen0 | Allocated | Alloc Ratio |
|----------------------------------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
|       **ReverseStringUsingLinqAndNew** |    **10** |     **2,650.9 ns** |     **21.94 ns** |     **20.52 ns** |  **1.00** |    **0.00** |   **0.3471** |    **5840 B** |        **1.00** |
|      ReverseStringUsingLinqAndJoin |    10 |     2,585.2 ns |     25.02 ns |     23.40 ns |  0.98 |    0.01 |   0.3242 |    5440 B |        0.93 |
|     ReverseStringUsingExplicitCopy |    10 |       432.0 ns |      3.59 ns |      3.00 ns |  0.16 |    0.00 |   0.1144 |    1920 B |        0.33 |
|     ReverseStringUsingStringCreate |    10 |       312.7 ns |      1.65 ns |      1.54 ns |  0.12 |    0.00 |   0.0572 |     960 B |        0.16 |
|     ReverseStringUsingArrayReverse |    10 |       267.5 ns |      3.29 ns |      2.75 ns |  0.10 |    0.00 |   0.1144 |    1920 B |        0.33 |
| ReverseStringUsingStringCreateKozi |    10 |       230.4 ns |      3.47 ns |      3.25 ns |  0.09 |    0.00 |   0.0572 |     960 B |        0.16 |
|         RevereStringEnumerableKesa |    10 |     2,622.7 ns |     15.84 ns |     14.82 ns |  0.99 |    0.01 |   0.3281 |    5520 B |        0.95 |
|                                    |       |                |              |              |       |         |          |           |             |
|       **ReverseStringUsingLinqAndNew** |   **100** |    **26,676.3 ns** |    **121.88 ns** |    **114.01 ns** |  **1.00** |    **0.00** |   **3.4790** |   **58400 B** |        **1.00** |
|      ReverseStringUsingLinqAndJoin |   100 |    26,061.5 ns |    240.44 ns |    224.91 ns |  0.98 |    0.01 |   3.2349 |   54400 B |        0.93 |
|     ReverseStringUsingExplicitCopy |   100 |     4,235.8 ns |     64.22 ns |     60.07 ns |  0.16 |    0.00 |   1.1444 |   19200 B |        0.33 |
|     ReverseStringUsingStringCreate |   100 |     3,134.0 ns |     22.16 ns |     20.73 ns |  0.12 |    0.00 |   0.5722 |    9600 B |        0.16 |
|     ReverseStringUsingArrayReverse |   100 |     2,674.3 ns |     45.39 ns |     42.46 ns |  0.10 |    0.00 |   1.1444 |   19200 B |        0.33 |
| ReverseStringUsingStringCreateKozi |   100 |     2,269.6 ns |     30.23 ns |     26.80 ns |  0.09 |    0.00 |   0.5722 |    9600 B |        0.16 |
|         RevereStringEnumerableKesa |   100 |    26,155.3 ns |    129.23 ns |    114.56 ns |  0.98 |    0.01 |   3.2959 |   55200 B |        0.95 |
|                                    |       |                |              |              |       |         |          |           |             |
|       **ReverseStringUsingLinqAndNew** | **10000** | **2,785,042.6 ns** | **35,260.60 ns** | **31,257.60 ns** |  **1.00** |    **0.00** | **347.6563** | **5840002 B** |        **1.00** |
|      ReverseStringUsingLinqAndJoin | 10000 | 2,605,588.5 ns | 47,262.02 ns | 59,771.33 ns |  0.94 |    0.03 | 324.2188 | 5440002 B |        0.93 |
|     ReverseStringUsingExplicitCopy | 10000 |   436,051.3 ns |  6,713.04 ns |  6,279.38 ns |  0.16 |    0.00 | 114.7461 | 1920000 B |        0.33 |
|     ReverseStringUsingStringCreate | 10000 |   314,435.7 ns |  1,903.58 ns |  1,589.57 ns |  0.11 |    0.00 |  57.1289 |  960000 B |        0.16 |
|     ReverseStringUsingArrayReverse | 10000 |   275,920.7 ns |  3,480.23 ns |  3,085.13 ns |  0.10 |    0.00 | 114.7461 | 1920000 B |        0.33 |
| ReverseStringUsingStringCreateKozi | 10000 |   230,678.2 ns |  3,493.03 ns |  3,267.38 ns |  0.08 |    0.00 |  57.3730 |  960000 B |        0.16 |
|         RevereStringEnumerableKesa | 10000 | 2,588,375.9 ns | 13,187.14 ns | 11,690.06 ns |  0.93 |    0.01 | 328.1250 | 5520002 B |        0.95 |
