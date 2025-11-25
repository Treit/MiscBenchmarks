# Concurrently reading dictionary entries





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Count  | Mean          | Error        | StdDev       | Ratio | RatioSD |
|----------------------------------------------------- |------- |--------------:|-------------:|-------------:|------:|--------:|
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **10**     |      **44.48 μs** |     **0.880 μs** |     **1.113 μs** |  **1.19** |    **0.04** |
| ConcurrentReadsUsingLock                             | 10     |      60.35 μs |     0.949 μs |     0.793 μs |  1.62 |    0.04 |
| ConcurrentReadsUsingReaderWriterLock                 | 10     |      86.10 μs |     0.647 μs |     0.573 μs |  2.31 |    0.05 |
| ConcurrentReadsUsingConcurrentDictionary             | 10     |      36.76 μs |     0.656 μs |     0.548 μs |  0.98 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | 10     |      37.87 μs |     0.684 μs |     0.640 μs |  1.01 |    0.03 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 10     |      37.34 μs |     0.697 μs |     0.716 μs |  1.00 |    0.03 |
|                                                      |        |               |              |              |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **1000**   |   **2,695.04 μs** |    **21.760 μs** |    **18.171 μs** |  **3.73** |    **0.03** |
| ConcurrentReadsUsingLock                             | 1000   |   4,071.33 μs |    33.659 μs |    28.107 μs |  5.64 |    0.05 |
| ConcurrentReadsUsingReaderWriterLock                 | 1000   |   9,551.17 μs |    62.362 μs |    58.334 μs | 13.24 |    0.12 |
| ConcurrentReadsUsingConcurrentDictionary             | 1000   |     735.87 μs |     3.599 μs |     3.366 μs |  1.02 |    0.01 |
| ConcurrentReadsUsingFrozentDictionary                | 1000   |     734.28 μs |     1.802 μs |     1.685 μs |  1.02 |    0.01 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 1000   |     721.68 μs |     5.381 μs |     5.033 μs |  1.00 |    0.01 |
|                                                      |        |               |              |              |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **100000** | **357,421.81 μs** | **2,823.751 μs** | **2,773.301 μs** |  **5.26** |    **0.05** |
| ConcurrentReadsUsingLock                             | 100000 | 459,245.16 μs | 3,591.245 μs | 3,183.545 μs |  6.76 |    0.06 |
| ConcurrentReadsUsingReaderWriterLock                 | 100000 | 908,980.76 μs | 9,480.268 μs | 7,916.453 μs | 13.38 |    0.13 |
| ConcurrentReadsUsingConcurrentDictionary             | 100000 |  70,813.42 μs | 1,378.157 μs | 1,587.088 μs |  1.04 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | 100000 |  81,422.28 μs | 1,609.482 μs | 3,062.206 μs |  1.20 |    0.05 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 100000 |  67,946.66 μs |   481.141 μs |   375.643 μs |  1.00 |    0.01 |
