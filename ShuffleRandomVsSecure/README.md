Shuffling using cryptographically strong RNG vs. normal System.Random RNG.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27891.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                  | Count | MaxItems | Mean           | Error        | StdDev       | Median         | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------ |------ |--------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|--------:|-------:|----------:|------------:|
| **ShuffleWithSecureRandom** | **100**   | **-1**       |    **13,085.4 ns** |    **239.36 ns** |    **488.95 ns** |    **12,960.9 ns** | **17.37** |    **1.01** |  **0.1984** |      **-** |     **912 B** |        **1.00** |
| ShuffleWithSystemRandom | 100   | -1       |       754.7 ns |     15.04 ns |     35.15 ns |       752.3 ns |  1.00 |    0.06 |  0.2108 |      - |     912 B |        1.00 |
|                         |       |          |                |              |              |                |       |         |         |        |           |             |
| **ShuffleWithSecureRandom** | **100**   | **50**       |    **12,679.8 ns** |    **223.15 ns** |    **372.83 ns** |    **12,553.3 ns** | **16.72** |    **0.51** |  **0.1678** |      **-** |     **760 B** |        **1.00** |
| ShuffleWithSystemRandom | 100   | 50       |       758.3 ns |      7.80 ns |      7.30 ns |       756.7 ns |  1.00 |    0.01 |  0.1755 |      - |     760 B |        1.00 |
|                         |       |          |                |              |              |                |       |         |         |        |           |             |
| **ShuffleWithSecureRandom** | **10000** | **-1**       | **1,241,096.3 ns** | **14,955.88 ns** | **12,488.84 ns** | **1,239,106.6 ns** | **18.55** |    **0.46** | **17.5781** | **1.9531** |   **80112 B** |        **1.00** |
| ShuffleWithSystemRandom | 10000 | -1       |    66,923.6 ns |  1,289.12 ns |  1,583.16 ns |    66,609.5 ns |  1.00 |    0.03 | 18.4326 | 1.9531 |   80112 B |        1.00 |
|                         |       |          |                |              |              |                |       |         |         |        |           |             |
| **ShuffleWithSecureRandom** | **10000** | **50**       | **1,290,558.9 ns** | **24,798.89 ns** | **27,563.90 ns** | **1,291,617.4 ns** | **19.17** |    **1.38** |  **7.8125** |      **-** |   **40360 B** |        **1.00** |
| ShuffleWithSystemRandom | 10000 | 50       |    67,662.3 ns |  1,733.46 ns |  5,029.08 ns |    65,352.0 ns |  1.01 |    0.10 |  9.2773 | 0.9766 |   40360 B |        1.00 |
