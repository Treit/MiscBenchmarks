# Serializing and deserializng JSON




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                             | Count | Mean         | Error      | StdDev      | Median       | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|--------------------------------------------------- |------ |-------------:|-----------:|------------:|-------------:|------:|--------:|----------:|-----------:|------------:|
| **SerializeAndDeserializeSTJ**                         | **10**    |     **7.248 μs** |  **0.1464 μs** |   **0.4200 μs** |     **7.188 μs** |  **1.00** |    **0.00** |    **0.6104** |    **2.58 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | 10    |     6.857 μs |  0.0742 μs |   0.0579 μs |     6.850 μs |  0.94 |    0.07 |    0.6104 |    2.58 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | 10    |     7.140 μs |  0.1423 μs |   0.2970 μs |     7.088 μs |  0.99 |    0.08 |    0.5493 |    2.34 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | 10    |     7.509 μs |  0.1404 μs |   0.2567 μs |     7.421 μs |  1.04 |    0.08 |    0.6256 |    2.75 KB |        1.07 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | 10    |     7.517 μs |  0.1468 μs |   0.2010 μs |     7.470 μs |  1.03 |    0.07 |    0.5569 |    2.52 KB |        0.98 |
| SerializeAndDeserializeNewtonsoft                  | 10    |    12.291 μs |  0.1540 μs |   0.1286 μs |    12.261 μs |  1.67 |    0.13 |   10.0250 |   42.27 KB |       16.39 |
|                                                    |       |              |            |             |              |       |         |           |            |             |
| **SerializeAndDeserializeSTJ**                         | **1000**  |   **673.840 μs** | **13.2922 μs** |  **26.5459 μs** |   **665.719 μs** |  **1.00** |    **0.00** |   **64.4531** |  **273.28 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | 1000  |   677.267 μs |  7.9978 μs |   7.4811 μs |   676.342 μs |  1.01 |    0.04 |   64.4531 |  273.28 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | 1000  |   710.237 μs | 11.6233 μs |  10.3037 μs |   712.029 μs |  1.06 |    0.05 |   58.5938 |  249.84 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | 1000  |   728.775 μs | 22.9358 μs |  62.7864 μs |   708.216 μs |  1.05 |    0.09 |   64.4531 |  273.47 KB |        1.00 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | 1000  |   729.225 μs | 14.5729 μs |  34.6341 μs |   721.560 μs |  1.09 |    0.07 |   58.5938 |  250.01 KB |        0.91 |
| SerializeAndDeserializeNewtonsoft                  | 1000  | 1,390.585 μs | 58.2782 μs | 162.4564 μs | 1,311.471 μs |  2.09 |    0.27 | 1005.8594 | 4242.03 KB |       15.52 |
