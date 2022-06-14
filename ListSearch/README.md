# Searching List<string>

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.300
  [Host]     : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT


```
|              Method |   Count |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD |
|-------------------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
|       **ForLoopSearch** |      **10** |         **21.87 ns** |       **0.688 ns** |       **2.008 ns** |         **21.74 ns** |  **1.00** |    **0.00** |
|   ForEachLoopSearch |      10 |         29.31 ns |       0.632 ns |       1.478 ns |         29.31 ns |  1.31 |    0.14 |
| ListFindIndexSearch |      10 |         47.81 ns |       0.990 ns |       2.254 ns |         47.75 ns |  2.12 |    0.19 |
|   ListIndexOfSearch |      10 |         60.54 ns |       1.909 ns |       5.537 ns |         60.04 ns |  2.79 |    0.39 |
|          LinqSearch |      10 |        394.91 ns |       8.219 ns |      24.105 ns |        392.48 ns | 18.21 |    1.97 |
|                     |         |                  |                |                |                  |       |         |
|       **ForLoopSearch** |    **1000** |      **2,322.08 ns** |      **99.837 ns** |     **292.804 ns** |      **2,217.46 ns** |  **1.00** |    **0.00** |
|   ForEachLoopSearch |    1000 |      2,976.33 ns |      58.903 ns |     126.795 ns |      2,956.90 ns |  1.26 |    0.16 |
| ListFindIndexSearch |    1000 |      3,095.24 ns |      54.582 ns |      62.856 ns |      3,095.51 ns |  1.40 |    0.13 |
|   ListIndexOfSearch |    1000 |      4,721.61 ns |      99.865 ns |     286.532 ns |      4,681.68 ns |  2.06 |    0.27 |
|          LinqSearch |    1000 |     15,661.30 ns |     305.787 ns |     651.657 ns |     15,714.44 ns |  6.63 |    0.91 |
|                     |         |                  |                |                |                  |       |         |
|       **ForLoopSearch** | **1000000** |  **4,482,080.23 ns** |  **80,552.774 ns** |  **75,349.114 ns** |  **4,488,634.77 ns** |  **1.00** |    **0.00** |
|   ForEachLoopSearch | 1000000 |  4,750,204.02 ns |  94,436.482 ns | 216,983.523 ns |  4,678,697.66 ns |  1.10 |    0.06 |
| ListFindIndexSearch | 1000000 |  5,222,144.45 ns |  97,703.716 ns | 218,528.361 ns |  5,222,998.83 ns |  1.14 |    0.05 |
|   ListIndexOfSearch | 1000000 |  6,034,313.58 ns | 161,040.136 ns | 459,456.569 ns |  5,909,725.00 ns |  1.34 |    0.08 |
|          LinqSearch | 1000000 | 18,071,109.73 ns | 360,695.543 ns | 937,495.674 ns | 17,900,887.50 ns |  4.14 |    0.30 |
