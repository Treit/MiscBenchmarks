# Pagination with Memory<T> vs ArraySegment<T>

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21390
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21258.4
  [Host]   : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  ShortRun : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                   Method |     Size |          Mean |         Error |        StdDev |      Gen 0 |      Gen 1 |     Gen 2 |    Allocated |
|------------------------- |--------- |--------------:|--------------:|--------------:|-----------:|-----------:|----------:|-------------:|
| PaginateWithArraySegment |     3200 |      44.68 us |      25.37 us |      1.390 us |     4.5166 |     0.2441 |         - |     19.16 KB |
|       PaginateWithMemory |     3200 |      46.39 us |      23.15 us |      1.269 us |     4.5166 |     0.2441 |         - |     19.16 KB |
| PaginateWithArraySegment |    32768 |     458.93 us |     287.16 us |     15.740 us |    45.4102 |     0.4883 |         - |    192.41 KB |
|       PaginateWithMemory |    32768 |     424.07 us |     259.80 us |     14.240 us |    45.4102 |     0.4883 |         - |    192.41 KB |
| PaginateWithArraySegment | 33554432 | 733,441.83 us | 977,551.55 us | 53,582.899 us | 28000.0000 | 11000.0000 | 3000.0000 | 196608.73 KB |
|       PaginateWithMemory | 33554432 | 737,430.97 us |   4,289.21 us |    235.106 us | 28000.0000 | 11000.0000 | 3000.0000 | 196608.63 KB |

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method |     Size |           Mean |         Error |        StdDev |       Gen0 |       Gen1 |      Gen2 |    Allocated |
|------------------------- |--------- |---------------:|--------------:|--------------:|-----------:|-----------:|----------:|-------------:|
| **PaginateWithArraySegment** |     **3200** |       **3.377 μs** |     **0.0173 μs** |     **0.0162 μs** |     **1.1597** |     **0.0725** |         **-** |     **18.95 KB** |
|       PaginateWithMemory |     3200 |       3.408 μs |     0.0355 μs |     0.0332 μs |     1.1597 |     0.0725 |         - |     18.95 KB |
| **PaginateWithArraySegment** |    **32768** |      **32.069 μs** |     **0.2189 μs** |     **0.2048 μs** |    **11.7188** |     **5.7983** |         **-** |     **192.2 KB** |
|       PaginateWithMemory |    32768 |      33.346 μs |     0.2368 μs |     0.2215 μs |    11.7188 |     5.7983 |         - |     192.2 KB |
| **PaginateWithArraySegment** | **33554432** | **187,139.177 μs** | **3,698.7298 μs** | **7,471.6167 μs** | **11666.6667** | **11333.3333** | **2333.3333** |  **196609.3 KB** |
|       PaginateWithMemory | 33554432 | 186,621.727 μs | 3,562.7394 μs | 7,115.1756 μs | 11666.6667 | 11333.3333 | 2333.3333 | 196609.27 KB |
