## Counting digits

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22538
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|                             Method |  Count |         Mean |      Error |      StdDev | Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------- |------- |-------------:|-----------:|------------:|------:|--------:|---------:|------:|------:|----------:|
|               **CountDigitsUsingMath** |    **100** |     **1.014 μs** |  **0.0200 μs** |   **0.0328 μs** |  **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
| CountDigitsUsingMathIncludingFloor |    100 |     1.122 μs |  0.0225 μs |   0.0507 μs |  1.10 |    0.07 |        - |     - |     - |         - |
|             CountDigitsUsingString |    100 |     1.521 μs |  0.0304 μs |   0.0654 μs |  1.50 |    0.09 |   0.6676 |     - |     - |    2880 B |
|           CountDigitsUsingMaxMahem |    100 |     4.175 μs |  0.0828 μs |   0.1920 μs |  4.17 |    0.21 |        - |     - |     - |         - |
|                                    |        |              |            |             |       |         |          |       |       |           |
|               **CountDigitsUsingMath** |   **1000** |     **9.632 μs** |  **0.1874 μs** |   **0.2861 μs** |  **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
| CountDigitsUsingMathIncludingFloor |   1000 |    11.282 μs |  0.2198 μs |   0.2443 μs |  1.16 |    0.04 |        - |     - |     - |         - |
|             CountDigitsUsingString |   1000 |    17.083 μs |  0.3399 μs |   0.8954 μs |  1.82 |    0.11 |   7.3242 |     - |     - |   31680 B |
|           CountDigitsUsingMaxMahem |   1000 |    46.958 μs |  0.9280 μs |   2.0565 μs |  4.80 |    0.23 |        - |     - |     - |         - |
|                                    |        |              |            |             |       |         |          |       |       |           |
|               **CountDigitsUsingMath** | **100000** |   **957.358 μs** | **19.0435 μs** |  **42.1991 μs** |  **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
| CountDigitsUsingMathIncludingFloor | 100000 | 1,045.218 μs | 20.6043 μs |  45.6577 μs |  1.09 |    0.07 |        - |     - |     - |         - |
|             CountDigitsUsingString | 100000 | 1,983.332 μs | 39.5994 μs | 104.3206 μs |  2.06 |    0.15 | 738.2813 |     - |     - | 3199680 B |
|           CountDigitsUsingMaxMahem | 100000 | 4,245.882 μs | 84.1938 μs | 151.8188 μs |  4.40 |    0.27 |        - |     - |     - |         - |
