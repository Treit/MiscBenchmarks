# Reading data with and without async and ConfigureAwait

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22581
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT


```
|                            Method |   Count |          Mean |        Error |        StdDev |        Median | Ratio | RatioSD |
|---------------------------------- |-------- |--------------:|-------------:|--------------:|--------------:|------:|--------:|
|                   **ReadSynchronous** |    **1000** |      **96.99 μs** |     **1.903 μs** |      **3.621 μs** |      **96.36 μs** |  **1.00** |    **0.00** |
|                    ReadAsyncAwait |    1000 |     218.57 μs |     4.322 μs |     10.102 μs |     216.15 μs |  2.29 |    0.14 |
| ReadAsyncAwaitConfigureAwaitFalse |    1000 |     214.39 μs |     3.889 μs |      5.701 μs |     213.20 μs |  2.20 |    0.09 |
|  ReadAsyncAwaitConfigureAwaitTrue |    1000 |     220.29 μs |     4.392 μs |      9.548 μs |     217.59 μs |  2.29 |    0.14 |
|                                   |         |               |              |               |               |       |         |
|                   **ReadSynchronous** |  **100000** |   **5,053.68 μs** |   **100.838 μs** |    **205.986 μs** |   **5,069.06 μs** |  **1.00** |    **0.00** |
|                    ReadAsyncAwait |  100000 |  12,748.13 μs |   234.320 μs |    489.112 μs |  12,718.47 μs |  2.53 |    0.14 |
| ReadAsyncAwaitConfigureAwaitFalse |  100000 |  12,715.86 μs |   254.193 μs |    489.743 μs |  12,608.75 μs |  2.52 |    0.13 |
|  ReadAsyncAwaitConfigureAwaitTrue |  100000 |  13,299.18 μs |   327.999 μs |    941.091 μs |  13,163.76 μs |  2.57 |    0.19 |
|                                   |         |               |              |               |               |       |         |
|                   **ReadSynchronous** | **1000000** |  **54,111.88 μs** | **1,055.648 μs** |  **1,674.370 μs** |  **54,118.50 μs** |  **1.00** |    **0.00** |
|                    ReadAsyncAwait | 1000000 | 144,866.93 μs | 3,763.897 μs | 10,859.704 μs | 140,532.45 μs |  2.75 |    0.24 |
| ReadAsyncAwaitConfigureAwaitFalse | 1000000 | 145,899.81 μs | 3,056.199 μs |  8,963.302 μs | 145,395.42 μs |  2.78 |    0.14 |
|  ReadAsyncAwaitConfigureAwaitTrue | 1000000 | 156,005.77 μs | 5,015.338 μs | 14,787.839 μs | 152,165.80 μs |  2.73 |    0.18 |
