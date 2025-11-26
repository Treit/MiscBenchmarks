Shuffling using cryptographically strong RNG vs. normal System.Random RNG.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count | MaxItems | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------ |------ |--------- |-------------:|------------:|------------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ShuffleWithSecureRandom** | **100**   | **-1**       |   **7,532.0 ns** |    **20.10 ns** |    **17.81 ns** | **14.33** |    **0.17** | **0.0534** |      **-** |     **912 B** |        **1.00** |
| ShuffleWithSystemRandom | 100   | -1       |     525.8 ns |     6.92 ns |     6.47 ns |  1.00 |    0.02 | 0.0544 |      - |     912 B |        1.00 |
|                         |       |          |              |             |             |       |         |        |        |           |             |
| **ShuffleWithSecureRandom** | **100**   | **50**       |   **7,523.8 ns** |    **25.98 ns** |    **24.30 ns** | **13.33** |    **0.33** | **0.0381** |      **-** |     **760 B** |        **1.00** |
| ShuffleWithSystemRandom | 100   | 50       |     564.6 ns |    10.98 ns |    13.88 ns |  1.00 |    0.03 | 0.0448 |      - |     760 B |        1.00 |
|                         |       |          |              |             |             |       |         |        |        |           |             |
| **ShuffleWithSecureRandom** | **10000** | **-1**       | **775,102.5 ns** | **4,573.40 ns** | **4,054.20 ns** | **16.21** |    **0.17** | **3.9063** |      **-** |   **80112 B** |        **1.00** |
| ShuffleWithSystemRandom | 10000 | -1       |  47,821.8 ns |   526.23 ns |   466.49 ns |  1.00 |    0.01 | 4.7607 | 0.5493 |   80112 B |        1.00 |
|                         |       |          |              |             |             |       |         |        |        |           |             |
| **ShuffleWithSecureRandom** | **10000** | **50**       | **779,081.1 ns** | **3,663.03 ns** | **3,426.40 ns** | **16.79** |    **0.18** | **1.9531** |      **-** |   **40360 B** |        **1.00** |
| ShuffleWithSystemRandom | 10000 | 50       |  46,413.1 ns |   518.26 ns |   484.78 ns |  1.00 |    0.01 | 2.3804 | 0.2441 |   40360 B |        1.00 |
