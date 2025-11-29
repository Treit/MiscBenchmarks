# Concurrently reading dictionary entries







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Job       | Runtime   | Count  | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD |
|----------------------------------------------------- |---------- |---------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **.NET 10.0** | **.NET 10.0** | **10**     |      **44.78 μs** |      **0.869 μs** |      **1.034 μs** |      **44.49 μs** |  **1.20** |    **0.03** |
| ConcurrentReadsUsingLock                             | .NET 10.0 | .NET 10.0 | 10     |      42.51 μs |      0.652 μs |      0.578 μs |      42.38 μs |  1.14 |    0.02 |
| ConcurrentReadsUsingReaderWriterLock                 | .NET 10.0 | .NET 10.0 | 10     |      54.59 μs |      0.447 μs |      0.396 μs |      54.59 μs |  1.46 |    0.02 |
| ConcurrentReadsUsingConcurrentDictionary             | .NET 10.0 | .NET 10.0 | 10     |      38.16 μs |      0.485 μs |      0.430 μs |      38.19 μs |  1.02 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | .NET 10.0 | .NET 10.0 | 10     |      37.37 μs |      0.710 μs |      0.729 μs |      37.42 μs |  1.00 |    0.02 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | .NET 10.0 | .NET 10.0 | 10     |      37.39 μs |      0.439 μs |      0.411 μs |      37.38 μs |  1.00 |    0.02 |
|                                                      |           |           |        |               |               |               |               |       |         |
| ConcurrentReadsUsingReaderWriterLockSlim             | .NET 9.0  | .NET 9.0  | 10     |      43.65 μs |      0.845 μs |      0.973 μs |      43.88 μs |  1.16 |    0.03 |
| ConcurrentReadsUsingLock                             | .NET 9.0  | .NET 9.0  | 10     |      44.68 μs |      0.473 μs |      0.395 μs |      44.64 μs |  1.19 |    0.02 |
| ConcurrentReadsUsingReaderWriterLock                 | .NET 9.0  | .NET 9.0  | 10     |      50.61 μs |      0.856 μs |      0.800 μs |      50.84 μs |  1.34 |    0.03 |
| ConcurrentReadsUsingConcurrentDictionary             | .NET 9.0  | .NET 9.0  | 10     |      37.57 μs |      0.346 μs |      0.324 μs |      37.59 μs |  1.00 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | .NET 9.0  | .NET 9.0  | 10     |      37.15 μs |      0.714 μs |      0.822 μs |      37.07 μs |  0.99 |    0.03 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | .NET 9.0  | .NET 9.0  | 10     |      37.68 μs |      0.681 μs |      0.637 μs |      37.53 μs |  1.00 |    0.02 |
|                                                      |           |           |        |               |               |               |               |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **.NET 10.0** | **.NET 10.0** | **1000**   |   **2,755.33 μs** |     **23.938 μs** |     **23.510 μs** |   **2,748.51 μs** |  **3.74** |    **0.07** |
| ConcurrentReadsUsingLock                             | .NET 10.0 | .NET 10.0 | 1000   |   4,368.95 μs |     66.705 μs |     62.396 μs |   4,354.10 μs |  5.93 |    0.13 |
| ConcurrentReadsUsingReaderWriterLock                 | .NET 10.0 | .NET 10.0 | 1000   |   8,617.97 μs |    168.797 μs |    187.617 μs |   8,585.29 μs | 11.69 |    0.31 |
| ConcurrentReadsUsingConcurrentDictionary             | .NET 10.0 | .NET 10.0 | 1000   |     742.88 μs |     12.775 μs |     11.950 μs |     740.12 μs |  1.01 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | .NET 10.0 | .NET 10.0 | 1000   |     771.29 μs |     14.898 μs |     15.299 μs |     767.82 μs |  1.05 |    0.03 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | .NET 10.0 | .NET 10.0 | 1000   |     737.09 μs |     13.038 μs |     12.196 μs |     737.78 μs |  1.00 |    0.02 |
|                                                      |           |           |        |               |               |               |               |       |         |
| ConcurrentReadsUsingReaderWriterLockSlim             | .NET 9.0  | .NET 9.0  | 1000   |   2,728.44 μs |     50.005 μs |     41.756 μs |   2,717.56 μs |  3.56 |    0.06 |
| ConcurrentReadsUsingLock                             | .NET 9.0  | .NET 9.0  | 1000   |   4,431.41 μs |     88.007 μs |     82.322 μs |   4,398.69 μs |  5.78 |    0.12 |
| ConcurrentReadsUsingReaderWriterLock                 | .NET 9.0  | .NET 9.0  | 1000   |   7,966.44 μs |     52.313 μs |     43.684 μs |   7,984.02 μs | 10.39 |    0.12 |
| ConcurrentReadsUsingConcurrentDictionary             | .NET 9.0  | .NET 9.0  | 1000   |     801.36 μs |     10.901 μs |      9.664 μs |     802.94 μs |  1.04 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | .NET 9.0  | .NET 9.0  | 1000   |     758.37 μs |     11.366 μs |     10.632 μs |     759.06 μs |  0.99 |    0.02 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | .NET 9.0  | .NET 9.0  | 1000   |     767.13 μs |      9.380 μs |      8.315 μs |     764.03 μs |  1.00 |    0.01 |
|                                                      |           |           |        |               |               |               |               |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **.NET 10.0** | **.NET 10.0** | **100000** | **349,717.97 μs** |  **6,031.864 μs** |  **5,924.097 μs** | **348,762.95 μs** |  **4.72** |    **0.12** |
| ConcurrentReadsUsingLock                             | .NET 10.0 | .NET 10.0 | 100000 | 512,839.80 μs |  3,224.646 μs |  3,167.034 μs | 512,877.95 μs |  6.92 |    0.15 |
| ConcurrentReadsUsingReaderWriterLock                 | .NET 10.0 | .NET 10.0 | 100000 | 872,446.23 μs | 24,493.478 μs | 72,219.577 μs | 899,767.85 μs | 11.77 |    1.00 |
| ConcurrentReadsUsingConcurrentDictionary             | .NET 10.0 | .NET 10.0 | 100000 |  70,808.67 μs |  1,406.564 μs |  2,463.483 μs |  70,585.86 μs |  0.96 |    0.04 |
| ConcurrentReadsUsingFrozentDictionary                | .NET 10.0 | .NET 10.0 | 100000 |  77,876.67 μs |  1,552.836 μs |  3,241.348 μs |  77,353.82 μs |  1.05 |    0.05 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | .NET 10.0 | .NET 10.0 | 100000 |  74,140.87 μs |  1,469.187 μs |  1,572.014 μs |  74,162.97 μs |  1.00 |    0.03 |
|                                                      |           |           |        |               |               |               |               |       |         |
| ConcurrentReadsUsingReaderWriterLockSlim             | .NET 9.0  | .NET 9.0  | 100000 | 357,416.50 μs |  7,016.208 μs |  8,616.534 μs | 353,908.60 μs |  5.03 |    0.19 |
| ConcurrentReadsUsingLock                             | .NET 9.0  | .NET 9.0  | 100000 | 552,011.17 μs |  2,651.077 μs |  2,350.110 μs | 551,707.75 μs |  7.78 |    0.22 |
| ConcurrentReadsUsingReaderWriterLock                 | .NET 9.0  | .NET 9.0  | 100000 | 878,087.72 μs | 23,282.663 μs | 68,284.026 μs | 899,674.10 μs | 12.37 |    1.02 |
| ConcurrentReadsUsingConcurrentDictionary             | .NET 9.0  | .NET 9.0  | 100000 |  75,089.57 μs |  1,418.399 μs |  3,113.421 μs |  74,801.19 μs |  1.06 |    0.05 |
| ConcurrentReadsUsingFrozentDictionary                | .NET 9.0  | .NET 9.0  | 100000 |  82,512.57 μs |  1,641.194 μs |  3,963.668 μs |  83,065.91 μs |  1.16 |    0.06 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | .NET 9.0  | .NET 9.0  | 100000 |  71,053.30 μs |  1,377.337 μs |  2,061.533 μs |  71,150.32 μs |  1.00 |    0.04 |
