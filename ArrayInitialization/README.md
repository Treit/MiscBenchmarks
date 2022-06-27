# Initializing Multidimensional vs. Jagged arrays.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                           Method | Size |          Mean |       Error |        StdDev |        Median |
|--------------------------------- |----- |--------------:|------------:|--------------:|--------------:|
|           **InitJaggedRandomValues** |  **100** |    **136.590 μs** |   **6.1929 μs** |    **18.2599 μs** |    **131.261 μs** |
| InitMultidimensionalRandomValues |  100 |    115.718 μs |   4.3263 μs |    12.6200 μs |    110.550 μs |
|             InitJaggedFixedValue |  100 |      8.935 μs |   0.2441 μs |     0.6806 μs |      8.731 μs |
|   InitMultidimensionalFixedValue |  100 |     18.696 μs |   0.7215 μs |     2.1160 μs |     18.297 μs |
|           **InitJaggedRandomValues** | **1024** | **14,521.715 μs** | **462.8224 μs** | **1,357.3778 μs** | **14,308.362 μs** |
| InitMultidimensionalRandomValues | 1024 | 12,599.513 μs | 464.9211 μs | 1,333.9457 μs | 12,369.759 μs |
|             InitJaggedFixedValue | 1024 |    805.751 μs |  20.8999 μs |    60.3009 μs |    790.840 μs |
|   InitMultidimensionalFixedValue | 1024 |  1,878.145 μs |  61.3491 μs |   172.0295 μs |  1,817.200 μs |
