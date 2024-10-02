# Concurrently reading dictionary entries




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27718.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                               | Count  | Mean          | Error        | StdDev        | Ratio | RatioSD |
|----------------------------------------------------- |------- |--------------:|-------------:|--------------:|------:|--------:|
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **10**     |      **44.35 μs** |     **0.881 μs** |      **1.264 μs** |  **1.65** |    **0.06** |
| ConcurrentReadsUsingLock                             | 10     |      48.24 μs |     0.942 μs |      1.650 μs |  1.80 |    0.07 |
| ConcurrentReadsUsingReaderWriterLock                 | 10     |      49.28 μs |     0.734 μs |      0.686 μs |  1.84 |    0.04 |
| ConcurrentReadsUsingConcurrentDictionary             | 10     |      26.94 μs |     0.526 μs |      0.720 μs |  1.00 |    0.03 |
| ConcurrentReadsUsingFrozentDictionary                | 10     |      27.16 μs |     0.543 μs |      1.108 μs |  1.00 |    0.04 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 10     |      26.85 μs |     0.442 μs |      0.414 μs |  1.00 |    0.00 |
|                                                      |        |               |              |               |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **1000**   |   **1,919.36 μs** |    **22.294 μs** |     **18.617 μs** |  **3.04** |    **0.02** |
| ConcurrentReadsUsingLock                             | 1000   |   1,776.87 μs |    17.852 μs |     16.699 μs |  2.82 |    0.02 |
| ConcurrentReadsUsingReaderWriterLock                 | 1000   |   3,169.92 μs |    58.916 μs |     55.110 μs |  4.99 |    0.06 |
| ConcurrentReadsUsingConcurrentDictionary             | 1000   |     673.27 μs |    13.318 μs |     20.339 μs |  1.06 |    0.04 |
| ConcurrentReadsUsingFrozentDictionary                | 1000   |     621.81 μs |    12.098 μs |     14.858 μs |  0.98 |    0.03 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 1000   |     631.43 μs |     5.584 μs |      4.360 μs |  1.00 |    0.00 |
|                                                      |        |               |              |               |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **100000** | **287,665.80 μs** | **5,633.352 μs** | **10,158.095 μs** |  **4.25** |    **0.21** |
| ConcurrentReadsUsingLock                             | 100000 | 267,918.78 μs | 5,232.016 μs |  5,372.896 μs |  3.97 |    0.12 |
| ConcurrentReadsUsingReaderWriterLock                 | 100000 | 290,472.77 μs | 3,424.462 μs |  3,035.697 μs |  4.35 |    0.17 |
| ConcurrentReadsUsingConcurrentDictionary             | 100000 |  68,491.06 μs | 1,367.776 μs |  3,902.343 μs |  1.02 |    0.07 |
| ConcurrentReadsUsingFrozentDictionary                | 100000 |  70,276.47 μs | 1,724.122 μs |  5,056.551 μs |  1.05 |    0.10 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 100000 |  67,574.98 μs | 1,333.862 μs |  2,228.583 μs |  1.00 |    0.00 |
