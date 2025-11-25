# Searching List<string>



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Count   | Mean            | Error         | StdDev        | Median          | Ratio | RatioSD |
|-------------------- |-------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|
| **ForLoopSearch**       | **10**      |        **16.25 ns** |      **0.313 ns** |      **0.396 ns** |        **16.14 ns** |  **1.00** |    **0.03** |
| ForEachLoopSearch   | 10      |        13.77 ns |      0.288 ns |      0.241 ns |        13.74 ns |  0.85 |    0.02 |
| ListFindIndexSearch | 10      |        28.43 ns |      0.210 ns |      0.197 ns |        28.54 ns |  1.75 |    0.04 |
| ListIndexOfSearch   | 10      |        10.53 ns |      0.243 ns |      0.450 ns |        10.25 ns |  0.65 |    0.03 |
| LinqSearch          | 10      |       132.24 ns |      1.589 ns |      1.486 ns |       132.35 ns |  8.14 |    0.21 |
|                     |         |                 |               |               |                 |       |         |
| **ForLoopSearch**       | **1000**    |     **1,507.21 ns** |      **6.755 ns** |      **6.319 ns** |     **1,505.41 ns** |  **1.00** |    **0.01** |
| ForEachLoopSearch   | 1000    |     1,265.50 ns |      9.846 ns |      9.210 ns |     1,268.16 ns |  0.84 |    0.01 |
| ListFindIndexSearch | 1000    |     2,351.62 ns |     47.349 ns |    139.610 ns |     2,359.83 ns |  1.56 |    0.09 |
| ListIndexOfSearch   | 1000    |       957.98 ns |      8.598 ns |      8.043 ns |       961.52 ns |  0.64 |    0.01 |
| LinqSearch          | 1000    |     6,029.71 ns |    114.120 ns |    122.107 ns |     6,008.52 ns |  4.00 |    0.08 |
|                     |         |                 |               |               |                 |       |         |
| **ForLoopSearch**       | **1000000** | **2,352,149.51 ns** | **37,939.475 ns** | **35,488.609 ns** | **2,350,666.41 ns** |  **1.00** |    **0.02** |
| ForEachLoopSearch   | 1000000 | 2,169,543.80 ns | 15,968.249 ns | 14,936.710 ns | 2,170,366.41 ns |  0.92 |    0.01 |
| ListFindIndexSearch | 1000000 | 2,780,419.30 ns | 21,180.656 ns | 19,812.399 ns | 2,779,758.98 ns |  1.18 |    0.02 |
| ListIndexOfSearch   | 1000000 | 1,779,754.97 ns | 14,610.879 ns | 13,667.026 ns | 1,777,579.69 ns |  0.76 |    0.01 |
| LinqSearch          | 1000000 | 6,255,118.75 ns | 40,635.980 ns | 31,725.900 ns | 6,248,993.75 ns |  2.66 |    0.04 |
