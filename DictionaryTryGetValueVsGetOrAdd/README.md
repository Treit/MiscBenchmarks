# ConcurrentDictionary using GetOrAdd vs. using TryGetvalue first.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27774.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                    | Count | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------ |--------------:|--------------:|--------------:|--------------:|------:|--------:|--------:|----------:|------------:|
| **FindMatchesUsingGetOrAddCacheHit**                          | **10**    |     **127.66 ns** |      **1.902 ns** |      **1.588 ns** |     **127.08 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | 10    |     258.16 ns |      2.351 ns |      2.199 ns |     258.00 ns |  2.02 |    0.03 |  0.0668 |     288 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 10    |     129.86 ns |      2.342 ns |      3.577 ns |     128.99 ns |  1.03 |    0.04 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 10    |      94.88 ns |      0.957 ns |      0.848 ns |      94.66 ns |  0.74 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 10    |     248.90 ns |      2.049 ns |      1.711 ns |     248.56 ns |  1.95 |    0.03 |  0.0668 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 10    |      91.62 ns |      1.476 ns |      1.233 ns |      91.12 ns |  0.72 |    0.01 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 10    |      95.41 ns |      1.672 ns |      1.482 ns |      95.10 ns |  0.75 |    0.02 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 10    |     228.75 ns |      1.774 ns |      1.572 ns |     228.28 ns |  1.79 |    0.02 |  0.0668 |     288 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 10    |      91.44 ns |      1.747 ns |      1.716 ns |      91.70 ns |  0.72 |    0.02 |       - |         - |          NA |
|                                                           |       |               |               |               |               |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **100**   |   **1,544.56 ns** |     **29.624 ns** |     **34.115 ns** |   **1,537.47 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| FindMatchesUsingGetOrAddCacheMiss                         | 100   |   3,094.47 ns |     61.202 ns |     95.284 ns |   3,068.49 ns |  2.01 |    0.08 |  0.7324 |    3168 B |          NA |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 100   |   1,515.54 ns |     29.850 ns |     45.584 ns |   1,504.35 ns |  0.99 |    0.03 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 100   |   1,173.07 ns |     22.363 ns |     18.674 ns |   1,168.08 ns |  0.76 |    0.02 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 100   |   2,695.77 ns |     28.953 ns |     27.082 ns |   2,690.91 ns |  1.74 |    0.05 |  0.7324 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 100   |   1,151.96 ns |     14.188 ns |     11.077 ns |   1,150.77 ns |  0.75 |    0.02 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 100   |   1,164.20 ns |     22.501 ns |     30.800 ns |   1,156.08 ns |  0.76 |    0.03 |       - |         - |          NA |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 100   |   2,744.97 ns |     26.873 ns |     23.822 ns |   2,742.27 ns |  1.78 |    0.03 |  0.7324 |    3168 B |          NA |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 100   |   1,139.14 ns |     12.284 ns |     10.258 ns |   1,137.12 ns |  0.74 |    0.02 |       - |         - |          NA |
|                                                           |       |               |               |               |               |       |         |         |           |             |
| **FindMatchesUsingGetOrAddCacheHit**                          | **10000** | **384,359.25 ns** |  **6,800.940 ns** |  **5,679.093 ns** | **382,392.19 ns** |  **1.00** |    **0.00** | **71.2891** |  **310400 B** |        **1.00** |
| FindMatchesUsingGetOrAddCacheMiss                         | 10000 | 624,853.42 ns | 14,112.354 ns | 40,034.399 ns | 619,755.22 ns |  1.74 |    0.12 | 73.2422 |  319968 B |        1.03 |
| FindMatchesUsingGetOrAddCacheMixOfHitsAndMisses           | 10000 | 441,500.12 ns |  8,758.985 ns | 23,530.444 ns | 440,118.58 ns |  1.12 |    0.06 | 71.7773 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheHit           | 10000 | 335,258.79 ns |  6,687.990 ns | 15,231.937 ns | 331,375.61 ns |  0.89 |    0.04 | 71.7773 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenGetOrAddCacheMiss          | 10000 | 567,471.29 ns | 10,906.323 ns | 14,928.698 ns | 567,564.70 ns |  1.46 |    0.04 | 73.2422 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenGetOrAddMixOfHitsAndMisses | 10000 | 404,647.57 ns |  7,891.936 ns | 20,651.821 ns | 397,573.07 ns |  1.09 |    0.07 | 71.7773 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheHit             | 10000 | 342,898.16 ns |  6,693.587 ns |  6,573.997 ns | 340,566.11 ns |  0.89 |    0.02 | 71.2891 |  310400 B |        1.00 |
| FindMatchesUsingTryGetValueThenTryAddCacheMiss            | 10000 | 556,262.47 ns | 10,371.327 ns | 15,202.156 ns | 550,089.16 ns |  1.44 |    0.05 | 73.2422 |  319968 B |        1.03 |
| FindMatchesUsingTryGetValueThenTryAddMixOfHitsAndMisses   | 10000 | 406,080.08 ns | 10,144.226 ns | 28,109.604 ns | 397,530.86 ns |  1.07 |    0.08 | 71.7773 |  310400 B |        1.00 |
