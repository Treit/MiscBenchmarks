# Serializing and deserializng JSON. Like the JsonSerialization benchmark, but broken
# out by serializing and deserializing separately, rather than round-tripping.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                | Count | Mean         | Error      | StdDev      | Median     | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------- |------ |-------------:|-----------:|------------:|-----------:|------:|--------:|---------:|----------:|------------:|
| **SerializeSTJ**          | **10**    |     **2.606 μs** |  **0.0597 μs** |   **0.1685 μs** |   **2.570 μs** |  **1.00** |    **0.00** |   **0.1831** |     **800 B** |        **1.00** |
| SerializeNewtonsoft   | 10    |     4.064 μs |  0.0794 μs |   0.1432 μs |   4.039 μs |  1.54 |    0.10 |   3.2272 |   13920 B |       17.40 |
| DeserializeSTJ        | 10    |     5.749 μs |  0.6026 μs |   1.7768 μs |   4.761 μs |  2.19 |    0.73 |   0.4196 |    1840 B |        2.30 |
| DeserializeNewtonsoft | 10    |    12.088 μs |  1.3312 μs |   3.9249 μs |  10.238 μs |  4.68 |    1.48 |   6.8054 |   29360 B |       36.70 |
|                       |       |              |            |             |            |       |         |          |           |             |
| **SerializeSTJ**          | **1000**  |   **265.910 μs** |  **7.8379 μs** |  **22.4883 μs** | **260.587 μs** |  **1.00** |    **0.00** |  **20.0195** |   **87920 B** |        **1.00** |
| SerializeNewtonsoft   | 1000  |   463.570 μs | 17.1263 μs |  49.1386 μs | 450.499 μs |  1.75 |    0.23 | 324.2188 | 1399920 B |       15.92 |
| DeserializeSTJ        | 1000  |   444.665 μs |  8.8699 μs |  20.9074 μs | 439.159 μs |  1.66 |    0.14 |  44.4336 |  191920 B |        2.18 |
| DeserializeNewtonsoft | 1000  | 1,048.492 μs | 87.6923 μs | 241.5300 μs | 945.046 μs |  3.99 |    1.08 | 681.6406 | 2943921 B |       33.48 |
