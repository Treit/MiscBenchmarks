# Concurrently reading dictionary entries

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25217
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT


```
|                                   Method |  Count |          Mean |         Error |        StdDev |        Median |
|----------------------------------------- |------- |--------------:|--------------:|--------------:|--------------:|
| **ConcurrentReadsUsingReaderWriterLockSlim** |     **10** |      **8.332 μs** |     **0.1641 μs** |     **0.4760 μs** |      **8.237 μs** |
|                 ConcurrentReadsUsingLock |     10 |      6.382 μs |     0.6919 μs |     2.0401 μs |      7.461 μs |
|     ConcurrentReadsUsingReaderWriterLock |     10 |      4.913 μs |     0.0969 μs |     0.1722 μs |      4.898 μs |
| ConcurrentReadsUsingConcurrentDictionary |     10 |      3.660 μs |     0.0487 μs |     0.0455 μs |      3.656 μs |
| **ConcurrentReadsUsingReaderWriterLockSlim** |   **1000** |    **135.940 μs** |     **7.2218 μs** |    **21.1804 μs** |    **133.539 μs** |
|                 ConcurrentReadsUsingLock |   1000 |    179.213 μs |     3.5496 μs |     3.6452 μs |    178.426 μs |
|     ConcurrentReadsUsingReaderWriterLock |   1000 |    214.695 μs |     1.6890 μs |     1.5799 μs |    214.684 μs |
| ConcurrentReadsUsingConcurrentDictionary |   1000 |     46.269 μs |     0.6971 μs |     0.6520 μs |     46.317 μs |
| **ConcurrentReadsUsingReaderWriterLockSlim** | **100000** | **34,770.322 μs** | **1,934.3207 μs** | **5,580.9574 μs** | **34,976.200 μs** |
|                 ConcurrentReadsUsingLock | 100000 | 15,410.466 μs |   235.1892 μs |   219.9961 μs | 15,468.467 μs |
|     ConcurrentReadsUsingReaderWriterLock | 100000 | 20,630.151 μs |   251.5029 μs |   235.2560 μs | 20,666.072 μs |
| ConcurrentReadsUsingConcurrentDictionary | 100000 |  3,777.589 μs |    70.7857 μs |    66.2130 μs |  3,748.720 μs |
