# ConcurrentDictionary using GetOrAdd vs. using TryGetvalue first.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                    | Count | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------ |--------------:|-------------:|-------------:|------:|--------:|--------:|----------:|------------:|
| **FindMatchesUsingGetOrAddCacheHit**                          | **10**    |      **58.81 ns** |     **0.493 ns** |     **0.461 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | 10    |     216.90 ns |     1.331 ns |     1.245 ns |  3.69 |    0.03 |  0.0172 |     288 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 10    |      58.72 ns |     0.438 ns |     0.388 ns |  1.00 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 10    |      56.96 ns |     0.390 ns |     0.346 ns |  0.97 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 10    |     209.85 ns |     1.099 ns |     0.974 ns |  3.57 |    0.03 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 10    |      55.16 ns |     0.237 ns |     0.222 ns |  0.94 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 10    |      57.78 ns |     0.448 ns |     0.419 ns |  0.98 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 10    |     211.56 ns |     0.751 ns |     0.627 ns |  3.60 |    0.03 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 10    |      55.10 ns |     0.087 ns |     0.072 ns |  0.94 |    0.01 |       - |         - |          NA |
|                                                           |       |               |              |              |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **100**   |     **619.74 ns** |     **4.501 ns** |     **4.210 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | 100   |   2,665.37 ns |    27.600 ns |    25.817 ns |  4.30 |    0.05 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 100   |     605.66 ns |     3.724 ns |     3.301 ns |  0.98 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 100   |     597.15 ns |     4.135 ns |     3.666 ns |  0.96 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 100   |   2,640.25 ns |    20.593 ns |    19.263 ns |  4.26 |    0.04 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 100   |     593.66 ns |     7.946 ns |     7.433 ns |  0.96 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 100   |     579.07 ns |     6.070 ns |     5.678 ns |  0.93 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 100   |   2,628.82 ns |    25.080 ns |    22.233 ns |  4.24 |    0.04 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 100   |     564.16 ns |     4.233 ns |     3.959 ns |  0.91 |    0.01 |       - |         - |          NA |
|                                                           |       |               |              |              |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **10000** | **263,374.78 ns** | **3,524.012 ns** | **3,123.945 ns** |  **1.00** |    **0.02** | **18.5547** |  **310400 B** |        **1.00** |
| FindMatchesUsingGetOrAddCacheMiss                         | 10000 | 489,722.79 ns | 4,847.346 ns | 4,534.211 ns |  1.86 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 10000 | 282,986.25 ns | 3,397.737 ns | 3,178.246 ns |  1.07 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 10000 | 256,868.63 ns | 2,965.318 ns | 2,628.678 ns |  0.98 |    0.01 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 10000 | 489,964.12 ns | 4,508.362 ns | 3,996.546 ns |  1.86 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 10000 | 273,814.49 ns | 3,437.658 ns | 3,047.395 ns |  1.04 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 10000 | 261,413.79 ns | 2,980.099 ns | 2,641.780 ns |  0.99 |    0.01 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 10000 | 496,473.06 ns | 4,490.430 ns | 4,200.351 ns |  1.89 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 10000 | 277,874.67 ns | 4,165.387 ns | 3,896.305 ns |  1.06 |    0.02 | 18.5547 |  310400 B |        1.00 |
