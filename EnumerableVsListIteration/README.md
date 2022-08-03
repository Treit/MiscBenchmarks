# Enumerating using IEnumerable vs List

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT


```
|                   Method |  Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------------- |------- |-------------:|-----------:|-----------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|
| **EnumerateUsingEnumerable** |   **1000** |     **5.906 μs** |  **0.3212 μs** |  **0.9318 μs** |     **5.625 μs** |  **1.00** |    **0.00** |   **0.0076** |        **-** |        **-** |      **40 B** |
|     EnumerateUsingToList |   1000 |     8.899 μs |  0.2065 μs |  0.5925 μs |     8.776 μs |  1.54 |    0.25 |   1.9531 |        - |        - |    8464 B |
|                          |        |              |            |            |              |       |         |          |          |          |           |
| **EnumerateUsingEnumerable** | **100000** |   **552.006 μs** | **16.2709 μs** | **47.4629 μs** |   **540.604 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |      **40 B** |
|     EnumerateUsingToList | 100000 | 1,238.405 μs | 29.5896 μs | 87.2456 μs | 1,229.060 μs |  2.26 |    0.26 | 285.1563 | 285.1563 | 285.1563 | 1049113 B |
