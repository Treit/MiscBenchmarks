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
| **GetTotalUsingBlockingCollectionSingleTask**    | **1000**  |  **1.218 ms** | **0.0057 ms** | **0.0053 ms** |  **1.00** |    **0.01** |  **1.9531** |       **-** |       **-** |  **33.51 KB** |        **1.00** |
| GetTotalUsingChannelSingleTask               | 1000  |  1.198 ms | 0.0065 ms | 0.0061 ms |  0.98 |    0.01 |  1.9531 |       - |       - |   33.8 KB |        1.01 |
| GetTotalUsingBlockingCollectionMultipleTasks | 1000  |  7.458 ms | 0.0351 ms | 0.0293 ms |  6.13 |    0.03 |       - |       - |       - |  30.93 KB |        0.92 |
| GetTotalUsingChannelMultipleTasks            | 1000  |  7.651 ms | 0.0378 ms | 0.0335 ms |  6.28 |    0.04 |       - |       - |       - |  31.43 KB |        0.94 |
|                                              |       |           |           |           |       |         |         |         |         |           |             |
| **GetTotalUsingBlockingCollectionSingleTask**    | **10000** | **11.918 ms** | **0.0526 ms** | **0.0492 ms** |  **1.00** |    **0.01** | **15.6250** | **15.6250** | **15.6250** | **258.39 KB** |        **1.00** |
| GetTotalUsingChannelSingleTask               | 10000 | 12.092 ms | 0.0573 ms | 0.0536 ms |  1.01 |    0.01 | 15.6250 | 15.6250 | 15.6250 | 258.68 KB |        1.00 |
| GetTotalUsingBlockingCollectionMultipleTasks | 10000 | 75.070 ms | 0.2370 ms | 0.1979 ms |  6.30 |    0.03 |       - |       - |       - | 245.21 KB |        0.95 |
| GetTotalUsingChannelMultipleTasks            | 10000 | 75.886 ms | 0.1135 ms | 0.1006 ms |  6.37 |    0.03 |       - |       - |       - | 267.11 KB |        1.03 |
