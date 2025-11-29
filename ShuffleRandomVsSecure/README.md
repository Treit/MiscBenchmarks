Shuffling using cryptographically strong RNG vs. normal System.Random RNG.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count | MaxItems | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------ |---------- |---------- |------ |--------- |-------------:|------------:|------------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ShuffleWithSecureRandom** | **.NET 10.0** | **.NET 10.0** | **100**   | **-1**       |   **7,538.3 ns** |    **23.35 ns** |    **20.70 ns** | **14.51** |    **0.08** | **0.0534** |      **-** |     **912 B** |        **1.00** |
| ShuffleWithSystemRandom | .NET 10.0 | .NET 10.0 | 100   | -1       |     519.5 ns |     2.86 ns |     2.53 ns |  1.00 |    0.01 | 0.0544 |      - |     912 B |        1.00 |
|                         |           |           |       |          |              |             |             |       |         |        |        |           |             |
| ShuffleWithSecureRandom | .NET 9.0  | .NET 9.0  | 100   | -1       |   7,504.3 ns |    38.38 ns |    34.02 ns | 14.46 |    0.15 | 0.0458 |      - |     912 B |        1.00 |
| ShuffleWithSystemRandom | .NET 9.0  | .NET 9.0  | 100   | -1       |     519.1 ns |     5.39 ns |     5.04 ns |  1.00 |    0.01 | 0.0544 |      - |     912 B |        1.00 |
|                         |           |           |       |          |              |             |             |       |         |        |        |           |             |
| **ShuffleWithSecureRandom** | **.NET 10.0** | **.NET 10.0** | **100**   | **50**       |   **7,454.4 ns** |    **31.40 ns** |    **27.83 ns** | **14.21** |    **0.08** | **0.0381** |      **-** |     **760 B** |        **1.00** |
| ShuffleWithSystemRandom | .NET 10.0 | .NET 10.0 | 100   | 50       |     524.6 ns |     2.76 ns |     2.44 ns |  1.00 |    0.01 | 0.0448 |      - |     760 B |        1.00 |
|                         |           |           |       |          |              |             |             |       |         |        |        |           |             |
| ShuffleWithSecureRandom | .NET 9.0  | .NET 9.0  | 100   | 50       |   7,432.6 ns |    17.49 ns |    14.61 ns | 14.11 |    0.05 | 0.0381 |      - |     760 B |        1.00 |
| ShuffleWithSystemRandom | .NET 9.0  | .NET 9.0  | 100   | 50       |     526.7 ns |     1.89 ns |     1.58 ns |  1.00 |    0.00 | 0.0448 |      - |     760 B |        1.00 |
|                         |           |           |       |          |              |             |             |       |         |        |        |           |             |
| **ShuffleWithSecureRandom** | **.NET 10.0** | **.NET 10.0** | **10000** | **-1**       | **771,268.2 ns** | **3,860.49 ns** | **3,611.11 ns** | **16.39** |    **0.09** | **3.9063** |      **-** |   **80112 B** |        **1.00** |
| ShuffleWithSystemRandom | .NET 10.0 | .NET 10.0 | 10000 | -1       |  47,061.1 ns |   210.19 ns |   175.52 ns |  1.00 |    0.01 | 4.7607 | 0.5493 |   80112 B |        1.00 |
|                         |           |           |       |          |              |             |             |       |         |        |        |           |             |
| ShuffleWithSecureRandom | .NET 9.0  | .NET 9.0  | 10000 | -1       | 769,950.9 ns | 2,216.57 ns | 1,964.93 ns | 16.10 |    0.07 | 3.9063 |      - |   80112 B |        1.00 |
| ShuffleWithSystemRandom | .NET 9.0  | .NET 9.0  | 10000 | -1       |  47,830.8 ns |   175.48 ns |   164.14 ns |  1.00 |    0.00 | 4.7607 | 0.5493 |   80112 B |        1.00 |
|                         |           |           |       |          |              |             |             |       |         |        |        |           |             |
| **ShuffleWithSecureRandom** | **.NET 10.0** | **.NET 10.0** | **10000** | **50**       | **766,007.9 ns** | **3,206.54 ns** | **2,842.52 ns** | **16.73** |    **0.12** | **1.9531** |      **-** |   **40360 B** |        **1.00** |
| ShuffleWithSystemRandom | .NET 10.0 | .NET 10.0 | 10000 | 50       |  45,782.9 ns |   312.52 ns |   292.34 ns |  1.00 |    0.01 | 2.3804 | 0.2441 |   40360 B |        1.00 |
|                         |           |           |       |          |              |             |             |       |         |        |        |           |             |
| ShuffleWithSecureRandom | .NET 9.0  | .NET 9.0  | 10000 | 50       | 763,773.0 ns | 2,754.36 ns | 2,300.02 ns | 16.85 |    0.08 | 1.9531 |      - |   40360 B |        1.00 |
| ShuffleWithSystemRandom | .NET 9.0  | .NET 9.0  | 10000 | 50       |  45,332.7 ns |   204.91 ns |   181.64 ns |  1.00 |    0.01 | 2.3804 | 0.2441 |   40360 B |        1.00 |
