# Searching List<string>


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|              Method |   Count |            Mean |         Error |        StdDev | Ratio | RatioSD |
|-------------------- |-------- |----------------:|--------------:|--------------:|------:|--------:|
|       **ForLoopSearch** |      **10** |        **14.55 ns** |      **0.206 ns** |      **0.172 ns** |  **1.00** |    **0.00** |
|   ForEachLoopSearch |      10 |        13.66 ns |      0.107 ns |      0.095 ns |  0.94 |    0.01 |
| ListFindIndexSearch |      10 |        19.80 ns |      0.127 ns |      0.119 ns |  1.36 |    0.01 |
|   ListIndexOfSearch |      10 |        28.87 ns |      0.195 ns |      0.292 ns |  1.99 |    0.04 |
|          LinqSearch |      10 |       189.62 ns |      1.174 ns |      1.098 ns | 13.02 |    0.14 |
|                     |         |                 |               |               |       |         |
|       **ForLoopSearch** |    **1000** |     **1,514.61 ns** |      **4.560 ns** |      **4.266 ns** |  **1.00** |    **0.00** |
|   ForEachLoopSearch |    1000 |     1,270.74 ns |      2.513 ns |      2.227 ns |  0.84 |    0.00 |
| ListFindIndexSearch |    1000 |     1,269.07 ns |      2.726 ns |      2.417 ns |  0.84 |    0.00 |
|   ListIndexOfSearch |    1000 |     2,218.90 ns |     35.800 ns |     31.736 ns |  1.46 |    0.02 |
|          LinqSearch |    1000 |     8,820.63 ns |     27.463 ns |     22.933 ns |  5.82 |    0.02 |
|                     |         |                 |               |               |       |         |
|       **ForLoopSearch** | **1000000** | **2,257,773.28 ns** | **21,544.565 ns** | **20,152.800 ns** |  **1.00** |    **0.00** |
|   ForEachLoopSearch | 1000000 | 2,327,267.42 ns | 18,156.573 ns | 16,983.670 ns |  1.03 |    0.01 |
| ListFindIndexSearch | 1000000 | 2,067,626.90 ns | 14,038.578 ns | 12,444.834 ns |  0.92 |    0.01 |
|   ListIndexOfSearch | 1000000 | 2,691,191.68 ns | 50,452.284 ns | 47,193.098 ns |  1.19 |    0.02 |
|          LinqSearch | 1000000 | 8,348,764.69 ns | 89,068.763 ns | 83,314.976 ns |  3.70 |    0.04 |
