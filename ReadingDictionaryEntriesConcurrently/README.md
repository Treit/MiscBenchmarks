# Concurrently reading dictionary entries






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Count  | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD |
|----------------------------------------------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **10**     |      **47.13 μs** |      **0.920 μs** |      **1.163 μs** |      **47.11 μs** |  **1.22** |    **0.03** |
| ConcurrentReadsUsingLock                             | 10     |      47.10 μs |      0.398 μs |      0.353 μs |      47.10 μs |  1.22 |    0.01 |
| ConcurrentReadsUsingReaderWriterLock                 | 10     |      51.64 μs |      0.997 μs |      1.066 μs |      51.29 μs |  1.33 |    0.03 |
| ConcurrentReadsUsingConcurrentDictionary             | 10     |      39.95 μs |      0.701 μs |      0.621 μs |      40.02 μs |  1.03 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | 10     |      37.99 μs |      0.673 μs |      0.596 μs |      37.91 μs |  0.98 |    0.02 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 10     |      38.76 μs |      0.410 μs |      0.383 μs |      38.75 μs |  1.00 |    0.01 |
|                                                      |        |               |               |               |               |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **1000**   |   **2,789.06 μs** |     **43.829 μs** |     **36.600 μs** |   **2,775.22 μs** |  **3.55** |    **0.07** |
| ConcurrentReadsUsingLock                             | 1000   |   4,743.21 μs |     39.663 μs |     33.121 μs |   4,753.52 μs |  6.04 |    0.10 |
| ConcurrentReadsUsingReaderWriterLock                 | 1000   |   9,062.70 μs |    180.308 μs |    258.592 μs |   9,100.26 μs | 11.54 |    0.37 |
| ConcurrentReadsUsingConcurrentDictionary             | 1000   |     875.98 μs |      7.013 μs |      5.856 μs |     875.12 μs |  1.12 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | 1000   |     778.05 μs |     12.980 μs |     12.142 μs |     774.11 μs |  0.99 |    0.02 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 1000   |     785.43 μs |     13.495 μs |     12.623 μs |     781.68 μs |  1.00 |    0.02 |
|                                                      |        |               |               |               |               |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **100000** | **379,646.43 μs** | **11,419.821 μs** | **33,130.974 μs** | **370,486.90 μs** |  **5.02** |    **0.49** |
| ConcurrentReadsUsingLock                             | 100000 | 479,750.31 μs |  9,381.835 μs |  8,775.774 μs | 481,052.50 μs |  6.34 |    0.30 |
| ConcurrentReadsUsingReaderWriterLock                 | 100000 | 833,531.06 μs | 27,831.947 μs | 82,063.129 μs | 860,725.55 μs | 11.02 |    1.18 |
| ConcurrentReadsUsingConcurrentDictionary             | 100000 |  75,994.72 μs |  1,515.154 μs |  3,659.268 μs |  75,513.50 μs |  1.01 |    0.07 |
| ConcurrentReadsUsingFrozentDictionary                | 100000 |  91,739.93 μs |  2,091.557 μs |  6,167.004 μs |  91,512.88 μs |  1.21 |    0.10 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 100000 |  75,755.95 μs |  1,498.873 μs |  3,352.444 μs |  75,894.84 μs |  1.00 |    0.06 |
