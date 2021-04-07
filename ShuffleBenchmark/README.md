# Shuffle Benchmarks

```
// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21343
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.201
  [Host]   : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  ShortRun : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3
```
|               Method |   Count |           Mean |           Error |         StdDev |     Gen 0 |     Gen 1 |     Gen 2 |   Allocated |
|--------------------- |-------- |---------------:|----------------:|---------------:|----------:|----------:|----------:|------------:|
|          FisherYates |      10 |       2.134 us |       0.5918 us |      0.0324 us |    0.0648 |         - |         - |       280 B |
| FisherYatesAscending |      10 |       2.120 us |       0.7786 us |      0.0427 us |    0.0648 |         - |         - |       280 B |
|              Sattolo |      10 |       2.205 us |       1.2956 us |      0.0710 us |    0.0648 |         - |         - |       280 B |
|       LinqWithRandom |      10 |       2.601 us |       0.5062 us |      0.0277 us |    0.1907 |         - |         - |       832 B |
|         LinqWithGuid |      10 |       3.601 us |       1.9434 us |      0.1065 us |    0.1984 |         - |         - |       864 B |
|      PLinqWithRandom |      10 |     153.043 us |      59.1947 us |      3.2447 us |   15.6250 |    0.2441 |         - |     43385 B |
|        PLinqWithGuid |      10 |     168.783 us |      93.4902 us |      5.1245 us |   46.6309 |    0.2441 |         - |    141601 B |
|          FisherYates |     100 |       4.078 us |       2.2357 us |      0.1225 us |    0.0610 |         - |         - |       280 B |
| FisherYatesAscending |     100 |       4.076 us |       2.1573 us |      0.1182 us |    0.0610 |         - |         - |       280 B |
|              Sattolo |     100 |       4.097 us |       2.6984 us |      0.1479 us |    0.0610 |         - |         - |       280 B |
|       LinqWithRandom |     100 |      11.793 us |       1.1242 us |      0.0616 us |    0.5188 |         - |         - |      2272 B |
|         LinqWithGuid |     100 |      21.522 us |       4.6036 us |      0.2523 us |    0.7629 |         - |         - |      3384 B |
|      PLinqWithRandom |     100 |     159.410 us |      58.8907 us |      3.2280 us |   16.1133 |    1.4648 |         - |     48009 B |
|        PLinqWithGuid |     100 |     182.253 us |      46.7093 us |      2.5603 us |   46.3867 |    0.2441 |         - |    146226 B |
|          FisherYates |    1000 |      21.932 us |      26.4693 us |      1.4509 us |    0.0610 |         - |         - |       280 B |
| FisherYatesAscending |    1000 |      23.587 us |      28.2077 us |      1.5462 us |    0.0610 |         - |         - |       280 B |
|              Sattolo |    1000 |      22.225 us |      14.8460 us |      0.8138 us |    0.0610 |         - |         - |       280 B |
|       LinqWithRandom |    1000 |     148.890 us |      69.0807 us |      3.7865 us |    3.6621 |         - |         - |     16672 B |
|         LinqWithGuid |    1000 |     254.048 us |     186.0139 us |     10.1961 us |    6.3477 |         - |         - |     28584 B |
|      PLinqWithRandom |    1000 |     245.263 us |      34.9178 us |      1.9140 us |   24.4141 |    0.4883 |         - |     88233 B |
|        PLinqWithGuid |    1000 |     296.909 us |     167.9872 us |      9.2079 us |   52.7344 |    0.4883 |         - |    186446 B |
|          FisherYates |  100000 |   2,008.620 us |     918.2742 us |     50.3337 us |         - |         - |         - |       280 B |
| FisherYatesAscending |  100000 |   2,042.784 us |   1,989.6784 us |    109.0610 us |         - |         - |         - |       280 B |
|              Sattolo |  100000 |   1,944.904 us |     354.2363 us |     19.4169 us |         - |         - |         - |       280 B |
|       LinqWithRandom |  100000 |  23,679.990 us |  14,183.3184 us |    777.4355 us |  468.7500 |  468.7500 |  468.7500 |   1600672 B |
|         LinqWithGuid |  100000 |  37,535.064 us |  21,348.2783 us |  1,170.1712 us |  642.8571 |  642.8571 |  642.8571 |   2802882 B |
|      PLinqWithRandom |  100000 |  13,394.319 us |   3,557.0338 us |    194.9730 us | 1484.3750 | 1421.8750 | 1000.0000 |   6728499 B |
|        PLinqWithGuid |  100000 |  14,705.179 us |   3,580.3337 us |    196.2502 us | 2046.8750 | 1968.7500 | 1562.5000 |  12179720 B |
|          FisherYates | 1000000 |  31,391.412 us |  39,299.1860 us |  2,154.1210 us |         - |         - |         - |       280 B |
| FisherYatesAscending | 1000000 |  33,807.992 us | 116,853.8189 us |  6,405.1521 us |         - |         - |         - |       280 B |
|              Sattolo | 1000000 |  30,384.694 us |   9,185.7873 us |    503.5040 us |         - |         - |         - |       280 B |
|       LinqWithRandom | 1000000 | 398,250.867 us | 267,720.6432 us | 14,674.6718 us |         - |         - |         - |  16000816 B |
|         LinqWithGuid | 1000000 | 580,011.700 us | 747,808.2953 us | 40,989.8960 us | 1000.0000 | 1000.0000 | 1000.0000 |  28000704 B |
|      PLinqWithRandom | 1000000 | 109,456.207 us |  74,907.5261 us |  4,105.9343 us | 1600.0000 | 1200.0000 | 1200.0000 |  61150251 B |
|        PLinqWithGuid | 1000000 | 169,834.400 us | 199,894.7627 us | 10,956.9065 us | 1666.6667 | 1333.3333 | 1333.3333 | 110218867 B |