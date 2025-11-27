# ConcurrentDictionary using GetOrAdd vs. using TryGetvalue first.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                    | Job       | Runtime   | Count | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------------------------------------------- |---------- |---------- |------ |--------------:|-------------:|-------------:|------:|--------:|--------:|----------:|------------:|
| **FindMatchesUsingGetOrAddCacheHit**                          | **.NET 10.0** | **.NET 10.0** | **10**    |      **61.75 ns** |     **0.842 ns** |     **0.787 ns** |  **1.00** |    **0.02** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | .NET 10.0 | .NET 10.0 | 10    |     217.62 ns |     1.579 ns |     1.477 ns |  3.52 |    0.05 |  0.0172 |     288 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | .NET 10.0 | .NET 10.0 | 10    |      60.01 ns |     0.533 ns |     0.473 ns |  0.97 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | .NET 10.0 | .NET 10.0 | 10    |      59.82 ns |     0.906 ns |     0.803 ns |  0.97 |    0.02 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | .NET 10.0 | .NET 10.0 | 10    |     214.22 ns |     1.232 ns |     1.153 ns |  3.47 |    0.05 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | .NET 10.0 | .NET 10.0 | 10    |      53.64 ns |     0.420 ns |     0.393 ns |  0.87 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | .NET 10.0 | .NET 10.0 | 10    |      55.12 ns |     0.215 ns |     0.168 ns |  0.89 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | .NET 10.0 | .NET 10.0 | 10    |     213.47 ns |     1.567 ns |     1.466 ns |  3.46 |    0.05 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | .NET 10.0 | .NET 10.0 | 10    |      53.26 ns |     0.314 ns |     0.262 ns |  0.86 |    0.01 |       - |         - |          NA |
|                                                           |           |           |       |               |              |              |       |         |         |           |             |
| FindMatchesUsingGetOrAddCacheHit                          | .NET 9.0  | .NET 9.0  | 10    |      62.54 ns |     0.671 ns |     0.628 ns |  1.00 |    0.01 |       - |         - |          NA |
| FindMatchesUsingGetOrAddCacheMiss                         | .NET 9.0  | .NET 9.0  | 10    |     219.07 ns |     1.665 ns |     1.558 ns |  3.50 |    0.04 |  0.0172 |     288 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | .NET 9.0  | .NET 9.0  | 10    |      61.08 ns |     0.611 ns |     0.572 ns |  0.98 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | .NET 9.0  | .NET 9.0  | 10    |      57.12 ns |     0.193 ns |     0.180 ns |  0.91 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | .NET 9.0  | .NET 9.0  | 10    |     215.12 ns |     1.693 ns |     1.584 ns |  3.44 |    0.04 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | .NET 9.0  | .NET 9.0  | 10    |      53.93 ns |     0.248 ns |     0.232 ns |  0.86 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | .NET 9.0  | .NET 9.0  | 10    |      55.74 ns |     0.215 ns |     0.179 ns |  0.89 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | .NET 9.0  | .NET 9.0  | 10    |     214.09 ns |     2.194 ns |     2.052 ns |  3.42 |    0.05 |  0.0172 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | .NET 9.0  | .NET 9.0  | 10    |      55.25 ns |     0.248 ns |     0.207 ns |  0.88 |    0.01 |       - |         - |          NA |
|                                                           |           |           |       |               |              |              |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **.NET 10.0** | **.NET 10.0** | **100**   |     **602.08 ns** |     **7.648 ns** |     **7.154 ns** |  **1.00** |    **0.02** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | .NET 10.0 | .NET 10.0 | 100   |   2,705.95 ns |    19.412 ns |    18.158 ns |  4.49 |    0.06 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | .NET 10.0 | .NET 10.0 | 100   |     604.85 ns |     6.560 ns |     6.136 ns |  1.00 |    0.02 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | .NET 10.0 | .NET 10.0 | 100   |     583.56 ns |     7.733 ns |     6.038 ns |  0.97 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | .NET 10.0 | .NET 10.0 | 100   |   2,663.57 ns |    16.769 ns |    14.003 ns |  4.42 |    0.06 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | .NET 10.0 | .NET 10.0 | 100   |     570.00 ns |     4.063 ns |     3.601 ns |  0.95 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | .NET 10.0 | .NET 10.0 | 100   |     583.27 ns |     5.517 ns |     5.160 ns |  0.97 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | .NET 10.0 | .NET 10.0 | 100   |   2,664.15 ns |    27.778 ns |    25.983 ns |  4.43 |    0.07 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | .NET 10.0 | .NET 10.0 | 100   |     569.22 ns |     6.988 ns |     6.194 ns |  0.95 |    0.01 |       - |         - |          NA |
|                                                           |           |           |       |               |              |              |       |         |         |           |             |
| FindMatchesUsingGetOrAddCacheHit                          | .NET 9.0  | .NET 9.0  | 100   |     658.90 ns |     3.995 ns |     3.737 ns |  1.00 |    0.01 |       - |         - |          NA |
| FindMatchesUsingGetOrAddCacheMiss                         | .NET 9.0  | .NET 9.0  | 100   |   2,682.37 ns |    16.338 ns |    15.283 ns |  4.07 |    0.03 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | .NET 9.0  | .NET 9.0  | 100   |     592.42 ns |     5.023 ns |     4.699 ns |  0.90 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | .NET 9.0  | .NET 9.0  | 100   |     582.73 ns |     3.094 ns |     2.584 ns |  0.88 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | .NET 9.0  | .NET 9.0  | 100   |   2,670.45 ns |    21.242 ns |    19.870 ns |  4.05 |    0.04 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | .NET 9.0  | .NET 9.0  | 100   |     578.91 ns |     6.160 ns |     5.762 ns |  0.88 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | .NET 9.0  | .NET 9.0  | 100   |     610.01 ns |     5.553 ns |     5.194 ns |  0.93 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | .NET 9.0  | .NET 9.0  | 100   |   2,664.67 ns |    23.951 ns |    22.404 ns |  4.04 |    0.04 |  0.1869 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | .NET 9.0  | .NET 9.0  | 100   |     589.62 ns |    11.738 ns |    12.054 ns |  0.89 |    0.02 |       - |         - |          NA |
|                                                           |           |           |       |               |              |              |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **.NET 10.0** | **.NET 10.0** | **10000** | **272,167.85 ns** | **5,107.312 ns** | **4,777.383 ns** |  **1.00** |    **0.02** | **18.5547** |  **310400 B** |        **1.00** |
| FindMatchesUsingGetOrAddCacheMiss                         | .NET 10.0 | .NET 10.0 | 10000 | 490,151.90 ns | 3,651.764 ns | 3,415.862 ns |  1.80 |    0.03 | 19.0430 |  319968 B |        1.03 |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | .NET 10.0 | .NET 10.0 | 10000 | 276,883.64 ns | 3,316.511 ns | 3,102.267 ns |  1.02 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | .NET 10.0 | .NET 10.0 | 10000 | 262,359.30 ns | 3,825.795 ns | 3,194.712 ns |  0.96 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | .NET 10.0 | .NET 10.0 | 10000 | 494,479.28 ns | 6,498.667 ns | 6,078.857 ns |  1.82 |    0.04 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | .NET 10.0 | .NET 10.0 | 10000 | 277,976.21 ns | 2,352.771 ns | 2,085.670 ns |  1.02 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | .NET 10.0 | .NET 10.0 | 10000 | 264,716.90 ns | 2,532.897 ns | 2,369.273 ns |  0.97 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | .NET 10.0 | .NET 10.0 | 10000 | 497,050.04 ns | 6,328.429 ns | 5,919.617 ns |  1.83 |    0.04 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | .NET 10.0 | .NET 10.0 | 10000 | 278,484.73 ns | 3,649.055 ns | 3,047.126 ns |  1.02 |    0.02 | 18.5547 |  310400 B |        1.00 |
|                                                           |           |           |       |               |              |              |       |         |         |           |             |
| FindMatchesUsingGetOrAddCacheHit                          | .NET 9.0  | .NET 9.0  | 10000 | 270,045.75 ns | 3,520.918 ns | 3,293.469 ns |  1.00 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingGetOrAddCacheMiss                         | .NET 9.0  | .NET 9.0  | 10000 | 491,559.41 ns | 5,647.601 ns | 5,282.770 ns |  1.82 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | .NET 9.0  | .NET 9.0  | 10000 | 277,214.36 ns | 3,398.641 ns | 2,838.019 ns |  1.03 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | .NET 9.0  | .NET 9.0  | 10000 | 268,559.13 ns | 2,596.004 ns | 2,167.781 ns |  0.99 |    0.01 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | .NET 9.0  | .NET 9.0  | 10000 | 494,734.88 ns | 4,960.280 ns | 4,639.849 ns |  1.83 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | .NET 9.0  | .NET 9.0  | 10000 | 275,592.99 ns | 4,527.742 ns | 4,235.253 ns |  1.02 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | .NET 9.0  | .NET 9.0  | 10000 | 262,220.06 ns | 3,111.280 ns | 2,910.293 ns |  0.97 |    0.02 | 18.5547 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | .NET 9.0  | .NET 9.0  | 10000 | 493,511.30 ns | 4,639.263 ns | 4,339.569 ns |  1.83 |    0.03 | 18.5547 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | .NET 9.0  | .NET 9.0  | 10000 | 283,437.70 ns | 3,850.653 ns | 3,413.503 ns |  1.05 |    0.02 | 18.5547 |  310400 B |        1.00 |
