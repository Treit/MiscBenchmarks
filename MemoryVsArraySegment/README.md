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



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Size     | Mean           | Error         | StdDev        | Median         | Gen0       | Gen1       | Gen2      | Allocated    |
|------------------------- |--------- |---------------:|--------------:|--------------:|---------------:|-----------:|-----------:|----------:|-------------:|
| **PaginateWithArraySegment** | **3200**     |       **3.510 μs** |     **0.0570 μs** |     **0.0533 μs** |       **3.490 μs** |     **1.1597** |     **0.0725** |         **-** |     **18.95 KB** |
| PaginateWithMemory       | 3200     |       3.596 μs |     0.0692 μs |     0.0647 μs |       3.596 μs |     1.1597 |     0.0725 |         - |     18.95 KB |
| **PaginateWithArraySegment** | **32768**    |      **34.881 μs** |     **0.6883 μs** |     **0.6439 μs** |      **34.663 μs** |    **11.7188** |     **5.7983** |         **-** |     **192.2 KB** |
| PaginateWithMemory       | 32768    |      35.443 μs |     0.6042 μs |     0.5045 μs |      35.507 μs |    11.7188 |     5.7983 |         - |     192.2 KB |
| **PaginateWithArraySegment** | **33554432** | **189,906.098 μs** | **3,758.6793 μs** | **7,928.3309 μs** | **186,958.017 μs** | **11666.6667** | **11333.3333** | **2333.3333** | **196609.17 KB** |
| PaginateWithMemory       | 33554432 | 186,826.766 μs | 3,728.9717 μs | 6,724.1056 μs | 185,720.700 μs | 11666.6667 | 11333.3333 | 2333.3333 |  196609.2 KB |
