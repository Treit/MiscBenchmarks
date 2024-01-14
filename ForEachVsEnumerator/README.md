# ForEach vs. directly using the enumerator.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                            Method |  Count |           Mean |        Error |      StdDev | Ratio | RatioSD |     Gen0 | Allocated | Alloc Ratio |
|---------------------------------- |------- |---------------:|-------------:|------------:|------:|--------:|---------:|----------:|------------:|
|            **MaxUsingEnumeratorList** |   **1000** |     **1,530.5 ns** |      **5.75 ns** |     **5.38 ns** |  **2.33** |    **0.01** |   **0.0019** |      **40 B** |          **NA** |
|               MaxUsingForEachList |   1000 |       655.8 ns |      4.18 ns |     3.71 ns |  1.00 |    0.00 |        - |         - |          NA |
|         MaxUsingForEachListSorted |   1000 |       758.9 ns |     33.28 ns |    98.13 ns |  1.09 |    0.12 |        - |         - |          NA |
|               MaxUsingForLoopList |   1000 |       668.8 ns |      6.65 ns |     5.90 ns |  1.02 |    0.01 |        - |         - |          NA |
|         MaxUsingForLoopListSorted |   1000 |       632.0 ns |      1.88 ns |     1.76 ns |  0.96 |    0.01 |        - |         - |          NA |
|           MaxUsingEnumeratorArray |   1000 |    33,068.8 ns |     85.22 ns |    71.16 ns | 50.45 |    0.28 |   1.4038 |   24032 B |          NA |
|              MaxUsingForEachArray |   1000 |       344.1 ns |      1.89 ns |     1.67 ns |  0.52 |    0.00 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable |   1000 |       348.4 ns |      1.48 ns |     1.32 ns |  0.53 |    0.00 |        - |         - |          NA |
|        MaxUsingForEachArraySorted |   1000 |       319.0 ns |      1.00 ns |     0.94 ns |  0.49 |    0.00 |        - |         - |          NA |
|              MaxUsingForLoopArray |   1000 |       661.3 ns |      2.20 ns |     1.95 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable |   1000 |       365.4 ns |      3.87 ns |     3.43 ns |  0.56 |    0.01 |        - |         - |          NA |
|        MaxUsingForLoopArraySorted |   1000 |       627.7 ns |      2.88 ns |     2.56 ns |  0.96 |    0.01 |        - |         - |          NA |
|          MaxUsingEnumeratorList64 |   1000 |     1,550.6 ns |      1.43 ns |     1.27 ns |  2.36 |    0.01 |   0.0019 |      40 B |          NA |
|             MaxUsingForEachList64 |   1000 |       678.7 ns |      3.09 ns |     2.89 ns |  1.03 |    0.01 |        - |         - |          NA |
|             MaxUsingForLoopList64 |   1000 |       652.7 ns |      3.46 ns |     3.07 ns |  1.00 |    0.01 |        - |         - |          NA |
|         MaxUsingEnumeratorArray64 |   1000 |    33,696.4 ns |    102.62 ns |    95.99 ns | 51.39 |    0.34 |   1.4038 |   24032 B |          NA |
|            MaxUsingForEachArray64 |   1000 |       369.6 ns |      2.62 ns |     2.45 ns |  0.56 |    0.01 |        - |         - |          NA |
|            MaxUsingForLoopArray64 |   1000 |       687.7 ns |      4.48 ns |     4.19 ns |  1.05 |    0.01 |        - |         - |          NA |
|                                   |        |                |              |             |       |         |          |           |             |
|            **MaxUsingEnumeratorList** | **100000** |   **149,655.8 ns** |    **478.52 ns** |   **447.61 ns** |  **2.39** |    **0.02** |        **-** |      **40 B** |          **NA** |
|               MaxUsingForEachList | 100000 |    62,624.5 ns |    423.64 ns |   396.27 ns |  1.00 |    0.00 |        - |         - |          NA |
|         MaxUsingForEachListSorted | 100000 |    62,717.1 ns |    422.55 ns |   395.26 ns |  1.00 |    0.01 |        - |         - |          NA |
|               MaxUsingForLoopList | 100000 |    62,686.8 ns |    240.37 ns |   200.72 ns |  1.00 |    0.01 |        - |         - |          NA |
|         MaxUsingForLoopListSorted | 100000 |    63,347.0 ns |    332.77 ns |   311.28 ns |  1.01 |    0.01 |        - |         - |          NA |
|           MaxUsingEnumeratorArray | 100000 | 3,292,812.6 ns |  9,490.94 ns | 8,413.47 ns | 52.56 |    0.38 | 140.6250 | 2400034 B |          NA |
|              MaxUsingForEachArray | 100000 |    31,426.1 ns |    207.32 ns |   173.12 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | 100000 |    31,264.2 ns |    141.10 ns |   117.83 ns |  0.50 |    0.00 |        - |         - |          NA |
|        MaxUsingForEachArraySorted | 100000 |    31,284.0 ns |     53.30 ns |    47.25 ns |  0.50 |    0.00 |        - |         - |          NA |
|              MaxUsingForLoopArray | 100000 |    62,279.6 ns |     88.82 ns |    74.17 ns |  0.99 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | 100000 |    31,397.4 ns |    103.24 ns |    96.57 ns |  0.50 |    0.00 |        - |         - |          NA |
|        MaxUsingForLoopArraySorted | 100000 |    62,152.2 ns |     80.32 ns |    62.71 ns |  0.99 |    0.01 |        - |         - |          NA |
|          MaxUsingEnumeratorList64 | 100000 |   154,623.2 ns |    347.53 ns |   308.08 ns |  2.47 |    0.02 |        - |      40 B |          NA |
|             MaxUsingForEachList64 | 100000 |    64,989.7 ns |    466.22 ns |   436.10 ns |  1.04 |    0.01 |        - |         - |          NA |
|             MaxUsingForLoopList64 | 100000 |    63,223.9 ns |    256.29 ns |   227.19 ns |  1.01 |    0.01 |        - |         - |          NA |
|         MaxUsingEnumeratorArray64 | 100000 | 3,251,488.0 ns | 10,081.01 ns | 8,418.10 ns | 51.89 |    0.38 | 140.6250 | 2400034 B |          NA |
|            MaxUsingForEachArray64 | 100000 |    31,620.9 ns |     58.62 ns |    48.95 ns |  0.50 |    0.00 |        - |         - |          NA |
|            MaxUsingForLoopArray64 | 100000 |    62,685.6 ns |     59.00 ns |    52.30 ns |  1.00 |    0.01 |        - |         - |          NA |
