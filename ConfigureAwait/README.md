# Reading data with and without async and ConfigureAwait





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count   | Mean         | Error        | StdDev       | Ratio | RatioSD |
|---------------------------------- |---------- |---------- |-------- |-------------:|-------------:|-------------:|------:|--------:|
| **ReadSynchronous**                   | **.NET 10.0** | **.NET 10.0** | **1000**    |     **98.09 μs** |     **1.141 μs** |     **1.067 μs** |  **1.00** |    **0.01** |
| ReadAsyncAwait                    | .NET 10.0 | .NET 10.0 | 1000    |    174.80 μs |     2.596 μs |     2.168 μs |  1.78 |    0.03 |
| ReadAsyncAwaitConfigureAwaitFalse | .NET 10.0 | .NET 10.0 | 1000    |    173.14 μs |     1.946 μs |     1.625 μs |  1.77 |    0.02 |
| ReadAsyncAwaitConfigureAwaitTrue  | .NET 10.0 | .NET 10.0 | 1000    |    174.22 μs |     3.330 μs |     3.270 μs |  1.78 |    0.04 |
|                                   |           |           |         |              |              |              |       |         |
| ReadSynchronous                   | .NET 9.0  | .NET 9.0  | 1000    |     96.87 μs |     0.866 μs |     0.810 μs |  1.00 |    0.01 |
| ReadAsyncAwait                    | .NET 9.0  | .NET 9.0  | 1000    |    173.14 μs |     2.040 μs |     1.809 μs |  1.79 |    0.02 |
| ReadAsyncAwaitConfigureAwaitFalse | .NET 9.0  | .NET 9.0  | 1000    |    174.50 μs |     3.013 μs |     2.516 μs |  1.80 |    0.03 |
| ReadAsyncAwaitConfigureAwaitTrue  | .NET 9.0  | .NET 9.0  | 1000    |    174.60 μs |     1.731 μs |     1.446 μs |  1.80 |    0.02 |
|                                   |           |           |         |              |              |              |       |         |
| **ReadSynchronous**                   | **.NET 10.0** | **.NET 10.0** | **100000**  |  **3,147.29 μs** |    **18.176 μs** |    **17.002 μs** |  **1.00** |    **0.01** |
| ReadAsyncAwait                    | .NET 10.0 | .NET 10.0 | 100000  |  6,395.20 μs |   119.170 μs |    93.040 μs |  2.03 |    0.03 |
| ReadAsyncAwaitConfigureAwaitFalse | .NET 10.0 | .NET 10.0 | 100000  |  6,297.06 μs |    78.622 μs |    65.653 μs |  2.00 |    0.02 |
| ReadAsyncAwaitConfigureAwaitTrue  | .NET 10.0 | .NET 10.0 | 100000  |  6,312.63 μs |    75.664 μs |    84.100 μs |  2.01 |    0.03 |
|                                   |           |           |         |              |              |              |       |         |
| ReadSynchronous                   | .NET 9.0  | .NET 9.0  | 100000  |  3,117.98 μs |    23.245 μs |    19.411 μs |  1.00 |    0.01 |
| ReadAsyncAwait                    | .NET 9.0  | .NET 9.0  | 100000  |  6,264.88 μs |    76.669 μs |    67.965 μs |  2.01 |    0.02 |
| ReadAsyncAwaitConfigureAwaitFalse | .NET 9.0  | .NET 9.0  | 100000  |  6,331.03 μs |    77.914 μs |    72.881 μs |  2.03 |    0.03 |
| ReadAsyncAwaitConfigureAwaitTrue  | .NET 9.0  | .NET 9.0  | 100000  |  6,329.40 μs |   121.310 μs |   101.299 μs |  2.03 |    0.03 |
|                                   |           |           |         |              |              |              |       |         |
| **ReadSynchronous**                   | **.NET 10.0** | **.NET 10.0** | **1000000** | **34,369.74 μs** |   **189.993 μs** |   **158.653 μs** |  **1.00** |    **0.01** |
| ReadAsyncAwait                    | .NET 10.0 | .NET 10.0 | 1000000 | 69,171.04 μs |   762.750 μs |   595.505 μs |  2.01 |    0.02 |
| ReadAsyncAwaitConfigureAwaitFalse | .NET 10.0 | .NET 10.0 | 1000000 | 68,919.79 μs | 1,308.346 μs | 1,159.815 μs |  2.01 |    0.03 |
| ReadAsyncAwaitConfigureAwaitTrue  | .NET 10.0 | .NET 10.0 | 1000000 | 68,791.41 μs |   661.673 μs |   618.929 μs |  2.00 |    0.02 |
|                                   |           |           |         |              |              |              |       |         |
| ReadSynchronous                   | .NET 9.0  | .NET 9.0  | 1000000 | 34,818.79 μs |   181.995 μs |   170.239 μs |  1.00 |    0.01 |
| ReadAsyncAwait                    | .NET 9.0  | .NET 9.0  | 1000000 | 68,518.83 μs |   612.760 μs |   543.196 μs |  1.97 |    0.02 |
| ReadAsyncAwaitConfigureAwaitFalse | .NET 9.0  | .NET 9.0  | 1000000 | 69,625.01 μs |   614.994 μs |   480.147 μs |  2.00 |    0.02 |
| ReadAsyncAwaitConfigureAwaitTrue  | .NET 9.0  | .NET 9.0  | 1000000 | 69,174.39 μs |   637.464 μs |   532.312 μs |  1.99 |    0.02 |
