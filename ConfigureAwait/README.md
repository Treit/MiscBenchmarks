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
| **ReadSynchronous**                   | **1000**    |    **105.4 μs** |     **0.58 μs** |     **0.51 μs** |    **105.4 μs** |  **1.00** |    **0.01** |
| ReadAsyncAwait                    | 1000    |    175.4 μs |     3.41 μs |     3.19 μs |    176.0 μs |  1.66 |    0.03 |
| ReadAsyncAwaitConfigureAwaitFalse | 1000    |    163.9 μs |     3.26 μs |     7.29 μs |    163.8 μs |  1.55 |    0.07 |
| ReadAsyncAwaitConfigureAwaitTrue  | 1000    |    161.1 μs |     3.31 μs |     9.70 μs |    158.2 μs |  1.53 |    0.09 |
|                                   |         |             |             |             |             |       |         |
| **ReadSynchronous**                   | **100000**  |  **3,425.8 μs** |    **64.16 μs** |    **68.65 μs** |  **3,408.7 μs** |  **1.00** |    **0.03** |
| ReadAsyncAwait                    | 100000  |  6,416.9 μs |   123.89 μs |   132.56 μs |  6,455.9 μs |  1.87 |    0.05 |
| ReadAsyncAwaitConfigureAwaitFalse | 100000  |  5,834.4 μs |   184.73 μs |   530.02 μs |  5,676.0 μs |  1.70 |    0.16 |
| ReadAsyncAwaitConfigureAwaitTrue  | 100000  |  5,908.3 μs |   172.45 μs |   500.30 μs |  5,827.4 μs |  1.73 |    0.15 |
|                                   |         |             |             |             |             |       |         |
| **ReadSynchronous**                   | **1000000** | **37,409.8 μs** |   **487.60 μs** |   **456.10 μs** | **37,285.5 μs** |  **1.00** |    **0.02** |
| ReadAsyncAwait                    | 1000000 | 70,250.1 μs | 1,400.19 μs | 2,261.04 μs | 70,449.2 μs |  1.88 |    0.06 |
| ReadAsyncAwaitConfigureAwaitFalse | 1000000 | 69,757.0 μs | 1,393.15 μs | 3,766.46 μs | 71,105.2 μs |  1.86 |    0.10 |
| ReadAsyncAwaitConfigureAwaitTrue  | 1000000 | 70,657.9 μs | 1,871.43 μs | 5,517.95 μs | 71,796.3 μs |  1.89 |    0.15 |
