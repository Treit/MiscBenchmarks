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
| **MaxUsingEnumeratorList**            | **1000**   |     **656.9 ns** |     **3.21 ns** |     **2.50 ns** |     **657.5 ns** |  **0.98** |    **0.01** |        **-** |         **-** |          **NA** |
| MaxUsingForEachList               | 1000   |     672.0 ns |     4.24 ns |     3.97 ns |     672.1 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachListSorted         | 1000   |     631.4 ns |     4.68 ns |     4.38 ns |     633.0 ns |  0.94 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList               | 1000   |     912.6 ns |    18.08 ns |    38.15 ns |     927.0 ns |  1.36 |    0.06 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | 1000   |     636.7 ns |     4.14 ns |     3.88 ns |     636.2 ns |  0.95 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | 1000   |   6,602.2 ns |    49.08 ns |    45.91 ns |   6,600.3 ns |  9.82 |    0.09 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray              | 1000   |     330.5 ns |     2.75 ns |     2.29 ns |     330.6 ns |  0.49 |    0.00 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | 1000   |     342.8 ns |     4.66 ns |     4.14 ns |     343.0 ns |  0.51 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | 1000   |     593.7 ns |    16.37 ns |    48.26 ns |     617.3 ns |  0.88 |    0.07 |        - |         - |          NA |
| MaxUsingForLoopArray              | 1000   |     651.4 ns |     3.15 ns |     2.63 ns |     653.1 ns |  0.97 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | 1000   |     372.5 ns |     7.14 ns |     9.77 ns |     369.8 ns |  0.55 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | 1000   |     632.8 ns |     5.65 ns |     5.29 ns |     633.6 ns |  0.94 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | 1000   |     668.7 ns |     2.43 ns |     2.15 ns |     669.4 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList64             | 1000   |     690.4 ns |     5.29 ns |     4.95 ns |     690.8 ns |  1.03 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList64             | 1000   |     666.5 ns |     4.55 ns |     4.26 ns |     667.9 ns |  0.99 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | 1000   |   6,613.9 ns |    52.73 ns |    49.32 ns |   6,619.3 ns |  9.84 |    0.09 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray64            | 1000   |     361.4 ns |     5.20 ns |     4.87 ns |     361.1 ns |  0.54 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray64            | 1000   |     648.6 ns |     4.54 ns |     4.25 ns |     649.9 ns |  0.97 |    0.01 |        - |         - |          NA |
|                                   |        |              |             |             |              |       |         |          |           |             |
| **MaxUsingEnumeratorList**            | **100000** |  **63,619.5 ns** |   **720.31 ns** |   **638.54 ns** |  **63,397.6 ns** |  **1.01** |    **0.01** |        **-** |         **-** |          **NA** |
| MaxUsingForEachList               | 100000 |  62,794.7 ns |   477.49 ns |   446.64 ns |  63,096.9 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachListSorted         | 100000 |  62,818.6 ns |   581.94 ns |   515.87 ns |  62,944.5 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList               | 100000 |  62,904.8 ns |   414.44 ns |   387.67 ns |  63,068.9 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | 100000 |  63,067.6 ns |   486.20 ns |   454.79 ns |  63,284.8 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | 100000 | 653,029.7 ns | 6,643.96 ns | 6,214.76 ns | 654,739.4 ns | 10.40 |    0.12 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray              | 100000 |  31,546.4 ns |   257.86 ns |   241.20 ns |  31,387.1 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | 100000 |  31,599.5 ns |   316.31 ns |   280.40 ns |  31,624.6 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | 100000 |  62,627.5 ns |   407.65 ns |   381.32 ns |  62,387.5 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray              | 100000 |  62,709.3 ns |   452.82 ns |   423.57 ns |  62,958.6 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | 100000 |  31,541.8 ns |   310.92 ns |   290.84 ns |  31,522.5 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | 100000 |  62,978.6 ns |   483.87 ns |   452.61 ns |  63,123.1 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | 100000 |  64,939.7 ns |   531.00 ns |   496.70 ns |  65,087.6 ns |  1.03 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList64             | 100000 |  63,290.3 ns |   418.67 ns |   391.62 ns |  63,288.3 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList64             | 100000 |  63,461.7 ns |   396.26 ns |   370.66 ns |  63,671.8 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | 100000 | 657,078.2 ns | 8,771.59 ns | 8,204.95 ns | 657,292.9 ns | 10.46 |    0.15 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray64            | 100000 |  31,904.0 ns |   192.02 ns |   179.62 ns |  31,975.1 ns |  0.51 |    0.00 |        - |         - |          NA |
| MaxUsingForLoopArray64            | 100000 |  63,205.0 ns |   519.10 ns |   485.56 ns |  63,373.1 ns |  1.01 |    0.01 |        - |         - |          NA |
