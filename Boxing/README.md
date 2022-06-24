# Illustrating the overhead of boxing

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                    Method |  Count |         Mean |      Error |     StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|-------------------------- |------- |-------------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|-----------:|
| **BuildIntListWithoutBoxing** |   **1000** |     **2.027 μs** |  **0.0842 μs** |  **0.2442 μs** |  **1.00** |    **0.00** |   **0.9384** |        **-** |        **-** |    **3.96 KB** |
|     BuildIntListWitBoxing |   1000 |     9.512 μs |  0.1876 μs |  0.3335 μs |  4.72 |    0.53 |   7.4158 |   0.0153 |        - |    31.3 KB |
|                           |        |              |            |            |       |         |          |          |          |            |
| **BuildIntListWithoutBoxing** | **100000** |   **223.226 μs** |  **7.9368 μs** | **23.4018 μs** |  **1.00** |    **0.00** | **124.7559** | **124.7559** | **124.7559** |  **390.72 KB** |
|     BuildIntListWitBoxing | 100000 | 4,786.679 μs | 91.8320 μs | 85.8997 μs | 24.99 |    1.88 | 492.1875 | 242.1875 | 242.1875 | 3125.14 KB |
