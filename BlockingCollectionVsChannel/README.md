# BlockingCollection vs Channels





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                       | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|--------------------------------------------- |---------- |---------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **GetTotalUsingBlockingCollectionSingleTask**    | **.NET 10.0** | **.NET 10.0** | **1000**  |  **1.152 ms** | **0.0086 ms** | **0.0076 ms** |  **1.154 ms** |  **1.00** |    **0.01** |  **1.9531** |       **-** |       **-** |  **33.51 KB** |        **1.00** |
| GetTotalUsingChannelSingleTask               | .NET 10.0 | .NET 10.0 | 1000  |  1.235 ms | 0.0068 ms | 0.0063 ms |  1.236 ms |  1.07 |    0.01 |  1.9531 |       - |       - |   33.8 KB |        1.01 |
| GetTotalUsingBlockingCollectionMultipleTasks | .NET 10.0 | .NET 10.0 | 1000  |  7.559 ms | 0.1000 ms | 0.0781 ms |  7.538 ms |  6.56 |    0.08 |       - |       - |       - |  34.48 KB |        1.03 |
| GetTotalUsingChannelMultipleTasks            | .NET 10.0 | .NET 10.0 | 1000  |  7.769 ms | 0.0846 ms | 0.0707 ms |  7.741 ms |  6.74 |    0.07 |       - |       - |       - |   29.3 KB |        0.87 |
|                                              |           |           |       |           |           |           |           |       |         |         |         |         |           |             |
| GetTotalUsingBlockingCollectionSingleTask    | .NET 9.0  | .NET 9.0  | 1000  |  1.131 ms | 0.0083 ms | 0.0078 ms |  1.133 ms |  1.00 |    0.01 |  1.9531 |       - |       - |  33.51 KB |        1.00 |
| GetTotalUsingChannelSingleTask               | .NET 9.0  | .NET 9.0  | 1000  |  1.201 ms | 0.0082 ms | 0.0076 ms |  1.204 ms |  1.06 |    0.01 |  1.9531 |       - |       - |   33.8 KB |        1.01 |
| GetTotalUsingBlockingCollectionMultipleTasks | .NET 9.0  | .NET 9.0  | 1000  |  7.405 ms | 0.0365 ms | 0.0304 ms |  7.401 ms |  6.55 |    0.05 |       - |       - |       - |  35.13 KB |        1.05 |
| GetTotalUsingChannelMultipleTasks            | .NET 9.0  | .NET 9.0  | 1000  |  7.964 ms | 0.0838 ms | 0.0655 ms |  7.961 ms |  7.04 |    0.07 |       - |       - |       - |  30.99 KB |        0.92 |
|                                              |           |           |       |           |           |           |           |       |         |         |         |         |           |             |
| **GetTotalUsingBlockingCollectionSingleTask**    | **.NET 10.0** | **.NET 10.0** | **10000** | **11.667 ms** | **0.0649 ms** | **0.0542 ms** | **11.695 ms** |  **1.00** |    **0.01** | **15.6250** | **15.6250** | **15.6250** | **258.41 KB** |        **1.00** |
| GetTotalUsingChannelSingleTask               | .NET 10.0 | .NET 10.0 | 10000 | 12.263 ms | 0.0682 ms | 0.0638 ms | 12.282 ms |  1.05 |    0.01 | 15.6250 | 15.6250 | 15.6250 | 258.68 KB |        1.00 |
| GetTotalUsingBlockingCollectionMultipleTasks | .NET 10.0 | .NET 10.0 | 10000 | 75.535 ms | 1.4292 ms | 3.7901 ms | 74.033 ms |  6.47 |    0.32 |       - |       - |       - | 263.54 KB |        1.02 |
| GetTotalUsingChannelMultipleTasks            | .NET 10.0 | .NET 10.0 | 10000 | 77.945 ms | 0.2502 ms | 0.2089 ms | 77.888 ms |  6.68 |    0.03 |       - |       - |       - | 267.61 KB |        1.04 |
|                                              |           |           |       |           |           |           |           |       |         |         |         |         |           |             |
| GetTotalUsingBlockingCollectionSingleTask    | .NET 9.0  | .NET 9.0  | 10000 | 11.594 ms | 0.0911 ms | 0.0807 ms | 11.596 ms |  1.00 |    0.01 | 15.6250 | 15.6250 | 15.6250 | 258.39 KB |        1.00 |
| GetTotalUsingChannelSingleTask               | .NET 9.0  | .NET 9.0  | 10000 | 12.286 ms | 0.1628 ms | 0.1523 ms | 12.297 ms |  1.06 |    0.01 | 15.6250 | 15.6250 | 15.6250 | 258.68 KB |        1.00 |
| GetTotalUsingBlockingCollectionMultipleTasks | .NET 9.0  | .NET 9.0  | 10000 | 76.075 ms | 0.2833 ms | 0.2511 ms | 76.063 ms |  6.56 |    0.05 |       - |       - |       - | 263.54 KB |        1.02 |
| GetTotalUsingChannelMultipleTasks            | .NET 9.0  | .NET 9.0  | 10000 | 78.344 ms | 1.5599 ms | 4.5750 ms | 75.769 ms |  6.76 |    0.40 |       - |       - |       - | 267.14 KB |        1.03 |
