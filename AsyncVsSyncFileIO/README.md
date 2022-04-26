# Reading and writing files

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22598
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.202
  [Host]     : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT


```
|         Method |  Count |         Mean |      Error |       StdDev |     Gen 0 |  Gen 1 | Gen 2 |   Allocated |
|--------------- |------- |-------------:|-----------:|-------------:|----------:|-------:|------:|------------:|
|   ReadFileSync |    100 |     53.46 μs |   1.069 μs |     2.391 μs |    2.5635 | 1.2817 |     - |    10.81 KB |
|   ReadFileSync |     10 |     56.17 μs |   1.481 μs |     4.274 μs |    1.8921 | 0.9155 |     - |        8 KB |
|  ReadFileAsync |     10 |    118.76 μs |   2.596 μs |     7.491 μs |    2.4414 | 1.2207 |     - |     9.81 KB |
|  ReadFileAsync |    100 |    123.03 μs |   2.446 μs |     4.654 μs |    5.2490 | 2.5635 |     - |    18.95 KB |
|  WriteFileSync |    100 |    478.65 μs |   8.218 μs |    10.093 μs |    2.9297 | 0.9766 |     - |    12.57 KB |
|  WriteFileSync |     10 |    483.93 μs |   7.643 μs |     6.775 μs |    1.4648 | 0.4883 |     - |     6.73 KB |
| WriteFileAsync |    100 |    488.19 μs |   9.374 μs |    12.189 μs |    2.9297 | 0.9766 |     - |    12.57 KB |
| WriteFileAsync |     10 |    493.49 μs |   9.571 μs |    13.417 μs |    1.4648 | 0.4883 |     - |     6.73 KB |
|   ReadFileSync | 100000 |  3,363.85 μs |  93.022 μs |   263.887 μs |  769.5313 |      - |     - |  3245.17 KB |
|  WriteFileSync | 100000 |  5,759.61 μs | 170.317 μs |   488.671 μs |  742.1875 |      - |     - |  3134.45 KB |
|  ReadFileAsync | 100000 |  8,922.66 μs | 320.169 μs |   928.868 μs | 2437.5000 |      - |     - | 10315.55 KB |
| WriteFileAsync | 100000 | 10,949.55 μs | 386.633 μs | 1,115.523 μs |  750.0000 |      - |     - |  3185.91 KB |
