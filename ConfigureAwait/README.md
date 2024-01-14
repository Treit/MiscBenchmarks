# Reading data with and without async and ConfigureAwait


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                            Method |   Count |         Mean |        Error |       StdDev |       Median | Ratio | RatioSD |
|---------------------------------- |-------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|
|                   **ReadSynchronous** |    **1000** |     **78.42 μs** |     **1.371 μs** |     **2.473 μs** |     **77.36 μs** |  **1.00** |    **0.00** |
|                    ReadAsyncAwait |    1000 |    192.71 μs |     0.893 μs |     0.745 μs |    192.67 μs |  2.43 |    0.09 |
| ReadAsyncAwaitConfigureAwaitFalse |    1000 |    171.95 μs |     1.124 μs |     0.997 μs |    172.03 μs |  2.17 |    0.08 |
|  ReadAsyncAwaitConfigureAwaitTrue |    1000 |    170.50 μs |     1.627 μs |     1.443 μs |    170.62 μs |  2.16 |    0.08 |
|                                   |         |              |              |              |              |       |         |
|                   **ReadSynchronous** |  **100000** |  **3,306.46 μs** |    **10.080 μs** |     **8.417 μs** |  **3,305.83 μs** |  **1.00** |    **0.00** |
|                    ReadAsyncAwait |  100000 |  6,983.69 μs |    44.616 μs |    39.551 μs |  6,981.72 μs |  2.11 |    0.01 |
| ReadAsyncAwaitConfigureAwaitFalse |  100000 |  7,186.28 μs |    49.717 μs |    44.073 μs |  7,174.67 μs |  2.18 |    0.01 |
|  ReadAsyncAwaitConfigureAwaitTrue |  100000 |  7,142.42 μs |    57.433 μs |    53.723 μs |  7,136.51 μs |  2.16 |    0.01 |
|                                   |         |              |              |              |              |       |         |
|                   **ReadSynchronous** | **1000000** | **36,069.10 μs** |   **596.666 μs** |   **586.006 μs** | **35,825.75 μs** |  **1.00** |    **0.00** |
|                    ReadAsyncAwait | 1000000 | 75,795.52 μs | 1,154.057 μs | 1,079.506 μs | 75,908.07 μs |  2.10 |    0.04 |
| ReadAsyncAwaitConfigureAwaitFalse | 1000000 | 75,432.71 μs |   655.831 μs |   613.465 μs | 75,220.60 μs |  2.09 |    0.04 |
|  ReadAsyncAwaitConfigureAwaitTrue | 1000000 | 89,789.25 μs | 1,794.256 μs | 1,762.200 μs | 89,228.43 μs |  2.49 |    0.05 |
