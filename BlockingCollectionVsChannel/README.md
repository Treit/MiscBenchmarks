# BlockingCollection vs Channels

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22543
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT


```
|                                       Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|    **GetTotalUsingBlockingCollectionSingleTask** |  **1000** |  **2.792 ms** | **0.0554 ms** | **0.1040 ms** |  **1.00** |    **0.00** | **7.8125** |     **-** |     **-** |  **33.51 KB** |
|               GetTotalUsingChannelSingleTask |  1000 |  3.827 ms | 0.0858 ms | 0.2503 ms |  1.35 |    0.12 | 7.8125 |     - |     - |  33.86 KB |
| GetTotalUsingBlockingCollectionMultipleTasks |  1000 |  8.597 ms | 0.1708 ms | 0.4378 ms |  3.05 |    0.21 |      - |     - |     - |  39.55 KB |
|            GetTotalUsingChannelMultipleTasks |  1000 |  7.166 ms | 0.1377 ms | 0.1741 ms |  2.55 |    0.11 | 7.8125 |     - |     - |  39.27 KB |
|                                              |       |           |           |           |       |         |        |       |       |           |
|    **GetTotalUsingBlockingCollectionSingleTask** | **10000** | **27.284 ms** | **0.4959 ms** | **0.6271 ms** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** | **258.28 KB** |
|               GetTotalUsingChannelSingleTask | 10000 | 37.129 ms | 0.7337 ms | 1.3231 ms |  1.36 |    0.06 |      - |     - |     - | 258.65 KB |
| GetTotalUsingBlockingCollectionMultipleTasks | 10000 | 79.270 ms | 1.5578 ms | 2.5596 ms |  2.89 |    0.15 |      - |     - |     - | 264.27 KB |
|            GetTotalUsingChannelMultipleTasks | 10000 | 72.187 ms | 0.6395 ms | 0.5669 ms |  2.63 |    0.05 |      - |     - |     - | 264.77 KB |
