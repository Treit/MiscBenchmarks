## Checking someList.Count > 0 vs. Any(), and variants.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  ShortRun  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Job       | Runtime   | IterationCount | LaunchCount | WarmupCount | Count  | Mean           | Error          | StdDev        | Ratio      | RatioSD  | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------------------------- |---------- |---------- |--------------- |------------ |------------ |------- |---------------:|---------------:|--------------:|-----------:|---------:|-------:|-------:|----------:|------------:|
| **IListAnyResultsLinqAny**                         | **.NET 10.0** | **.NET 10.0** | **Default**        | **Default**     | **Default**     | **10**     |      **0.5274 ns** |      **0.0165 ns** |     **0.0154 ns** |       **1.41** |     **0.06** |      **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |      0.3738 ns |      0.0149 ns |     0.0140 ns |       1.00 |     0.05 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |      0.5056 ns |      0.0107 ns |     0.0100 ns |       1.35 |     0.05 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |     15.9722 ns |      0.1438 ns |     0.1275 ns |      42.79 |     1.56 | 0.0038 |      - |      64 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |      0.3681 ns |      0.0166 ns |     0.0156 ns |       0.99 |     0.05 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |      0.3589 ns |      0.0065 ns |     0.0055 ns |       0.96 |     0.04 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |      4.5301 ns |      0.0116 ns |     0.0091 ns |      12.14 |     0.43 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |     10.5276 ns |      0.1018 ns |     0.0902 ns |      28.20 |     1.03 | 0.0019 |      - |      32 B |          NA |
| IEnumerableAnyResultsLinqCount                 | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 10     |      5.9133 ns |      0.0173 ns |     0.0153 ns |      15.84 |     0.57 |      - |      - |         - |          NA |
|                                                |           |           |                |             |             |        |                |                |               |            |          |        |        |           |             |
| IListAnyResultsLinqAny                         | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |      0.5377 ns |      0.0133 ns |     0.0124 ns |       1.55 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsIListDotCount                   | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |      0.3461 ns |      0.0113 ns |     0.0106 ns |       1.00 |     0.04 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |      0.5682 ns |      0.0177 ns |     0.0166 ns |       1.64 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |     15.9137 ns |      0.1114 ns |     0.0988 ns |      46.02 |     1.40 | 0.0038 |      - |      64 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |      0.3595 ns |      0.0101 ns |     0.0085 ns |       1.04 |     0.04 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |      0.3368 ns |      0.0209 ns |     0.0185 ns |       0.97 |     0.06 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |      4.5545 ns |      0.0161 ns |     0.0150 ns |      13.17 |     0.39 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |     10.5573 ns |      0.1350 ns |     0.1263 ns |      30.53 |     0.97 | 0.0019 |      - |      32 B |          NA |
| IEnumerableAnyResultsLinqCount                 | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 10     |      5.9122 ns |      0.0399 ns |     0.0353 ns |      17.10 |     0.52 |      - |      - |         - |          NA |
|                                                |           |           |                |             |             |        |                |                |               |            |          |        |        |           |             |
| IListAnyResultsLinqAny                         | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |      0.5205 ns |      0.2398 ns |     0.0131 ns |       1.38 |     0.05 |      - |      - |         - |          NA |
| IListAnyResultsIListDotCount                   | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |      0.3772 ns |      0.2583 ns |     0.0142 ns |       1.00 |     0.05 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |      0.5612 ns |      0.2740 ns |     0.0150 ns |       1.49 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |     16.0631 ns |      2.9505 ns |     0.1617 ns |      42.62 |     1.45 | 0.0038 |      - |      64 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |      0.3477 ns |      0.1026 ns |     0.0056 ns |       0.92 |     0.03 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |      0.3702 ns |      0.1836 ns |     0.0101 ns |       0.98 |     0.04 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |      4.5319 ns |      0.4105 ns |     0.0225 ns |      12.03 |     0.40 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |     10.5344 ns |      1.6991 ns |     0.0931 ns |      27.95 |     0.95 | 0.0019 |      - |      32 B |          NA |
| IEnumerableAnyResultsLinqCount                 | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 10     |      5.8857 ns |      0.2391 ns |     0.0131 ns |      15.62 |     0.52 |      - |      - |         - |          NA |
|                                                |           |           |                |             |             |        |                |                |               |            |          |        |        |           |             |
| **IListAnyResultsLinqAny**                         | **.NET 10.0** | **.NET 10.0** | **Default**        | **Default**     | **Default**     | **100000** |      **0.5478 ns** |      **0.0143 ns** |     **0.0133 ns** |       **1.50** |     **0.07** |      **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 |      0.3650 ns |      0.0177 ns |     0.0165 ns |       1.00 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 |      0.5434 ns |      0.0136 ns |     0.0127 ns |       1.49 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 |  3,920.0984 ns |     34.7779 ns |    32.5313 ns |  10,760.41 |   468.27 | 4.7607 | 0.7935 |   80056 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 |      0.4114 ns |      0.0340 ns |     0.0318 ns |       1.13 |     0.10 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 |      0.3654 ns |      0.0128 ns |     0.0113 ns |       1.00 |     0.05 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 |      4.5283 ns |      0.0246 ns |     0.0218 ns |      12.43 |     0.53 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 | 43,242.8129 ns |    740.9045 ns |   618.6888 ns | 118,698.70 | 5,335.69 | 4.7607 |      - |   80024 B |          NA |
| IEnumerableAnyResultsLinqCount                 | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 100000 | 10,024.3584 ns |     14.8945 ns |    12.4376 ns |  27,516.21 | 1,177.68 |      - |      - |         - |          NA |
|                                                |           |           |                |             |             |        |                |                |               |            |          |        |        |           |             |
| IListAnyResultsLinqAny                         | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 |      0.5442 ns |      0.0154 ns |     0.0144 ns |       1.47 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsIListDotCount                   | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 |      0.3700 ns |      0.0184 ns |     0.0172 ns |       1.00 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 |      0.5279 ns |      0.0123 ns |     0.0115 ns |       1.43 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 |  4,170.4031 ns |     80.4822 ns |   101.7842 ns |  11,294.71 |   557.83 | 4.7607 | 0.7935 |   80056 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 |      0.3710 ns |      0.0130 ns |     0.0122 ns |       1.00 |     0.05 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 |      0.4025 ns |      0.0342 ns |     0.0320 ns |       1.09 |     0.10 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 |      4.5697 ns |      0.0238 ns |     0.0223 ns |      12.38 |     0.54 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 | 42,729.2161 ns |    836.1445 ns |   995.3706 ns | 115,723.59 | 5,653.51 | 4.7607 |      - |   80024 B |          NA |
| IEnumerableAnyResultsLinqCount                 | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 100000 | 10,032.8731 ns |     36.2311 ns |    30.2546 ns |  27,172.04 | 1,177.96 |      - |      - |         - |          NA |
|                                                |           |           |                |             |             |        |                |                |               |            |          |        |        |           |             |
| IListAnyResultsLinqAny                         | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 |      0.5204 ns |      0.0827 ns |     0.0045 ns |       1.49 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsIListDotCount                   | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 |      0.3509 ns |      0.3101 ns |     0.0170 ns |       1.00 |     0.06 |      - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 |      0.5316 ns |      0.1434 ns |     0.0079 ns |       1.52 |     0.07 |      - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 |  3,874.9944 ns |  2,176.6955 ns |   119.3120 ns |  11,058.93 |   540.23 | 4.7607 | 0.7935 |   80056 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 |      0.3614 ns |      0.0438 ns |     0.0024 ns |       1.03 |     0.04 |      - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 |      0.3963 ns |      0.3211 ns |     0.0176 ns |       1.13 |     0.06 |      - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 |      4.6109 ns |      1.4159 ns |     0.0776 ns |      13.16 |     0.57 |      - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 | 45,316.8925 ns | 18,455.8831 ns | 1,011.6292 ns | 129,330.88 | 5,853.58 | 4.7607 |      - |   80024 B |          NA |
| IEnumerableAnyResultsLinqCount                 | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 100000 | 10,204.5497 ns |  1,129.4283 ns |    61.9078 ns |  29,122.99 | 1,201.42 |      - |      - |         - |          NA |
