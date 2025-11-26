# BlockingCollection vs Channels




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                       | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|--------------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **GetTotalUsingBlockingCollectionSingleTask**    | **1000**  |  **1.178 ms** | **0.0081 ms** | **0.0076 ms** |  **1.00** |    **0.01** |  **1.9531** |       **-** |       **-** |  **33.51 KB** |        **1.00** |
| GetTotalUsingChannelSingleTask               | 1000  |  1.259 ms | 0.0063 ms | 0.0059 ms |  1.07 |    0.01 |  1.9531 |       - |       - |   33.8 KB |        1.01 |
| GetTotalUsingBlockingCollectionMultipleTasks | 1000  |  7.722 ms | 0.0274 ms | 0.0214 ms |  6.56 |    0.04 |       - |       - |       - |  24.95 KB |        0.74 |
| GetTotalUsingChannelMultipleTasks            | 1000  |  7.790 ms | 0.0504 ms | 0.0472 ms |  6.62 |    0.06 |       - |       - |       - |  28.65 KB |        0.86 |
|                                              |       |           |           |           |       |         |         |         |         |           |             |
| **GetTotalUsingBlockingCollectionSingleTask**    | **10000** | **11.526 ms** | **0.0565 ms** | **0.0529 ms** |  **1.00** |    **0.01** | **15.6250** | **15.6250** | **15.6250** | **258.39 KB** |        **1.00** |
| GetTotalUsingChannelSingleTask               | 10000 | 11.954 ms | 0.0540 ms | 0.0506 ms |  1.04 |    0.01 | 15.6250 | 15.6250 | 15.6250 | 258.68 KB |        1.00 |
| GetTotalUsingBlockingCollectionMultipleTasks | 10000 | 74.643 ms | 0.3739 ms | 0.3122 ms |  6.48 |    0.04 |       - |       - |       - | 263.54 KB |        1.02 |
| GetTotalUsingChannelMultipleTasks            | 10000 | 74.369 ms | 0.2683 ms | 0.2509 ms |  6.45 |    0.04 |       - |       - |       - | 266.36 KB |        1.03 |
