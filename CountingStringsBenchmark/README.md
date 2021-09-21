## Counting strings

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22463
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                         Method |   Count |            Mean |             Error |         StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------------- |-------- |----------------:|------------------:|---------------:|-------:|------:|------:|----------:|
|              **ForLoopCountUsingLengthEqualsZero** |      **10** |        **13.98 ns** |         **12.134 ns** |       **0.665 ns** |      **-** |     **-** |     **-** |         **-** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |      10 |        14.10 ns |          5.411 ns |       0.297 ns |      - |     - |     - |         - |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |      10 |        22.02 ns |         12.492 ns |       0.685 ns |      - |     - |     - |         - |
|            ForLoopCountUsingEmptyStringLiteral |      10 |        38.05 ns |         11.699 ns |       0.641 ns |      - |     - |     - |         - |
|                ForLoopCountUsingStringDotEmpty |      10 |        37.63 ns |         10.770 ns |       0.590 ns |      - |     - |     - |         - |
|          ForEachLoopCountUsingLengthEqualsZero |      10 |        45.19 ns |         26.484 ns |       1.452 ns |      - |     - |     - |         - |
|        ForEachLoopCountUsingEmptyStringLiteral |      10 |        80.86 ns |         28.263 ns |       1.549 ns |      - |     - |     - |         - |
|            ForEachLoopCountUsingStringDotEmpty |      10 |        84.37 ns |         88.917 ns |       4.874 ns |      - |     - |     - |         - |
|                 ForLoopCountUsingIsNullOrEmpty |      10 |        14.50 ns |         13.271 ns |       0.727 ns |      - |     - |     - |         - |
|          CountUsingLinqWhereEmptyStringLiteral |      10 |        96.02 ns |        145.116 ns |       7.954 ns | 0.0167 |     - |     - |      72 B |
|            CountUsingLinqWhereLengthEqualsZero |      10 |        73.98 ns |         56.587 ns |       3.102 ns | 0.0167 |     - |     - |      72 B |
|              **ForLoopCountUsingLengthEqualsZero** |     **100** |       **136.27 ns** |        **107.006 ns** |       **5.865 ns** |      **-** |     **-** |     **-** |         **-** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |     100 |       133.06 ns |         38.720 ns |       2.122 ns |      - |     - |     - |         - |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |     100 |       235.66 ns |         83.464 ns |       4.575 ns |      - |     - |     - |         - |
|            ForLoopCountUsingEmptyStringLiteral |     100 |       351.22 ns |        351.191 ns |      19.250 ns |      - |     - |     - |         - |
|                ForLoopCountUsingStringDotEmpty |     100 |       406.79 ns |         15.762 ns |       0.864 ns |      - |     - |     - |         - |
|          ForEachLoopCountUsingLengthEqualsZero |     100 |       595.01 ns |        477.092 ns |      26.151 ns |      - |     - |     - |         - |
|        ForEachLoopCountUsingEmptyStringLiteral |     100 |       893.63 ns |        293.567 ns |      16.091 ns |      - |     - |     - |         - |
|            ForEachLoopCountUsingStringDotEmpty |     100 |       744.72 ns |        105.402 ns |       5.777 ns |      - |     - |     - |         - |
|                 ForLoopCountUsingIsNullOrEmpty |     100 |       148.02 ns |         16.133 ns |       0.884 ns |      - |     - |     - |         - |
|          CountUsingLinqWhereEmptyStringLiteral |     100 |       545.25 ns |      1,630.555 ns |      89.376 ns | 0.0162 |     - |     - |      72 B |
|            CountUsingLinqWhereLengthEqualsZero |     100 |       309.82 ns |         46.416 ns |       2.544 ns | 0.0167 |     - |     - |      72 B |
|              **ForLoopCountUsingLengthEqualsZero** |    **1000** |     **1,385.64 ns** |        **534.470 ns** |      **29.296 ns** |      **-** |     **-** |     **-** |         **-** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |    1000 |     1,469.03 ns |        693.491 ns |      38.013 ns |      - |     - |     - |         - |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |    1000 |     2,351.02 ns |      1,239.219 ns |      67.926 ns |      - |     - |     - |         - |
|            ForLoopCountUsingEmptyStringLiteral |    1000 |     3,602.72 ns |      1,096.140 ns |      60.083 ns |      - |     - |     - |         - |
|                ForLoopCountUsingStringDotEmpty |    1000 |     3,760.08 ns |      1,949.260 ns |     106.846 ns |      - |     - |     - |         - |
|          ForEachLoopCountUsingLengthEqualsZero |    1000 |     4,404.18 ns |      4,544.627 ns |     249.106 ns |      - |     - |     - |         - |
|        ForEachLoopCountUsingEmptyStringLiteral |    1000 |     6,823.37 ns |        586.448 ns |      32.145 ns |      - |     - |     - |         - |
|            ForEachLoopCountUsingStringDotEmpty |    1000 |     7,733.14 ns |      3,589.404 ns |     196.747 ns |      - |     - |     - |         - |
|                 ForLoopCountUsingIsNullOrEmpty |    1000 |     1,505.43 ns |      1,266.823 ns |      69.439 ns |      - |     - |     - |         - |
|          CountUsingLinqWhereEmptyStringLiteral |    1000 |     4,350.93 ns |      2,884.309 ns |     158.099 ns | 0.0153 |     - |     - |      72 B |
|            CountUsingLinqWhereLengthEqualsZero |    1000 |     2,920.62 ns |      2,836.741 ns |     155.491 ns | 0.0153 |     - |     - |      72 B |
|              **ForLoopCountUsingLengthEqualsZero** |  **100000** |   **164,219.02 ns** |    **142,166.961 ns** |   **7,792.651 ns** |      **-** |     **-** |     **-** |         **-** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |  100000 |   170,646.57 ns |     33,366.809 ns |   1,828.947 ns |      - |     - |     - |         - |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |  100000 |   246,224.20 ns |    178,810.535 ns |   9,801.209 ns |      - |     - |     - |         - |
|            ForLoopCountUsingEmptyStringLiteral |  100000 |   382,038.57 ns |    312,538.833 ns |  17,131.308 ns |      - |     - |     - |         - |
|                ForLoopCountUsingStringDotEmpty |  100000 |   327,449.71 ns |     83,578.222 ns |   4,581.204 ns |      - |     - |     - |         - |
|          ForEachLoopCountUsingLengthEqualsZero |  100000 |   410,022.84 ns |    128,987.309 ns |   7,070.230 ns |      - |     - |     - |         - |
|        ForEachLoopCountUsingEmptyStringLiteral |  100000 |   797,540.90 ns |    542,303.796 ns |  29,725.501 ns |      - |     - |     - |         - |
|            ForEachLoopCountUsingStringDotEmpty |  100000 |   721,908.17 ns |    257,967.180 ns |  14,140.052 ns |      - |     - |     - |         - |
|                 ForLoopCountUsingIsNullOrEmpty |  100000 |   177,983.35 ns |    220,650.256 ns |  12,094.585 ns |      - |     - |     - |         - |
|          CountUsingLinqWhereEmptyStringLiteral |  100000 |   407,736.43 ns |    397,339.821 ns |  21,779.536 ns |      - |     - |     - |      72 B |
|            CountUsingLinqWhereLengthEqualsZero |  100000 |   290,901.66 ns |     90,114.523 ns |   4,939.481 ns |      - |     - |     - |      72 B |
|              **ForLoopCountUsingLengthEqualsZero** | **1000000** | **3,679,082.42 ns** |    **875,823.279 ns** |  **48,006.829 ns** |      **-** |     **-** |     **-** |         **-** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 1000000 | 3,735,541.54 ns |  1,416,343.860 ns |  77,634.586 ns |      - |     - |     - |         - |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch | 1000000 | 4,011,544.27 ns |    879,301.041 ns |  48,197.457 ns |      - |     - |     - |         - |
|            ForLoopCountUsingEmptyStringLiteral | 1000000 | 4,758,120.31 ns |    876,732.208 ns |  48,056.651 ns |      - |     - |     - |         - |
|                ForLoopCountUsingStringDotEmpty | 1000000 | 4,609,853.52 ns |  2,354,391.625 ns | 129,052.149 ns |      - |     - |     - |         - |
|          ForEachLoopCountUsingLengthEqualsZero | 1000000 | 5,683,738.15 ns | 16,033,868.007 ns | 878,870.409 ns |      - |     - |     - |         - |
|        ForEachLoopCountUsingEmptyStringLiteral | 1000000 | 9,082,056.25 ns | 14,229,788.708 ns | 779,982.735 ns |      - |     - |     - |         - |
|            ForEachLoopCountUsingStringDotEmpty | 1000000 | 8,454,280.99 ns |  6,541,485.769 ns | 358,560.908 ns |      - |     - |     - |         - |
|                 ForLoopCountUsingIsNullOrEmpty | 1000000 | 3,648,028.12 ns |    716,880.194 ns |  39,294.622 ns |      - |     - |     - |         - |
|          CountUsingLinqWhereEmptyStringLiteral | 1000000 | 4,772,445.31 ns |    869,168.988 ns |  47,642.085 ns |      - |     - |     - |      72 B |
|            CountUsingLinqWhereLengthEqualsZero | 1000000 | 4,224,156.77 ns |  4,066,295.726 ns | 222,887.390 ns |      - |     - |     - |      72 B |
