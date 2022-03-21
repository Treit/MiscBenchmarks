# Serializing and deserializng JSON

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22581
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                                    Method | Count |         Mean |      Error |     StdDev |     Gen 0 |  Gen 1 | Gen 2 |  Allocated |
|------------------------------------------ |------ |-------------:|-----------:|-----------:|----------:|-------:|------:|-----------:|
|                **SerializeAndDeserializeSTJ** |    **10** |     **8.801 μs** |  **0.1741 μs** |  **0.3966 μs** |    **1.1749** |      **-** |     **-** |       **5 KB** |
| SerializeAndDeserializeSTJCaseInsensitive |    10 |   353.588 μs |  7.0414 μs | 14.6980 μs |    3.9063 | 1.9531 |     - |   17.78 KB |
|         SerializeAndDeserializeNewtonsoft |    10 |    18.619 μs |  0.3715 μs |  0.8971 μs |   10.0098 |      - |     - |   42.27 KB |
|                **SerializeAndDeserializeSTJ** |  **1000** |   **895.577 μs** | **17.4535 μs** | **28.6766 μs** |  **122.0703** |      **-** |     **-** |  **515.47 KB** |
| SerializeAndDeserializeSTJCaseInsensitive |  1000 | 1,253.545 μs | 25.0574 μs | 62.4017 μs |  125.0000 | 1.9531 |     - |  528.57 KB |
|         SerializeAndDeserializeNewtonsoft |  1000 | 1,866.162 μs | 36.9858 μs | 53.0439 μs | 1005.8594 |      - |     - | 4242.03 KB |
