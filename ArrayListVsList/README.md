# ArrayList vs List

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25241
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|           Method |  Count |       Mean |     Error |    StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------------- |------- |-----------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|
|  CreateArrayList | 100000 | 9,833.1 μs | 327.85 μs | 966.66 μs | 65.82 |    6.93 | 796.8750 | 671.8750 | 421.8750 | 4497742 B |
|       CreateList | 100000 |   478.9 μs |  10.72 μs |  31.61 μs |  3.12 |    0.23 | 128.9063 | 101.5625 |  98.1445 | 1049677 B |
| IterateArrayList | 100000 |   783.1 μs |  19.72 μs |  56.90 μs |  5.20 |    0.38 |        - |        - |        - |      48 B |
|      IterateList | 100000 |   152.1 μs |   2.75 μs |   6.48 μs |  1.00 |    0.00 |        - |        - |        - |         - |

