# Serializing and deserializng JSON. Like the JsonSerialization benchmark, but broken
# out by serializing and deserializing separately, rather than round-tripping.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1   | Allocated | Alloc Ratio |
|---------------------- |------ |-----------:|----------:|----------:|------:|--------:|---------:|-------:|----------:|------------:|
| **SerializeSTJ**          | **10**    |   **1.828 μs** | **0.0077 μs** | **0.0068 μs** |  **1.00** |    **0.01** |   **0.0477** |      **-** |     **800 B** |        **1.00** |
| SerializeNewtonsoft   | 10    |   2.976 μs | 0.0322 μs | 0.0302 μs |  1.63 |    0.02 |   0.8354 |      - |   14000 B |       17.50 |
| DeserializeSTJ        | 10    |   2.813 μs | 0.0111 μs | 0.0093 μs |  1.54 |    0.01 |   0.1030 |      - |    1760 B |        2.20 |
| DeserializeNewtonsoft | 10    |   5.125 μs | 0.0620 μs | 0.0580 μs |  2.80 |    0.03 |   1.7548 | 0.0153 |   29360 B |       36.70 |
|                       |       |            |           |           |       |         |          |        |           |             |
| **SerializeSTJ**          | **1000**  | **168.792 μs** | **1.7261 μs** | **1.4414 μs** |  **1.00** |    **0.01** |   **5.1270** |      **-** |   **87920 B** |        **1.00** |
| SerializeNewtonsoft   | 1000  | 282.569 μs | 4.7265 μs | 4.4212 μs |  1.67 |    0.03 |  83.9844 |      - | 1407920 B |       16.01 |
| DeserializeSTJ        | 1000  | 275.855 μs | 2.8485 μs | 2.5251 μs |  1.63 |    0.02 |  10.7422 |      - |  183920 B |        2.09 |
| DeserializeNewtonsoft | 1000  | 524.099 μs | 7.5840 μs | 7.0941 μs |  3.11 |    0.05 | 175.7813 | 0.9766 | 2943920 B |       33.48 |
