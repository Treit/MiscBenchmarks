# ForEach vs. directly using the enumerator.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count  | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------------- |---------- |---------- |------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **MaxUsingEnumeratorList**            | **.NET 10.0** | **.NET 10.0** | **1000**   |     **663.2 ns** |      **5.49 ns** |      **5.13 ns** |     **663.0 ns** |  **1.02** |    **0.01** |        **-** |         **-** |          **NA** |
| MaxUsingForEachList               | .NET 10.0 | .NET 10.0 | 1000   |     652.4 ns |      9.16 ns |      8.57 ns |     649.4 ns |  1.00 |    0.02 |        - |         - |          NA |
| MaxUsingForEachListSorted         | .NET 10.0 | .NET 10.0 | 1000   |     639.3 ns |      9.02 ns |      8.44 ns |     638.3 ns |  0.98 |    0.02 |        - |         - |          NA |
| MaxUsingForLoopList               | .NET 10.0 | .NET 10.0 | 1000   |     935.6 ns |     18.57 ns |     33.96 ns |     947.0 ns |  1.43 |    0.05 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | .NET 10.0 | .NET 10.0 | 1000   |     641.2 ns |      5.79 ns |      5.42 ns |     642.3 ns |  0.98 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | .NET 10.0 | .NET 10.0 | 1000   |   6,685.4 ns |    107.82 ns |    100.86 ns |   6,714.1 ns | 10.25 |    0.20 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray              | .NET 10.0 | .NET 10.0 | 1000   |     343.8 ns |      4.38 ns |      4.10 ns |     344.2 ns |  0.53 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | .NET 10.0 | .NET 10.0 | 1000   |     371.9 ns |      3.85 ns |      3.60 ns |     372.9 ns |  0.57 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | .NET 10.0 | .NET 10.0 | 1000   |     571.3 ns |     18.45 ns |     54.41 ns |     590.0 ns |  0.88 |    0.08 |        - |         - |          NA |
| MaxUsingForLoopArray              | .NET 10.0 | .NET 10.0 | 1000   |     667.2 ns |      5.53 ns |      4.91 ns |     667.9 ns |  1.02 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | .NET 10.0 | .NET 10.0 | 1000   |     355.7 ns |      5.98 ns |      5.60 ns |     356.0 ns |  0.55 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | .NET 10.0 | .NET 10.0 | 1000   |     632.6 ns |      4.38 ns |      4.09 ns |     634.0 ns |  0.97 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | .NET 10.0 | .NET 10.0 | 1000   |     669.6 ns |      3.96 ns |      3.51 ns |     670.8 ns |  1.03 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList64             | .NET 10.0 | .NET 10.0 | 1000   |     668.6 ns |      7.18 ns |      6.72 ns |     670.8 ns |  1.03 |    0.02 |        - |         - |          NA |
| MaxUsingForLoopList64             | .NET 10.0 | .NET 10.0 | 1000   |     666.9 ns |      7.76 ns |      7.26 ns |     667.6 ns |  1.02 |    0.02 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | .NET 10.0 | .NET 10.0 | 1000   |   6,857.1 ns |    117.26 ns |    109.68 ns |   6,821.0 ns | 10.51 |    0.21 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray64            | .NET 10.0 | .NET 10.0 | 1000   |     334.0 ns |      3.46 ns |      3.23 ns |     334.3 ns |  0.51 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray64            | .NET 10.0 | .NET 10.0 | 1000   |     657.5 ns |      7.64 ns |      7.15 ns |     657.0 ns |  1.01 |    0.02 |        - |         - |          NA |
|                                   |           |           |        |              |              |              |              |       |         |          |           |             |
| MaxUsingEnumeratorList            | .NET 9.0  | .NET 9.0  | 1000   |     667.0 ns |      5.14 ns |      4.80 ns |     668.3 ns |  0.99 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList               | .NET 9.0  | .NET 9.0  | 1000   |     672.0 ns |      8.11 ns |      7.19 ns |     672.0 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachListSorted         | .NET 9.0  | .NET 9.0  | 1000   |     634.2 ns |      4.53 ns |      4.02 ns |     635.0 ns |  0.94 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList               | .NET 9.0  | .NET 9.0  | 1000   |     957.0 ns |     19.16 ns |     38.26 ns |     968.0 ns |  1.42 |    0.06 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | .NET 9.0  | .NET 9.0  | 1000   |     642.9 ns |      8.97 ns |      8.39 ns |     643.1 ns |  0.96 |    0.02 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | .NET 9.0  | .NET 9.0  | 1000   |   6,711.8 ns |     88.47 ns |     82.76 ns |   6,702.2 ns |  9.99 |    0.16 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray              | .NET 9.0  | .NET 9.0  | 1000   |     336.5 ns |      5.93 ns |      5.54 ns |     335.5 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | .NET 9.0  | .NET 9.0  | 1000   |     355.5 ns |      3.72 ns |      3.48 ns |     355.1 ns |  0.53 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | .NET 9.0  | .NET 9.0  | 1000   |     487.8 ns |     23.41 ns |     69.03 ns |     486.8 ns |  0.73 |    0.10 |        - |         - |          NA |
| MaxUsingForLoopArray              | .NET 9.0  | .NET 9.0  | 1000   |     652.4 ns |      6.89 ns |      6.45 ns |     652.5 ns |  0.97 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | .NET 9.0  | .NET 9.0  | 1000   |     347.3 ns |      5.91 ns |      5.52 ns |     344.7 ns |  0.52 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | .NET 9.0  | .NET 9.0  | 1000   |     632.9 ns |      4.59 ns |      4.07 ns |     634.7 ns |  0.94 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | .NET 9.0  | .NET 9.0  | 1000   |     650.5 ns |      5.04 ns |      4.72 ns |     650.0 ns |  0.97 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList64             | .NET 9.0  | .NET 9.0  | 1000   |     654.0 ns |      5.33 ns |      4.98 ns |     654.6 ns |  0.97 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList64             | .NET 9.0  | .NET 9.0  | 1000   |     681.0 ns |      3.65 ns |      3.41 ns |     682.3 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | .NET 9.0  | .NET 9.0  | 1000   |   6,723.1 ns |     94.61 ns |     88.50 ns |   6,705.9 ns | 10.01 |    0.16 |   1.4343 |   24000 B |          NA |
| MaxUsingForEachArray64            | .NET 9.0  | .NET 9.0  | 1000   |     356.9 ns |      7.18 ns |      7.37 ns |     356.2 ns |  0.53 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray64            | .NET 9.0  | .NET 9.0  | 1000   |     659.5 ns |      4.30 ns |      3.81 ns |     660.2 ns |  0.98 |    0.01 |        - |         - |          NA |
|                                   |           |           |        |              |              |              |              |       |         |          |           |             |
| **MaxUsingEnumeratorList**            | **.NET 10.0** | **.NET 10.0** | **100000** |  **63,924.8 ns** |    **715.11 ns** |    **668.92 ns** |  **64,040.7 ns** |  **1.01** |    **0.01** |        **-** |         **-** |          **NA** |
| MaxUsingForEachList               | .NET 10.0 | .NET 10.0 | 100000 |  63,292.4 ns |    730.54 ns |    647.60 ns |  63,464.7 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachListSorted         | .NET 10.0 | .NET 10.0 | 100000 |  63,762.7 ns |  1,050.39 ns |    982.53 ns |  63,707.5 ns |  1.01 |    0.02 |        - |         - |          NA |
| MaxUsingForLoopList               | .NET 10.0 | .NET 10.0 | 100000 |  63,885.7 ns |  1,261.78 ns |  1,295.75 ns |  63,534.0 ns |  1.01 |    0.02 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | .NET 10.0 | .NET 10.0 | 100000 |  63,452.2 ns |    609.14 ns |    569.79 ns |  63,587.4 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | .NET 10.0 | .NET 10.0 | 100000 | 662,995.6 ns |  8,119.75 ns |  7,197.95 ns | 663,899.8 ns | 10.48 |    0.15 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray              | .NET 10.0 | .NET 10.0 | 100000 |  31,737.7 ns |    433.08 ns |    405.11 ns |  31,833.0 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | .NET 10.0 | .NET 10.0 | 100000 |  31,680.1 ns |    402.02 ns |    376.05 ns |  31,772.2 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | .NET 10.0 | .NET 10.0 | 100000 |  63,061.2 ns |    553.27 ns |    490.46 ns |  63,181.8 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray              | .NET 10.0 | .NET 10.0 | 100000 |  63,086.7 ns |    508.77 ns |    451.01 ns |  63,217.1 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | .NET 10.0 | .NET 10.0 | 100000 |  31,717.9 ns |    443.24 ns |    414.60 ns |  31,817.4 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | .NET 10.0 | .NET 10.0 | 100000 |  63,036.0 ns |    865.16 ns |    809.27 ns |  63,343.5 ns |  1.00 |    0.02 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | .NET 10.0 | .NET 10.0 | 100000 |  64,796.4 ns |    619.68 ns |    549.33 ns |  64,803.1 ns |  1.02 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList64             | .NET 10.0 | .NET 10.0 | 100000 |  63,413.7 ns |    525.27 ns |    491.34 ns |  63,597.3 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList64             | .NET 10.0 | .NET 10.0 | 100000 |  63,547.5 ns |    575.64 ns |    480.68 ns |  63,486.1 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | .NET 10.0 | .NET 10.0 | 100000 | 676,458.6 ns | 13,017.34 ns | 12,176.43 ns | 679,368.2 ns | 10.69 |    0.21 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray64            | .NET 10.0 | .NET 10.0 | 100000 |  31,997.1 ns |    219.68 ns |    205.49 ns |  32,015.7 ns |  0.51 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray64            | .NET 10.0 | .NET 10.0 | 100000 |  63,009.3 ns |    480.56 ns |    449.51 ns |  62,849.1 ns |  1.00 |    0.01 |        - |         - |          NA |
|                                   |           |           |        |              |              |              |              |       |         |          |           |             |
| MaxUsingEnumeratorList            | .NET 9.0  | .NET 9.0  | 100000 |  63,684.4 ns |    593.47 ns |    526.09 ns |  63,726.7 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingForEachList               | .NET 9.0  | .NET 9.0  | 100000 |  63,203.1 ns |    696.59 ns |    651.59 ns |  63,083.9 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForEachListSorted         | .NET 9.0  | .NET 9.0  | 100000 |  63,427.0 ns |    567.06 ns |    530.43 ns |  63,674.5 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList               | .NET 9.0  | .NET 9.0  | 100000 |  63,400.0 ns |    798.96 ns |    747.35 ns |  63,425.3 ns |  1.00 |    0.02 |        - |         - |          NA |
| MaxUsingForLoopListSorted         | .NET 9.0  | .NET 9.0  | 100000 |  63,508.6 ns |    935.73 ns |    875.29 ns |  63,516.0 ns |  1.00 |    0.02 |        - |         - |          NA |
| MaxUsingEnumeratorArray           | .NET 9.0  | .NET 9.0  | 100000 | 663,858.7 ns | 11,177.58 ns | 10,455.51 ns | 662,929.9 ns | 10.50 |    0.19 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray              | .NET 9.0  | .NET 9.0  | 100000 |  31,707.2 ns |    223.75 ns |    198.35 ns |  31,798.8 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArrayLocalVariable | .NET 9.0  | .NET 9.0  | 100000 |  32,101.4 ns |    507.83 ns |    475.02 ns |  32,024.5 ns |  0.51 |    0.01 |        - |         - |          NA |
| MaxUsingForEachArraySorted        | .NET 9.0  | .NET 9.0  | 100000 |  62,888.1 ns |    686.02 ns |    608.14 ns |  62,957.0 ns |  1.00 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray              | .NET 9.0  | .NET 9.0  | 100000 |  62,669.6 ns |    545.43 ns |    510.20 ns |  62,865.7 ns |  0.99 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArrayLocalVariable | .NET 9.0  | .NET 9.0  | 100000 |  31,625.6 ns |    290.51 ns |    271.74 ns |  31,764.5 ns |  0.50 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArraySorted        | .NET 9.0  | .NET 9.0  | 100000 |  62,865.2 ns |    550.42 ns |    514.86 ns |  63,245.2 ns |  0.99 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorList64          | .NET 9.0  | .NET 9.0  | 100000 |  65,156.8 ns |    782.00 ns |    731.48 ns |  65,349.3 ns |  1.03 |    0.02 |        - |         - |          NA |
| MaxUsingForEachList64             | .NET 9.0  | .NET 9.0  | 100000 |  63,691.5 ns |    682.20 ns |    532.62 ns |  63,824.9 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopList64             | .NET 9.0  | .NET 9.0  | 100000 |  63,576.6 ns |    568.30 ns |    531.59 ns |  63,788.9 ns |  1.01 |    0.01 |        - |         - |          NA |
| MaxUsingEnumeratorArray64         | .NET 9.0  | .NET 9.0  | 100000 | 673,996.5 ns | 12,804.12 ns | 12,575.36 ns | 674,823.5 ns | 10.67 |    0.22 | 142.5781 | 2400000 B |          NA |
| MaxUsingForEachArray64            | .NET 9.0  | .NET 9.0  | 100000 |  31,942.2 ns |    225.67 ns |    200.05 ns |  32,037.2 ns |  0.51 |    0.01 |        - |         - |          NA |
| MaxUsingForLoopArray64            | .NET 9.0  | .NET 9.0  | 100000 |  63,184.9 ns |    617.01 ns |    577.15 ns |  63,405.9 ns |  1.00 |    0.01 |        - |         - |          NA |
