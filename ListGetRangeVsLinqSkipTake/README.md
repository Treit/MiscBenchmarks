# List index vs. ElementAt



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | ListSize | RangeSize | Mean            | Error         | StdDev        | Ratio     | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------------ |---------- |---------- |--------- |---------- |----------------:|--------------:|--------------:|----------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **ToListDotGetRangeFirstN** | **.NET 10.0** | **.NET 10.0** | **10**       | **5**         |        **32.90 ns** |      **0.419 ns** |      **0.448 ns** |      **0.93** |    **0.01** |   **0.0138** |        **-** |        **-** |     **232 B** |        **2.42** |
| LinqSkipTakeFirstN      | .NET 10.0 | .NET 10.0 | 10       | 5         |        35.51 ns |      0.337 ns |      0.282 ns |      1.00 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 10.0 | .NET 10.0 | 10       | 5         |        31.00 ns |      0.619 ns |      0.688 ns |      0.87 |    0.02 |   0.0138 |        - |        - |     232 B |        2.42 |
| LinqSkipTakeLastN       | .NET 10.0 | .NET 10.0 | 10       | 5         |        36.67 ns |      0.467 ns |      0.437 ns |      1.03 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                         |           |           |          |           |                 |               |               |           |         |          |          |          |           |             |
| ToListDotGetRangeFirstN | .NET 9.0  | .NET 9.0  | 10       | 5         |        33.41 ns |      0.694 ns |      0.649 ns |      0.93 |    0.02 |   0.0138 |        - |        - |     232 B |        2.42 |
| LinqSkipTakeFirstN      | .NET 9.0  | .NET 9.0  | 10       | 5         |        36.04 ns |      0.291 ns |      0.272 ns |      1.00 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 9.0  | .NET 9.0  | 10       | 5         |        31.80 ns |      0.328 ns |      0.307 ns |      0.88 |    0.01 |   0.0138 |        - |        - |     232 B |        2.42 |
| LinqSkipTakeLastN       | .NET 9.0  | .NET 9.0  | 10       | 5         |        35.39 ns |      0.226 ns |      0.212 ns |      0.98 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                         |           |           |          |           |                 |               |               |           |         |          |          |          |           |             |
| **ToListDotGetRangeFirstN** | **.NET 10.0** | **.NET 10.0** | **10**       | **100**       |        **35.26 ns** |      **0.319 ns** |      **0.298 ns** |      **0.70** |    **0.01** |   **0.0162** |        **-** |        **-** |     **272 B** |        **2.83** |
| LinqSkipTakeFirstN      | .NET 10.0 | .NET 10.0 | 10       | 100       |        50.03 ns |      0.248 ns |      0.232 ns |      1.00 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 10.0 | .NET 10.0 | 10       | 100       |              NA |            NA |            NA |         ? |       ? |       NA |       NA |       NA |        NA |           ? |
| LinqSkipTakeLastN       | .NET 10.0 | .NET 10.0 | 10       | 100       |        49.25 ns |      0.224 ns |      0.209 ns |      0.98 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                         |           |           |          |           |                 |               |               |           |         |          |          |          |           |             |
| ToListDotGetRangeFirstN | .NET 9.0  | .NET 9.0  | 10       | 100       |        34.74 ns |      0.379 ns |      0.355 ns |      0.70 |    0.01 |   0.0162 |        - |        - |     272 B |        2.83 |
| LinqSkipTakeFirstN      | .NET 9.0  | .NET 9.0  | 10       | 100       |        49.48 ns |      0.420 ns |      0.351 ns |      1.00 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 9.0  | .NET 9.0  | 10       | 100       |              NA |            NA |            NA |         ? |       ? |       NA |       NA |       NA |        NA |           ? |
| LinqSkipTakeLastN       | .NET 9.0  | .NET 9.0  | 10       | 100       |        49.46 ns |      0.310 ns |      0.290 ns |      1.00 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                         |           |           |          |           |                 |               |               |           |         |          |          |          |           |             |
| **ToListDotGetRangeFirstN** | **.NET 10.0** | **.NET 10.0** | **1000000**  | **5**         | **2,508,396.12 ns** | **22,202.012 ns** | **19,681.505 ns** | **67,441.72** |  **579.66** | **394.5313** | **394.5313** | **394.5313** | **8000275 B** |   **83,336.20** |
| LinqSkipTakeFirstN      | .NET 10.0 | .NET 10.0 | 1000000  | 5         |        37.19 ns |      0.187 ns |      0.156 ns |      1.00 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 10.0 | .NET 10.0 | 1000000  | 5         | 2,515,251.52 ns | 24,365.540 ns | 22,791.542 ns | 67,626.04 |  653.62 | 394.5313 | 394.5313 | 394.5313 | 8000275 B |   83,336.20 |
| LinqSkipTakeLastN       | .NET 10.0 | .NET 10.0 | 1000000  | 5         |        35.67 ns |      0.193 ns |      0.171 ns |      0.96 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                         |           |           |          |           |                 |               |               |           |         |          |          |          |           |             |
| ToListDotGetRangeFirstN | .NET 9.0  | .NET 9.0  | 1000000  | 5         | 2,528,963.70 ns | 21,563.718 ns | 20,170.715 ns | 68,955.58 |  676.35 | 394.5313 | 394.5313 | 394.5313 | 8000275 B |   83,336.20 |
| LinqSkipTakeFirstN      | .NET 9.0  | .NET 9.0  | 1000000  | 5         |        36.68 ns |      0.259 ns |      0.229 ns |      1.00 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 9.0  | .NET 9.0  | 1000000  | 5         | 2,523,753.32 ns | 32,786.260 ns | 29,064.165 ns | 68,813.52 |  871.37 | 394.5313 | 394.5313 | 394.5313 | 8000275 B |   83,336.20 |
| LinqSkipTakeLastN       | .NET 9.0  | .NET 9.0  | 1000000  | 5         |        37.34 ns |      0.221 ns |      0.196 ns |      1.02 |    0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                         |           |           |          |           |                 |               |               |           |         |          |          |          |           |             |
| **ToListDotGetRangeFirstN** | **.NET 10.0** | **.NET 10.0** | **1000000**  | **100**       | **2,529,975.78 ns** | **25,746.756 ns** | **22,823.829 ns** |  **9,104.97** |   **80.24** | **394.5313** | **394.5313** | **394.5313** | **8001035 B** |   **83,344.11** |
| LinqSkipTakeFirstN      | .NET 10.0 | .NET 10.0 | 1000000  | 100       |       277.87 ns |      0.475 ns |      0.371 ns |      1.00 |    0.00 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 10.0 | .NET 10.0 | 1000000  | 100       | 2,532,160.99 ns | 39,268.477 ns | 36,731.758 ns |  9,112.84 |  128.60 | 394.5313 | 394.5313 | 394.5313 | 8001035 B |   83,344.11 |
| LinqSkipTakeLastN       | .NET 10.0 | .NET 10.0 | 1000000  | 100       |       274.22 ns |      0.913 ns |      0.809 ns |      0.99 |    0.00 |   0.0057 |        - |        - |      96 B |        1.00 |
|                         |           |           |          |           |                 |               |               |           |         |          |          |          |           |             |
| ToListDotGetRangeFirstN | .NET 9.0  | .NET 9.0  | 1000000  | 100       | 2,535,353.37 ns | 41,856.687 ns | 39,152.771 ns |  9,239.67 |  139.78 | 394.5313 | 394.5313 | 394.5313 | 8001035 B |   83,344.11 |
| LinqSkipTakeFirstN      | .NET 9.0  | .NET 9.0  | 1000000  | 100       |       274.40 ns |      0.733 ns |      0.650 ns |      1.00 |    0.00 |   0.0057 |        - |        - |      96 B |        1.00 |
| ToListDotGetRangeLastN  | .NET 9.0  | .NET 9.0  | 1000000  | 100       | 2,533,824.84 ns | 24,952.544 ns | 23,340.625 ns |  9,234.10 |   85.04 | 394.5313 | 394.5313 | 394.5313 | 8001035 B |   83,344.11 |
| LinqSkipTakeLastN       | .NET 9.0  | .NET 9.0  | 1000000  | 100       |       292.84 ns |      0.562 ns |      0.469 ns |      1.07 |    0.00 |   0.0057 |        - |        - |      96 B |        1.00 |

Benchmarks with issues:
  Benchmark.ToListDotGetRangeLastN: .NET 10.0(Runtime=.NET 10.0) [ListSize=10, RangeSize=100]
  Benchmark.ToListDotGetRangeLastN: .NET 9.0(Runtime=.NET 9.0) [ListSize=10, RangeSize=100]
