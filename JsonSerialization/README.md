# Serializing and deserializng JSON

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25290.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|                                    Method | Count |        Mean |     Error |     StdDev |      Median |      Gen0 |   Gen1 |  Allocated |
|------------------------------------------ |------ |------------:|----------:|-----------:|------------:|----------:|-------:|-----------:|
|                **SerializeAndDeserializeSTJ** |    **10** |    **10.20 μs** |  **0.283 μs** |   **0.829 μs** |    **10.07 μs** |    **0.8087** |      **-** |    **3.44 KB** |
| SerializeAndDeserializeSTJCaseInsensitive |    10 |    10.88 μs |  0.332 μs |   0.968 μs |    10.83 μs |    0.8545 | 0.0305 |    3.74 KB |
|         SerializeAndDeserializeNewtonsoft |    10 |    20.62 μs |  0.618 μs |   1.774 μs |    20.85 μs |   10.0098 |      - |   42.27 KB |
|                **SerializeAndDeserializeSTJ** |  **1000** |   **979.22 μs** | **26.773 μs** |  **78.520 μs** |   **973.60 μs** |   **83.9844** |      **-** |  **359.22 KB** |
| SerializeAndDeserializeSTJCaseInsensitive |  1000 | 1,002.81 μs | 39.130 μs | 113.524 μs | 1,002.66 μs |   83.9844 |      - |  359.56 KB |
|         SerializeAndDeserializeNewtonsoft |  1000 | 1,993.21 μs | 90.092 μs | 258.491 μs | 1,923.06 μs | 1003.9063 |      - | 4242.03 KB |
