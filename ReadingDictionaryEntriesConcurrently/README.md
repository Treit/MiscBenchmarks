# Concurrently reading dictionary entries


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                   Method |  Count |          Mean |       Error |      StdDev |
|----------------------------------------- |------- |--------------:|------------:|------------:|
| **ConcurrentReadsUsingReaderWriterLockSlim** |     **10** |      **2.743 μs** |   **0.0518 μs** |   **0.0532 μs** |
|                 ConcurrentReadsUsingLock |     10 |      2.429 μs |   0.0475 μs |   0.0682 μs |
|     ConcurrentReadsUsingReaderWriterLock |     10 |      2.770 μs |   0.0545 μs |   0.0535 μs |
| ConcurrentReadsUsingConcurrentDictionary |     10 |      2.135 μs |   0.0426 μs |   0.0638 μs |
| **ConcurrentReadsUsingReaderWriterLockSlim** |   **1000** |     **89.925 μs** |   **0.2101 μs** |   **0.1966 μs** |
|                 ConcurrentReadsUsingLock |   1000 |    236.856 μs |   2.4796 μs |   2.3194 μs |
|     ConcurrentReadsUsingReaderWriterLock |   1000 |    258.129 μs |   1.2084 μs |   1.1304 μs |
| ConcurrentReadsUsingConcurrentDictionary |   1000 |     29.390 μs |   0.0959 μs |   0.0897 μs |
| **ConcurrentReadsUsingReaderWriterLockSlim** | **100000** |  **8,297.277 μs** |  **66.1207 μs** |  **61.8493 μs** |
|                 ConcurrentReadsUsingLock | 100000 | 14,759.137 μs | 142.1385 μs | 132.9564 μs |
|     ConcurrentReadsUsingReaderWriterLock | 100000 | 32,603.225 μs | 506.6548 μs | 473.9253 μs |
| ConcurrentReadsUsingConcurrentDictionary | 100000 |  2,530.118 μs |   6.7317 μs |   5.9675 μs |
