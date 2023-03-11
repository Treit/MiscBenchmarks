# Counting strings in a list using different types of loops.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25305.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                                  Method |   Count |            Mean |         Error |         StdDev |           Median | Ratio | RatioSD |
|---------------------------------------- |-------- |----------------:|--------------:|---------------:|-----------------:|------:|--------:|
|                            **ForLoopCount** |      **10** |        **13.34 ns** |      **0.352 ns** |       **1.017 ns** |        **13.064 ns** |  **1.27** |    **0.10** |
|                        ForEachLoopCount |      10 |        10.58 ns |      0.214 ns |       0.427 ns |        10.435 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan |      10 |        10.10 ns |      0.241 ns |       0.475 ns |         9.919 ns |  0.96 |    0.06 |
|                 ListDotForEachLoopCount |      10 |        38.60 ns |      0.780 ns |       0.729 ns |        38.578 ns |  3.63 |    0.17 |
|             ListExplicitEnumeratorCount |      10 |        11.80 ns |      0.271 ns |       0.488 ns |        11.661 ns |  1.11 |    0.06 |
|                                         |         |                 |               |                |                  |       |         |
|                            **ForLoopCount** |    **1000** |     **1,343.75 ns** |     **29.139 ns** |      **83.605 ns** |     **1,333.035 ns** |  **1.31** |    **0.10** |
|                        ForEachLoopCount |    1000 |     1,006.07 ns |     19.915 ns |      35.398 ns |     1,000.798 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan |    1000 |     1,042.81 ns |     13.524 ns |      11.989 ns |     1,039.876 ns |  1.03 |    0.04 |
|                 ListDotForEachLoopCount |    1000 |     2,490.48 ns |     38.082 ns |      46.769 ns |     2,485.264 ns |  2.48 |    0.10 |
|             ListExplicitEnumeratorCount |    1000 |     1,068.50 ns |     30.603 ns |      87.807 ns |     1,050.538 ns |  1.11 |    0.10 |
|                                         |         |                 |               |                |                  |       |         |
|                            **ForLoopCount** | **1000000** | **3,373,196.84 ns** | **66,810.714 ns** |  **99,999.130 ns** | **3,335,146.289 ns** |  **1.01** |    **0.03** |
|                        ForEachLoopCount | 1000000 | 3,339,632.62 ns | 62,971.776 ns |  58,903.839 ns | 3,333,203.320 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000000 | 3,172,322.57 ns | 60,301.523 ns |  74,055.686 ns | 3,172,209.375 ns |  0.95 |    0.03 |
|                 ListDotForEachLoopCount | 1000000 | 3,687,919.87 ns | 73,728.148 ns |  81,948.642 ns | 3,704,701.758 ns |  1.11 |    0.03 |
|             ListExplicitEnumeratorCount | 1000000 | 3,410,016.83 ns | 68,075.301 ns | 168,265.277 ns | 3,372,870.898 ns |  1.04 |    0.06 |
