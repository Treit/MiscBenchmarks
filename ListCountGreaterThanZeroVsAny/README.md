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
| **IListAnyResultsLinqAny**                         | **10**     |      **0.5322 ns** |      **0.2430 ns** |     **0.0133 ns** |       **1.47** |     **0.08** |      **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | 10     |      0.3619 ns |      0.3684 ns |     0.0202 ns |       1.00 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | 10     |      0.5293 ns |      0.6093 ns |     0.0334 ns |       1.47 |     0.11 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | 10     |     16.3431 ns |      3.1271 ns |     0.1714 ns |      45.25 |     2.22 | 0.0038 |      - |      64 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | 10     |      0.3622 ns |      0.4491 ns |     0.0246 ns |       1.00 |     0.08 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | 10     |      0.3493 ns |      0.2055 ns |     0.0113 ns |       0.97 |     0.05 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | 10     |      4.6059 ns |      1.1372 ns |     0.0623 ns |      12.75 |     0.63 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | 10     |     10.5545 ns |      2.9902 ns |     0.1639 ns |      29.22 |     1.46 | 0.0019 |      - |      32 B |          NA |
| IEnumerableAnyResultsLinqCount                 | 10     |      5.9592 ns |      1.0373 ns |     0.0569 ns |      16.50 |     0.81 |      - |      - |         - |          NA |
|                                                |        |                |                |               |            |          |        |        |           |             |
| **IListAnyResultsLinqAny**                         | **100000** |      **0.5779 ns** |      **0.3020 ns** |     **0.0166 ns** |       **1.64** |     **0.09** |      **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | 100000 |      0.3527 ns |      0.3615 ns |     0.0198 ns |       1.00 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | 100000 |      0.5284 ns |      0.2438 ns |     0.0134 ns |       1.50 |     0.08 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | 100000 |  4,048.3398 ns |    576.8009 ns |    31.6164 ns |  11,501.34 |   578.13 | 4.7607 | 0.7935 |   80056 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | 100000 |      0.3779 ns |      0.7272 ns |     0.0399 ns |       1.07 |     0.11 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | 100000 |      0.3624 ns |      0.3584 ns |     0.0196 ns |       1.03 |     0.07 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | 100000 |      4.5598 ns |      0.4088 ns |     0.0224 ns |      12.95 |     0.65 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | 100000 | 43,379.7526 ns | 30,738.3582 ns | 1,684.8731 ns | 123,241.98 | 7,409.71 | 4.7607 |      - |   80024 B |          NA |
| IEnumerableAnyResultsLinqCount                 | 100000 | 10,245.4575 ns |  1,323.2313 ns |    72.5308 ns |  29,107.37 | 1,460.76 |      - |      - |         - |          NA |
