## Checking someList.Count > 0 vs. Any(), and variants.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]   : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  ShortRun : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                         | Count  | Mean           | Error          | StdDev        | Ratio      | RatioSD  | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------------------------- |------- |---------------:|---------------:|--------------:|-----------:|---------:|-------:|-------:|----------:|------------:|
| **IListAnyResultsLinqAny**                         | **10**     |      **0.5623 ns** |      **0.6683 ns** |     **0.0366 ns** |       **1.58** |     **0.11** |      **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | 10     |      0.3571 ns |      0.3197 ns |     0.0175 ns |       1.00 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | 10     |      0.5420 ns |      0.1561 ns |     0.0086 ns |       1.52 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | 10     |     16.1861 ns |      3.6378 ns |     0.1994 ns |      45.40 |     2.02 | 0.0038 |      - |      64 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | 10     |      0.3577 ns |      0.2571 ns |     0.0141 ns |       1.00 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | 10     |      0.3617 ns |      0.4876 ns |     0.0267 ns |       1.01 |     0.08 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | 10     |      4.5809 ns |      0.6372 ns |     0.0349 ns |      12.85 |     0.56 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | 10     |     10.5574 ns |      1.6528 ns |     0.0906 ns |      29.61 |     1.30 | 0.0019 |      - |      32 B |          NA |
| IEnumerableAnyResultsLinqCount                 | 10     |      5.9229 ns |      1.3351 ns |     0.0732 ns |      16.61 |     0.74 |      - |      - |         - |          NA |
|                                                |        |                |                |               |            |          |        |        |           |             |
| **IListAnyResultsLinqAny**                         | **100000** |      **0.5641 ns** |      **0.3305 ns** |     **0.0181 ns** |       **1.66** |     **0.06** |      **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | 100000 |      0.3405 ns |      0.1876 ns |     0.0103 ns |       1.00 |     0.04 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | 100000 |      0.5240 ns |      0.2274 ns |     0.0125 ns |       1.54 |     0.05 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | 100000 |  4,091.3256 ns |  2,568.7618 ns |   140.8025 ns |  12,024.35 |   480.57 | 4.7607 | 0.7935 |   80056 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | 100000 |      0.3672 ns |      0.4742 ns |     0.0260 ns |       1.08 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | 100000 |      0.3664 ns |      0.3693 ns |     0.0202 ns |       1.08 |     0.06 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | 100000 |      4.5599 ns |      0.6935 ns |     0.0380 ns |      13.40 |     0.37 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | 100000 | 44,687.5793 ns | 20,588.2873 ns | 1,128.5135 ns | 131,336.18 | 4,525.09 | 4.7607 | 0.7935 |   80056 B |          NA |
| IEnumerableAnyResultsLinqCount                 | 100000 | 10,225.3108 ns |  1,361.9977 ns |    74.6557 ns |  30,052.05 |   822.19 |      - |      - |         - |          NA |
