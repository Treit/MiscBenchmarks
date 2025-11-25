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
| **FindMatchesUsingGetOrAddCacheHit**                          | **10**    |      **63.23 ns** |     **0.501 ns** |     **0.444 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | 10    |     215.78 ns |     1.436 ns |     1.273 ns |  3.41 |    0.03 |  0.0172 |     288 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 10    |      57.13 ns |     0.468 ns |     0.438 ns |  0.90 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 10    |      56.21 ns |     0.146 ns |     0.122 ns |  0.89 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 10    |     210.09 ns |     0.998 ns |     0.885 ns |  3.32 |    0.03 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 10    |      54.93 ns |     0.073 ns |     0.061 ns |  0.87 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 10    |      57.34 ns |     0.059 ns |     0.052 ns |  0.91 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 10    |     210.29 ns |     1.144 ns |     1.014 ns |  3.33 |    0.03 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 10    |      55.59 ns |     0.058 ns |     0.048 ns |  0.88 |    0.01 |       - |         - |          NA |
|                                                           |       |               |              |              |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **100**   |     **611.17 ns** |     **3.739 ns** |     **3.314 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | 100   |   2,640.54 ns |    18.802 ns |    17.588 ns |  4.32 |    0.04 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 100   |     599.27 ns |     6.957 ns |     6.508 ns |  0.98 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 100   |     587.73 ns |     3.684 ns |     3.446 ns |  0.96 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 100   |   2,615.37 ns |    19.189 ns |    17.010 ns |  4.28 |    0.04 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 100   |     589.78 ns |     4.143 ns |     3.875 ns |  0.97 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 100   |     579.51 ns |     6.917 ns |     6.470 ns |  0.95 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 100   |   2,628.22 ns |    34.199 ns |    31.990 ns |  4.30 |    0.06 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 100   |     575.30 ns |     4.827 ns |     4.516 ns |  0.94 |    0.01 |       - |         - |          NA |
|                                                           |       |               |              |              |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **10000** | **264,136.47 ns** | **3,029.730 ns** | **2,685.777 ns** |  **1.00** |    **0.01** | **18.5547** |  **310400 B** |        **1.00** |
| FindMatchesUsingGetOrAddCacheMiss                         | 10000 | 487,264.93 ns | 5,044.234 ns | 4,718.380 ns |  1.84 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 10000 | 281,802.03 ns | 3,866.363 ns | 3,228.588 ns |  1.07 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 10000 | 261,695.43 ns | 2,609.216 ns | 2,440.662 ns |  0.99 |    0.01 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 10000 | 492,667.17 ns | 5,479.199 ns | 5,125.246 ns |  1.87 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 10000 | 270,816.90 ns | 4,542.903 ns | 4,249.434 ns |  1.03 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 10000 | 260,930.99 ns | 3,430.092 ns | 3,208.510 ns |  0.99 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 10000 | 491,057.69 ns | 7,162.458 ns | 6,699.768 ns |  1.86 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 10000 | 276,826.18 ns | 3,804.135 ns | 3,558.390 ns |  1.05 |    0.02 | 18.5547 |  310400 B |        1.00 |
