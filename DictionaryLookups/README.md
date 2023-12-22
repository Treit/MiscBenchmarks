# Dictionary lookups.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26020.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
|                          Method | Iterations |                 Mean |              Error |             StdDev |               Median | Ratio | RatioSD |       Gen0 |   Allocated | Alloc Ratio |
|-------------------------------- |----------- |---------------------:|-------------------:|-------------------:|---------------------:|------:|--------:|-----------:|------------:|------------:|
|           **LookupUsingDictionary** |         **10** |        **15,689.264 ns** |        **313.1248 ns** |         **514.473 ns** |        **15,606.952 ns** | **1.000** |    **0.00** |          **-** |           **-** |          **NA** |
|           LookupUsingSortedList |         10 |        18,793.415 ns |        363.6795 ns |         373.472 ns |        18,858.757 ns | 1.183 |    0.04 |          - |           - |          NA |
|     LookupUsingSortedDictionary |         10 |        25,722.356 ns |        552.5275 ns |       1,585.305 ns |        25,342.889 ns | 1.675 |    0.11 |          - |           - |          NA |
| LookupUsingConcurrentDictionary |         10 |       149,946.949 ns |      2,994.9511 ns |       6,185.093 ns |       149,539.001 ns | 9.527 |    0.53 |          - |           - |          NA |
|    LookupUsingOrderedDictionary |         10 |        14,225.327 ns |        283.2650 ns |         496.116 ns |        14,078.505 ns | 0.908 |    0.04 |          - |           - |          NA |
|            LookupUsingHashtable |         10 |        22,946.124 ns |        565.3567 ns |       1,658.093 ns |        22,456.134 ns | 1.413 |    0.06 |     2.7771 |     12000 B |          NA |
|     LookupUsingFrozenDictionary |         10 |             7.788 ns |          0.4101 ns |           1.203 ns |             7.427 ns | 0.000 |    0.00 |          - |           - |          NA |
|                                 |            |                      |                    |                    |                      |       |         |            |             |             |
|           **LookupUsingDictionary** |     **100000** |   **159,431,888.194 ns** |  **2,959,455.7231 ns** |   **4,944,585.684 ns** |   **159,326,925.000 ns** | **1.000** |    **0.00** |          **-** |           **-** |          **NA** |
|           LookupUsingSortedList |     100000 |   192,630,757.576 ns |  3,835,925.5272 ns |   9,832,943.593 ns |   189,920,166.667 ns | 1.220 |    0.09 |          - |           - |          NA |
|     LookupUsingSortedDictionary |     100000 |   249,222,628.455 ns |  4,956,793.3188 ns |   8,938,120.815 ns |   245,414,600.000 ns | 1.565 |    0.07 |          - |           - |          NA |
| LookupUsingConcurrentDictionary |     100000 | 1,641,951,363.000 ns | 47,381,293.6977 ns | 139,704,813.500 ns | 1,625,627,450.000 ns | 9.693 |    0.81 |          - |           - |          NA |
|    LookupUsingOrderedDictionary |     100000 |   172,715,128.000 ns |  3,392,516.4770 ns |   4,528,912.053 ns |   173,167,866.667 ns | 1.090 |    0.05 |          - |           - |          NA |
|            LookupUsingHashtable |     100000 |   269,928,747.368 ns |  5,276,547.8575 ns |   5,864,868.963 ns |   271,373,600.000 ns | 1.705 |    0.07 | 27500.0000 | 120000200 B |          NA |
|     LookupUsingFrozenDictionary |     100000 |       240,828.067 ns |      4,696.9421 ns |       6,584.457 ns |       242,026.807 ns | 0.002 |    0.00 |          - |           - |          NA |
