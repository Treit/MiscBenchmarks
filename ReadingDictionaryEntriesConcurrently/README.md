# Concurrently reading dictionary entries



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27718.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                               | Count  | Mean          | Error        | StdDev       | Ratio | RatioSD |
|----------------------------------------------------- |------- |--------------:|-------------:|-------------:|------:|--------:|
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **10**     |      **40.60 μs** |     **0.807 μs** |     **1.789 μs** |  **1.59** |    **0.06** |
| ConcurrentReadsUsingLock                             | 10     |      38.39 μs |     0.757 μs |     1.529 μs |  1.51 |    0.08 |
| ConcurrentReadsUsingReaderWriterLock                 | 10     |      48.05 μs |     0.519 μs |     0.485 μs |  1.88 |    0.07 |
| ConcurrentReadsUsingConcurrentDictionary             | 10     |      27.60 μs |     0.544 μs |     0.780 μs |  1.09 |    0.05 |
| ConcurrentReadsUsingFrozentDictionary                | 10     |      26.35 μs |     0.464 μs |     0.434 μs |  1.03 |    0.03 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 10     |      25.41 μs |     0.507 μs |     0.695 μs |  1.00 |    0.00 |
|                                                      |        |               |              |              |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **1000**   |   **1,163.80 μs** |     **7.305 μs** |     **6.833 μs** |  **2.34** |    **0.03** |
| ConcurrentReadsUsingLock                             | 1000   |   2,315.34 μs |    45.950 μs |    90.700 μs |  4.71 |    0.14 |
| ConcurrentReadsUsingReaderWriterLock                 | 1000   |   3,258.65 μs |    19.026 μs |    17.797 μs |  6.54 |    0.08 |
| ConcurrentReadsUsingConcurrentDictionary             | 1000   |     493.50 μs |     6.546 μs |     5.803 μs |  0.99 |    0.02 |
| ConcurrentReadsUsingFrozentDictionary                | 1000   |     521.32 μs |    10.396 μs |     9.725 μs |  1.05 |    0.02 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 1000   |     497.95 μs |     5.392 μs |     5.043 μs |  1.00 |    0.00 |
|                                                      |        |               |              |              |       |         |
| **ConcurrentReadsUsingReaderWriterLockSlim**             | **100000** | **121,226.44 μs** | **1,694.367 μs** | **1,584.912 μs** |  **2.64** |    **0.14** |
| ConcurrentReadsUsingLock                             | 100000 | 259,354.32 μs | 3,393.048 μs | 3,173.859 μs |  5.64 |    0.24 |
| ConcurrentReadsUsingReaderWriterLock                 | 100000 | 314,215.21 μs | 4,799.712 μs | 4,489.653 μs |  6.83 |    0.34 |
| ConcurrentReadsUsingConcurrentDictionary             | 100000 |  44,264.87 μs |   771.654 μs | 1,558.779 μs |  0.98 |    0.03 |
| ConcurrentReadsUsingFrozentDictionary                | 100000 |  46,935.69 μs |   821.015 μs | 1,562.066 μs |  1.04 |    0.04 |
| ConcurrentReadsUsingDictionaryNoLockingNotThreadSafe | 100000 |  45,036.01 μs |   823.612 μs | 1,644.842 μs |  1.00 |    0.00 |
