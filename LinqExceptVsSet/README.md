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
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count   | Mean             | Error            | StdDev           | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------- |-------- |-----------------:|-----------------:|-----------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **SetDifferenceUsingLinq**    | **10**      |        **476.56 ns** |         **7.069 ns** |         **6.267 ns** |  **7.03** |    **0.11** |   **0.0610** |        **-** |        **-** |     **1024 B** |       **25.60** |
| SetDifferenceUsingHashSet | 10      |         67.82 ns |         0.643 ns |         0.602 ns |  1.00 |    0.01 |   0.0024 |        - |        - |       40 B |        1.00 |
|                           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **100**     |      **2,596.25 ns** |        **21.723 ns** |        **20.320 ns** |  **4.32** |    **0.04** |   **0.1450** |        **-** |        **-** |     **2432 B** |       **60.80** |
| SetDifferenceUsingHashSet | 100     |        601.22 ns |         2.878 ns |         2.403 ns |  1.00 |    0.01 |   0.0019 |        - |        - |       40 B |        1.00 |
|                           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **1000**    |     **27,964.48 ns** |       **241.396 ns** |       **213.992 ns** |  **4.63** |    **0.04** |   **1.3123** |   **0.0916** |        **-** |    **22352 B** |      **558.80** |
| SetDifferenceUsingHashSet | 1000    |      6,042.43 ns |        28.357 ns |        22.139 ns |  1.00 |    0.00 |        - |        - |        - |       40 B |        1.00 |
|                           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **100000**  |  **5,869,838.44 ns** |    **58,694.547 ns** |    **54,902.916 ns** |  **6.23** |    **0.06** | **234.3750** | **234.3750** | **234.3750** |  **2174786 B** |   **54,369.65** |
| SetDifferenceUsingHashSet | 100000  |    941,754.34 ns |     3,145.067 ns |     2,626.273 ns |  1.00 |    0.00 |        - |        - |        - |       40 B |        1.00 |
|                           |         |                  |                  |                  |       |         |          |          |          |            |             |
| **SetDifferenceUsingLinq**    | **1000000** | **91,771,286.96 ns** | **1,808,492.786 ns** | **3,484,351.892 ns** |  **7.31** |    **0.28** |        **-** |        **-** |        **-** | **23254032 B** |  **581,350.80** |
| SetDifferenceUsingHashSet | 1000000 | 12,548,675.00 ns |    56,641.249 ns |    50,210.992 ns |  1.00 |    0.01 |        - |        - |        - |       40 B |        1.00 |
