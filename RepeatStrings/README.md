# Repeating strings

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22518
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT


```
|                       Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|   **DupeUsingStringBuilderLoop** |     **3** |    **44.42 ns** |  **0.964 ns** |  **1.557 ns** |  **1.00** |    **0.00** | **0.0315** |     **-** |     **-** |     **136 B** |
|        DupeUsingStringCreate |     3 |    30.15 ns |  0.702 ns |  1.466 ns |  0.68 |    0.04 | 0.0241 |     - |     - |     104 B |
| DupeUsingStackOverflowAnswer |     3 |    79.76 ns |  1.666 ns |  3.477 ns |  1.82 |    0.12 | 0.0592 |     - |     - |     256 B |
|    DupeUsingEnumerableRepeat |     3 |    67.38 ns |  1.304 ns |  2.513 ns |  1.53 |    0.09 | 0.0185 |     - |     - |      80 B |
|                              |       |             |           |           |       |         |        |       |       |           |
|   **DupeUsingStringBuilderLoop** |    **50** |   **368.56 ns** |  **7.444 ns** | **14.164 ns** |  **1.00** |    **0.00** | **0.1631** |     **-** |     **-** |     **704 B** |
|        DupeUsingStringCreate |    50 |   274.73 ns |  5.533 ns | 10.922 ns |  0.75 |    0.04 | 0.0906 |     - |     - |     392 B |
| DupeUsingStackOverflowAnswer |    50 |   923.33 ns | 17.688 ns | 20.370 ns |  2.53 |    0.10 | 0.3462 |     - |     - |    1496 B |
|    DupeUsingEnumerableRepeat |    50 |   570.13 ns | 10.895 ns | 23.217 ns |  1.55 |    0.08 | 0.0849 |     - |     - |     368 B |
|                              |       |             |           |           |       |         |        |       |       |           |
|   **DupeUsingStringBuilderLoop** |   **100** |   **687.39 ns** | **13.570 ns** | **26.786 ns** |  **1.00** |    **0.00** | **0.3004** |     **-** |     **-** |    **1296 B** |
|        DupeUsingStringCreate |   100 |   509.74 ns | 10.156 ns | 20.746 ns |  0.74 |    0.04 | 0.1593 |     - |     - |     688 B |
| DupeUsingStackOverflowAnswer |   100 | 1,658.66 ns | 32.777 ns | 64.699 ns |  2.42 |    0.14 | 0.5970 |     - |     - |    2576 B |
|    DupeUsingEnumerableRepeat |   100 | 1,133.86 ns | 22.615 ns | 41.352 ns |  1.65 |    0.08 | 0.1526 |     - |     - |     664 B |
