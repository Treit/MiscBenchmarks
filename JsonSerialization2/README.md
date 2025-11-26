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
| **SerializeSTJ**          | **10**    |   **1.514 μs** | **0.0114 μs** | **0.0106 μs** |  **1.00** |    **0.01** |   **0.0477** |      **-** |     **800 B** |        **1.00** |
| SerializeNewtonsoft   | 10    |   2.718 μs | 0.0344 μs | 0.0322 μs |  1.80 |    0.02 |   0.8354 |      - |   14000 B |       17.50 |
| DeserializeSTJ        | 10    |   2.746 μs | 0.0204 μs | 0.0191 μs |  1.81 |    0.02 |   0.1030 |      - |    1760 B |        2.20 |
| DeserializeNewtonsoft | 10    |   5.206 μs | 0.0797 μs | 0.0746 μs |  3.44 |    0.05 |   1.7548 | 0.0153 |   29360 B |       36.70 |
|                       |       |            |           |           |       |         |          |        |           |             |
| **SerializeSTJ**          | **1000**  | **171.026 μs** | **1.2604 μs** | **1.1790 μs** |  **1.00** |    **0.01** |   **5.1270** |      **-** |   **87920 B** |        **1.00** |
| SerializeNewtonsoft   | 1000  | 300.555 μs | 4.5709 μs | 4.2756 μs |  1.76 |    0.03 |  83.9844 |      - | 1407920 B |       16.01 |
| DeserializeSTJ        | 1000  | 282.963 μs | 3.2927 μs | 2.9189 μs |  1.65 |    0.02 |  10.7422 |      - |  183920 B |        2.09 |
| DeserializeNewtonsoft | 1000  | 534.187 μs | 5.8970 μs | 5.5160 μs |  3.12 |    0.04 | 175.7813 | 0.9766 | 2943920 B |       33.48 |
