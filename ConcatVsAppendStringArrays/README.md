# Concat vs Append String Arrays Benchmark

Compares different approaches for creating string arrays that combine a range of generated strings with additional fixed strings.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27934.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method              | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|-------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|-------:|----------:|------------:|
| **UsingConcat**         | **100**   |  **4.524 μs** | **0.0878 μs** | **0.0733 μs** |  **4.514 μs** |  **1.00** |    **0.02** |  **1.0071** |      **-** |   **4.25 KB** |        **1.00** |
| UsingAppend         | 100   |  3.467 μs | 0.0671 μs | 0.0595 μs |  3.450 μs |  0.77 |    0.02 |  1.0071 |      - |   4.24 KB |        1.00 |
| UsingListAdd        | 100   |  2.772 μs | 0.0547 μs | 0.0802 μs |  2.750 μs |  0.61 |    0.02 |  1.1406 | 0.0038 |    4.8 KB |        1.13 |
| UsingListAddRange   | 100   |  3.827 μs | 0.0760 μs | 0.1961 μs |  3.777 μs |  0.85 |    0.05 |  1.1597 |      - |   4.89 KB |        1.15 |
| UsingArrayWithIndex | 100   |  3.039 μs | 0.0739 μs | 0.2121 μs |  2.974 μs |  0.67 |    0.05 |  0.9384 |      - |   3.95 KB |        0.93 |
| UsingArrayCopyTo    | 100   |  3.038 μs | 0.0822 μs | 0.2318 μs |  2.947 μs |  0.67 |    0.05 |  1.1292 |      - |   4.76 KB |        1.12 |
| UsingSpanAndCopyTo  | 100   |  2.693 μs | 0.0503 μs | 0.0767 μs |  2.673 μs |  0.60 |    0.02 |  0.9384 |      - |   3.95 KB |        0.93 |
|                     |       |           |           |           |           |       |         |         |        |           |             |
| **UsingConcat**         | **1000**  | **43.667 μs** | **0.5642 μs** | **0.5278 μs** | **43.749 μs** |  **1.00** |    **0.02** | **10.9863** | **0.0610** |  **46.44 KB** |        **1.00** |
| UsingAppend         | 1000  | 36.668 μs | 0.7077 μs | 0.9687 μs | 36.546 μs |  0.84 |    0.02 | 10.9863 | 1.4038 |  46.43 KB |        1.00 |
| UsingListAdd        | 1000  | 29.801 μs | 0.4836 μs | 0.6456 μs | 29.578 μs |  0.68 |    0.02 | 12.8174 | 1.5869 |  54.02 KB |        1.16 |
| UsingListAddRange   | 1000  | 36.580 μs | 0.5618 μs | 0.4691 μs | 36.376 μs |  0.84 |    0.01 | 12.8174 | 1.7090 |  54.11 KB |        1.17 |
| UsingArrayWithIndex | 1000  | 29.875 μs | 0.5576 μs | 0.5477 μs | 29.778 μs |  0.68 |    0.01 | 10.9253 | 1.4038 |  46.14 KB |        0.99 |
| UsingArrayCopyTo    | 1000  | 29.943 μs | 0.5870 μs | 0.9967 μs | 29.736 μs |  0.69 |    0.02 | 12.8174 |      - |  53.98 KB |        1.16 |
| UsingSpanAndCopyTo  | 1000  | 29.747 μs | 0.5466 μs | 0.7108 μs | 29.500 μs |  0.68 |    0.02 | 10.9253 | 1.4343 |  46.14 KB |        0.99 |
