# Linq 'Except' vs HashSet for computing set difference.
Not exactly an apples-to-apples comparison since the HashSet version mutates the first set instead of creating a new one for the results.

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                    Method |   Count |             Mean |            Error |           StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|-------------------------- |-------- |-----------------:|-----------------:|-----------------:|------:|--------:|---------:|---------:|---------:|-----------:|
|    SetDifferenceUsingLinq |      10 |       1,320.7 ns |       1,344.9 ns |         73.72 ns |  5.26 |    0.42 |   0.1774 |        - |        - |      768 B |
| SetDifferenceUsingHashSet |      10 |         251.7 ns |         209.3 ns |         11.47 ns |  1.00 |    0.00 |   0.0091 |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq |     100 |      10,724.8 ns |       5,263.9 ns |        288.53 ns |  4.47 |    0.39 |   1.2360 |        - |        - |     5344 B |
| SetDifferenceUsingHashSet |     100 |       2,411.7 ns |       3,714.5 ns |        203.60 ns |  1.00 |    0.00 |   0.0076 |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq |    1000 |     116,875.3 ns |      18,187.3 ns |        996.91 ns |  5.15 |    0.88 |   9.5215 |        - |        - |    41280 B |
| SetDifferenceUsingHashSet |    1000 |      23,163.3 ns |      75,672.3 ns |      4,147.85 ns |  1.00 |    0.00 |        - |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq |  100000 |  18,765,656.2 ns |  27,273,605.6 ns |  1,494,958.35 ns |  6.00 |    0.56 | 406.2500 | 375.0000 | 375.0000 |  5243906 B |
| SetDifferenceUsingHashSet |  100000 |   3,131,171.8 ns |   2,762,805.2 ns |    151,438.68 ns |  1.00 |    0.00 |        - |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq | 1000000 | 421,657,133.3 ns | 372,056,411.9 ns | 20,393,667.39 ns |  6.13 |    0.69 |        - |        - |        - | 41943680 B |
| SetDifferenceUsingHashSet | 1000000 |  69,200,800.0 ns |  98,575,578.4 ns |  5,403,260.08 ns |  1.00 |    0.00 |        - |        - |        - |      269 B |




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count   | Mean             | Error            | StdDev           | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------- |---------- |---------- |-------- |-----------------:|-----------------:|-----------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **SetDifferenceUsingLinq**    | **.NET 10.0** | **.NET 10.0** | **10**      |        **495.80 ns** |         **9.617 ns** |         **8.996 ns** |  **7.33** |    **0.15** |   **0.0610** |        **-** |        **-** |     **1024 B** |       **25.60** |
| SetDifferenceUsingHashSet | .NET 10.0 | .NET 10.0 | 10      |         67.61 ns |         0.777 ns |         0.726 ns |  1.00 |    0.01 |   0.0024 |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| SetDifferenceUsingLinq    | .NET 9.0  | .NET 9.0  | 10      |        511.60 ns |         3.643 ns |         3.042 ns |  7.59 |    0.09 |   0.0610 |        - |        - |     1024 B |       25.60 |
| SetDifferenceUsingHashSet | .NET 9.0  | .NET 9.0  | 10      |         67.38 ns |         0.750 ns |         0.702 ns |  1.00 |    0.01 |   0.0024 |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **.NET 10.0** | **.NET 10.0** | **100**     |      **2,649.38 ns** |        **24.687 ns** |        **23.092 ns** |  **4.40** |    **0.05** |   **0.1450** |        **-** |        **-** |     **2432 B** |       **60.80** |
| SetDifferenceUsingHashSet | .NET 10.0 | .NET 10.0 | 100     |        602.62 ns |         6.035 ns |         5.350 ns |  1.00 |    0.01 |   0.0019 |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| SetDifferenceUsingLinq    | .NET 9.0  | .NET 9.0  | 100     |      2,610.96 ns |        20.803 ns |        19.459 ns |  4.31 |    0.04 |   0.1450 |        - |        - |     2432 B |       60.80 |
| SetDifferenceUsingHashSet | .NET 9.0  | .NET 9.0  | 100     |        606.41 ns |         4.815 ns |         4.504 ns |  1.00 |    0.01 |   0.0019 |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **.NET 10.0** | **.NET 10.0** | **1000**    |     **28,215.46 ns** |       **178.104 ns** |       **166.599 ns** |  **4.88** |    **0.04** |   **1.3123** |   **0.0916** |        **-** |    **22352 B** |      **558.80** |
| SetDifferenceUsingHashSet | .NET 10.0 | .NET 10.0 | 1000    |      5,786.66 ns |        41.850 ns |        37.099 ns |  1.00 |    0.01 |        - |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| SetDifferenceUsingLinq    | .NET 9.0  | .NET 9.0  | 1000    |     27,831.79 ns |       162.775 ns |       144.295 ns |  4.78 |    0.04 |   1.3123 |   0.0916 |        - |    22352 B |      558.80 |
| SetDifferenceUsingHashSet | .NET 9.0  | .NET 9.0  | 1000    |      5,820.24 ns |        58.138 ns |        48.548 ns |  1.00 |    0.01 |        - |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **.NET 10.0** | **.NET 10.0** | **100000**  |  **6,298,474.04 ns** |    **48,777.536 ns** |    **45,626.537 ns** |  **6.64** |    **0.08** | **335.9375** | **335.9375** | **296.8750** |  **2173034 B** |   **54,325.85** |
| SetDifferenceUsingHashSet | .NET 10.0 | .NET 10.0 | 100000  |    949,243.12 ns |     9,285.779 ns |     8,685.924 ns |  1.00 |    0.01 |        - |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| SetDifferenceUsingLinq    | .NET 9.0  | .NET 9.0  | 100000  |  6,326,399.25 ns |    71,956.151 ns |    60,086.645 ns |  6.78 |    0.07 | 335.9375 | 335.9375 | 296.8750 |  2173034 B |   54,325.85 |
| SetDifferenceUsingHashSet | .NET 9.0  | .NET 9.0  | 100000  |    933,081.69 ns |     6,366.635 ns |     5,643.857 ns |  1.00 |    0.01 |        - |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **.NET 10.0** | **.NET 10.0** | **1000000** | **94,271,874.38 ns** | **1,882,975.244 ns** | **4,960,510.317 ns** |  **7.57** |    **0.40** |        **-** |        **-** |        **-** | **23254032 B** |  **581,350.80** |
| SetDifferenceUsingHashSet | .NET 10.0 | .NET 10.0 | 1000000 | 12,455,597.00 ns |   160,212.940 ns |   133,785.061 ns |  1.00 |    0.01 |        - |        - |        - |       40 B |        1.00 |
|                           |           |           |         |                  |                  |                  |       |         |          |          |          |            |             |
| SetDifferenceUsingLinq    | .NET 9.0  | .NET 9.0  | 1000000 | 92,192,419.34 ns | 1,841,058.943 ns | 3,842,975.896 ns |  7.37 |    0.31 |        - |        - |        - | 23254032 B |  581,350.80 |
| SetDifferenceUsingHashSet | .NET 9.0  | .NET 9.0  | 1000000 | 12,506,043.96 ns |    95,671.453 ns |    89,491.136 ns |  1.00 |    0.01 |        - |        - |        - |       40 B |        1.00 |
