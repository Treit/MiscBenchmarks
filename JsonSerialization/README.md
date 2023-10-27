# Serializing and deserializng JSON


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25982.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2


```
|                                             Method | Count |         Mean |      Error |      StdDev |       Median |      Gen0 |   Gen1 |  Allocated |
|--------------------------------------------------- |------ |-------------:|-----------:|------------:|-------------:|----------:|-------:|-----------:|
|                         **SerializeAndDeserializeSTJ** |    **10** |    **10.386 μs** |  **0.4277 μs** |   **1.2475 μs** |     **9.901 μs** |    **0.8087** |      **-** |    **3.44 KB** |
|            SerializeAndDeserializeSTJCachedOptions |    10 |    12.134 μs |  0.9411 μs |   2.7304 μs |    11.319 μs |    0.8087 |      - |    3.44 KB |
|                SerializeAndDeserializeSTJSourceGen |    10 |     9.650 μs |  0.1984 μs |   0.5757 μs |     9.490 μs |    0.7477 |      - |     3.2 KB |
|          SerializeAndDeserializeSTJCaseInsensitive |    10 |    10.906 μs |  0.3941 μs |   1.1306 μs |    10.533 μs |    0.8392 |      - |    3.67 KB |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen |    10 |    10.994 μs |  0.4345 μs |   1.2468 μs |    10.610 μs |    0.7935 | 0.0153 |    3.44 KB |
|                  SerializeAndDeserializeNewtonsoft |    10 |    19.735 μs |  0.4642 μs |   1.3318 μs |    19.260 μs |   10.0098 |      - |   42.27 KB |
|                         **SerializeAndDeserializeSTJ** |  **1000** |   **928.660 μs** | **18.5310 μs** |  **40.2848 μs** |   **915.122 μs** |   **84.9609** |      **-** |  **359.22 KB** |
|            SerializeAndDeserializeSTJCachedOptions |  1000 |   963.821 μs | 19.0245 μs |  47.7287 μs |   948.244 μs |   83.9844 |      - |  359.22 KB |
|                SerializeAndDeserializeSTJSourceGen |  1000 | 1,010.360 μs | 27.0858 μs |  75.5043 μs |   990.459 μs |   79.1016 |      - |  335.78 KB |
|          SerializeAndDeserializeSTJCaseInsensitive |  1000 |   975.879 μs | 21.1928 μs |  58.3710 μs |   963.194 μs |   84.9609 |      - |  359.47 KB |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen |  1000 | 1,023.682 μs | 40.1027 μs | 116.9815 μs |   974.491 μs |   79.1016 |      - |     336 KB |
|                  SerializeAndDeserializeNewtonsoft |  1000 | 2,107.577 μs | 68.1222 μs | 199.7905 μs | 2,077.829 μs | 1003.9063 |      - | 4242.03 KB |
