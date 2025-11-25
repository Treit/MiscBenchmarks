# Reading data with and without async and ConfigureAwait



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count   | Mean        | Error       | StdDev      | Median      | Ratio | RatioSD |
|---------------------------------- |-------- |------------:|------------:|------------:|------------:|------:|--------:|
| **ReadSynchronous**                   | **1000**    |    **103.7 μs** |     **2.00 μs** |     **2.39 μs** |    **104.4 μs** |  **1.00** |    **0.03** |
| ReadAsyncAwait                    | 1000    |    165.8 μs |     3.26 μs |     6.73 μs |    167.0 μs |  1.60 |    0.08 |
| ReadAsyncAwaitConfigureAwaitFalse | 1000    |    169.0 μs |     3.34 μs |     5.10 μs |    169.9 μs |  1.63 |    0.06 |
| ReadAsyncAwaitConfigureAwaitTrue  | 1000    |    174.0 μs |     3.33 μs |     3.27 μs |    174.8 μs |  1.68 |    0.05 |
|                                   |         |             |             |             |             |       |         |
| **ReadSynchronous**                   | **100000**  |  **3,395.4 μs** |    **18.85 μs** |    **15.74 μs** |  **3,397.5 μs** |  **1.00** |    **0.01** |
| ReadAsyncAwait                    | 100000  |  6,140.8 μs |   149.08 μs |   437.21 μs |  6,204.0 μs |  1.81 |    0.13 |
| ReadAsyncAwaitConfigureAwaitFalse | 100000  |  6,327.6 μs |   180.99 μs |   519.30 μs |  6,563.0 μs |  1.86 |    0.15 |
| ReadAsyncAwaitConfigureAwaitTrue  | 100000  |  5,746.2 μs |   121.51 μs |   358.28 μs |  5,687.5 μs |  1.69 |    0.11 |
|                                   |         |             |             |             |             |       |         |
| **ReadSynchronous**                   | **1000000** | **37,353.0 μs** |   **437.18 μs** |   **408.94 μs** | **37,312.5 μs** |  **1.00** |    **0.01** |
| ReadAsyncAwait                    | 1000000 | 65,190.6 μs | 1,660.08 μs | 4,894.80 μs | 66,115.1 μs |  1.75 |    0.13 |
| ReadAsyncAwaitConfigureAwaitFalse | 1000000 | 66,031.7 μs | 1,602.07 μs | 4,698.60 μs | 67,497.6 μs |  1.77 |    0.13 |
| ReadAsyncAwaitConfigureAwaitTrue  | 1000000 | 62,664.1 μs | 1,996.19 μs | 5,791.30 μs | 61,487.3 μs |  1.68 |    0.16 |
