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