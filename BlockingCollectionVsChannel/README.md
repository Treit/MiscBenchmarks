# BlockingCollection vs Channels


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                       Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |    Gen0 |    Gen1 |    Gen2 | Allocated | Alloc Ratio |
|--------------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
|    **GetTotalUsingBlockingCollectionSingleTask** |  **1000** |  **1.201 ms** | **0.0028 ms** | **0.0025 ms** |  **1.00** |    **0.00** |  **1.9531** |       **-** |       **-** |  **33.51 KB** |        **1.00** |
|               GetTotalUsingChannelSingleTask |  1000 |  1.177 ms | 0.0020 ms | 0.0016 ms |  0.98 |    0.00 |  1.9531 |       - |       - |  33.85 KB |        1.01 |
| GetTotalUsingBlockingCollectionMultipleTasks |  1000 |  7.466 ms | 0.0105 ms | 0.0093 ms |  6.22 |    0.01 |       - |       - |       - |  29.28 KB |        0.87 |
|            GetTotalUsingChannelMultipleTasks |  1000 |  7.224 ms | 0.0245 ms | 0.0229 ms |  6.01 |    0.03 |       - |       - |       - |  40.17 KB |        1.20 |
|                                              |       |           |           |           |       |         |         |         |         |           |             |
|    **GetTotalUsingBlockingCollectionSingleTask** | **10000** | **12.131 ms** | **0.0090 ms** | **0.0084 ms** |  **1.00** |    **0.00** | **15.6250** | **15.6250** | **15.6250** | **258.39 KB** |        **1.00** |
|               GetTotalUsingChannelSingleTask | 10000 | 11.464 ms | 0.0200 ms | 0.0167 ms |  0.95 |    0.00 | 15.6250 | 15.6250 | 15.6250 | 258.73 KB |        1.00 |
| GetTotalUsingBlockingCollectionMultipleTasks | 10000 | 75.063 ms | 0.0753 ms | 0.0629 ms |  6.19 |    0.01 |       - |       - |       - | 263.62 KB |        1.02 |
|            GetTotalUsingChannelMultipleTasks | 10000 | 74.566 ms | 0.2114 ms | 0.1874 ms |  6.15 |    0.02 |       - |       - |       - | 266.18 KB |        1.03 |
