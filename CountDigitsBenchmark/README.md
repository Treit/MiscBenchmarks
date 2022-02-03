## Counting digits

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22538
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|                 Method |  Count |         Mean |      Error |     StdDev |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------- |-------------:|-----------:|-----------:|---------:|------:|------:|----------:|
|   **CountDigitsUsingMath** |    **100** |     **1.021 μs** |  **0.0193 μs** |  **0.0402 μs** |        **-** |     **-** |     **-** |         **-** |
| CountDigitsUsingString |    100 |     1.150 μs |  0.0224 μs |  0.0386 μs |   0.6676 |     - |     - |    2880 B |
|   **CountDigitsUsingMath** |   **1000** |     **9.668 μs** |  **0.1930 μs** |  **0.3431 μs** |        **-** |     **-** |     **-** |         **-** |
| CountDigitsUsingString |   1000 |    13.680 μs |  0.2664 μs |  0.4377 μs |   7.3242 |     - |     - |   31680 B |
|   **CountDigitsUsingMath** | **100000** |   **954.791 μs** | **18.9884 μs** | **42.0770 μs** |        **-** |     **-** |     **-** |         **-** |
| CountDigitsUsingString | 100000 | 1,681.139 μs | 33.5211 μs | 82.2277 μs | 740.2344 |     - |     - | 3199680 B |
