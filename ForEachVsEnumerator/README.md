# ForEach vs. directly using the enumerator.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count  | Mean         | Error       | StdDev      | Median       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------------- |------- |-------------:|------------:|------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **MaxUsingEnumeratorList**            | **1000**   |     **682.9 ns** |     **7.67 ns** |     **7.18 ns** |     **682.7 ns** |  **1.02** |    **0.01** |        **-** |         **-** |          **NA** |
| MaxUsingForEachList               | 1000   |     671.4 ns |     4.54 ns |     4.24 ns |     673.0 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachListSorted         | 1000   |     634.2 ns |     5.60 ns |     5.23 ns |     635.5 ns |  0.94 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList               | 1000   |     959.7 ns |    18.38 ns |    22.57 ns |     964.6 ns |  1.43 |    0.03 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | 1000   |     638.3 ns |     5.25 ns |     4.91 ns |     638.0 ns |  0.95 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | 1000   |   6,625.8 ns |    63.47 ns |    59.37 ns |   6,632.6 ns |  9.87 |    0.10 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray              | 1000   |     330.0 ns |     4.51 ns |     4.22 ns |     330.1 ns |  0.49 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | 1000   |     340.3 ns |     4.99 ns |     4.67 ns |     340.3 ns |  0.51 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | 1000   |     575.8 ns |    25.36 ns |    74.76 ns |     612.3 ns |  0.86 |    0.11 |        - |         - |          NA |
| MaxUsingForLoopArray              | 1000   |     671.1 ns |     4.82 ns |     4.51 ns |     671.7 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | 1000   |     353.7 ns |     3.96 ns |     3.70 ns |     354.1 ns |  0.53 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | 1000   |     631.3 ns |     3.32 ns |     2.77 ns |     632.0 ns |  0.94 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | 1000   |     653.0 ns |     4.95 ns |     4.63 ns |     653.1 ns |  0.97 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList64             | 1000   |     654.7 ns |     4.76 ns |     4.22 ns |     654.0 ns |  0.98 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList64             | 1000   |     656.1 ns |     6.42 ns |     5.69 ns |     655.3 ns |  0.98 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | 1000   |   6,608.6 ns |    48.68 ns |    45.53 ns |   6,601.3 ns |  9.84 |    0.09 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray64            | 1000   |     336.7 ns |     4.41 ns |     4.13 ns |     336.7 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray64            | 1000   |     648.5 ns |     5.05 ns |     3.95 ns |     650.3 ns |  0.97 |    0.01 |        - |         - |          NA |
|                                   |        |              |             |             |              |       |         |          |           |             |
| **MaxUsingEnumeratorList**            | **100000** |  **63,552.4 ns** |   **452.28 ns** |   **423.06 ns** |  **63,336.3 ns** |  **1.01** |    **0.01** |        **-** |         **-** |          **NA** |
| MaxUsingForEachList               | 100000 |  62,898.1 ns |   498.70 ns |   466.48 ns |  63,227.1 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachListSorted         | 100000 |  62,784.9 ns |   479.96 ns |   425.47 ns |  62,572.2 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList               | 100000 |  62,939.8 ns |   466.13 ns |   436.02 ns |  63,226.9 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | 100000 |  67,178.6 ns | 2,230.92 ns | 6,218.91 ns |  63,682.0 ns |  1.07 |    0.10 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | 100000 | 658,576.1 ns | 6,601.82 ns | 6,175.35 ns | 657,873.7 ns | 10.47 |    0.12 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray              | 100000 |  31,726.4 ns |   224.27 ns |   209.78 ns |  31,811.3 ns |  0.50 |    0.00 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | 100000 |  31,627.3 ns |   355.65 ns |   332.68 ns |  31,698.2 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | 100000 |  62,936.3 ns |   637.34 ns |   596.17 ns |  63,043.6 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray              | 100000 |  62,732.6 ns |   538.13 ns |   503.37 ns |  62,977.6 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | 100000 |  31,680.6 ns |   212.77 ns |   199.03 ns |  31,779.9 ns |  0.50 |    0.00 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | 100000 |  62,851.7 ns |   563.66 ns |   527.25 ns |  62,483.5 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | 100000 |  65,740.0 ns |   592.27 ns |   554.01 ns |  65,761.2 ns |  1.05 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList64             | 100000 |  63,482.7 ns |   497.11 ns |   465.00 ns |  63,596.2 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList64             | 100000 |  63,534.3 ns |   437.69 ns |   409.42 ns |  63,767.8 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | 100000 | 661,971.4 ns | 6,955.30 ns | 6,505.99 ns | 661,116.8 ns | 10.53 |    0.13 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray64            | 100000 |  31,807.6 ns |   237.57 ns |   222.22 ns |  31,947.7 ns |  0.51 |    0.00 |        - |         - |          NA |
| MaxUsingForLoopArray64            | 100000 |  63,069.2 ns |   463.58 ns |   433.64 ns |  63,338.2 ns |  1.00 |    0.01 |        - |         - |          NA |
