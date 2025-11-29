# Serializing and deserializng JSON. Like the JsonSerialization benchmark, but broken
# out by serializing and deserializing separately, rather than round-tripping.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Job       | Runtime   | Count | Mean       | Error      | StdDev     | Ratio | RatioSD | Gen0     | Gen1   | Allocated | Alloc Ratio |
|---------------------- |---------- |---------- |------ |-----------:|-----------:|-----------:|------:|--------:|---------:|-------:|----------:|------------:|
| **SerializeSTJ**          | **.NET 10.0** | **.NET 10.0** | **10**    |   **1.579 μs** |  **0.0307 μs** |  **0.0301 μs** |  **1.00** |    **0.03** |   **0.0477** |      **-** |     **800 B** |        **1.00** |
| SerializeNewtonsoft   | .NET 10.0 | .NET 10.0 | 10    |   2.741 μs |  0.0519 μs |  0.0486 μs |  1.74 |    0.04 |   0.8354 |      - |   14000 B |       17.50 |
| DeserializeSTJ        | .NET 10.0 | .NET 10.0 | 10    |   2.690 μs |  0.0284 μs |  0.0252 μs |  1.70 |    0.04 |   0.1030 |      - |    1760 B |        2.20 |
| DeserializeNewtonsoft | .NET 10.0 | .NET 10.0 | 10    |   5.259 μs |  0.0550 μs |  0.0515 μs |  3.33 |    0.07 |   1.7548 | 0.0153 |   29360 B |       36.70 |
|                       |           |           |       |            |            |            |       |         |          |        |           |             |
| SerializeSTJ          | .NET 9.0  | .NET 9.0  | 10    |   1.648 μs |  0.0097 μs |  0.0086 μs |  1.00 |    0.01 |   0.0477 |      - |     800 B |        1.00 |
| SerializeNewtonsoft   | .NET 9.0  | .NET 9.0  | 10    |   2.803 μs |  0.0419 μs |  0.0392 μs |  1.70 |    0.02 |   0.8354 |      - |   14000 B |       17.50 |
| DeserializeSTJ        | .NET 9.0  | .NET 9.0  | 10    |   2.742 μs |  0.0339 μs |  0.0317 μs |  1.66 |    0.02 |   0.1030 |      - |    1760 B |        2.20 |
| DeserializeNewtonsoft | .NET 9.0  | .NET 9.0  | 10    |   5.248 μs |  0.0985 μs |  0.1054 μs |  3.18 |    0.06 |   1.7548 | 0.0153 |   29360 B |       36.70 |
|                       |           |           |       |            |            |            |       |         |          |        |           |             |
| **SerializeSTJ**          | **.NET 10.0** | **.NET 10.0** | **1000**  | **162.057 μs** |  **2.4309 μs** |  **2.2738 μs** |  **1.00** |    **0.02** |   **5.1270** |      **-** |   **87924 B** |        **1.00** |
| SerializeNewtonsoft   | .NET 10.0 | .NET 10.0 | 1000  | 286.015 μs |  5.5597 μs |  5.4604 μs |  1.77 |    0.04 |  83.9844 |      - | 1407920 B |       16.01 |
| DeserializeSTJ        | .NET 10.0 | .NET 10.0 | 1000  | 268.937 μs |  3.1558 μs |  2.9519 μs |  1.66 |    0.03 |  10.7422 |      - |  183920 B |        2.09 |
| DeserializeNewtonsoft | .NET 10.0 | .NET 10.0 | 1000  | 547.604 μs | 10.8038 μs | 13.6633 μs |  3.38 |    0.09 | 175.7813 | 0.9766 | 2943920 B |       33.48 |
|                       |           |           |       |            |            |            |       |         |          |        |           |             |
| SerializeSTJ          | .NET 9.0  | .NET 9.0  | 1000  | 168.180 μs |  1.0931 μs |  0.9690 μs |  1.00 |    0.01 |   5.1270 |      - |   87924 B |        1.00 |
| SerializeNewtonsoft   | .NET 9.0  | .NET 9.0  | 1000  | 289.579 μs |  4.7723 μs |  4.4640 μs |  1.72 |    0.03 |  83.9844 |      - | 1407920 B |       16.01 |
| DeserializeSTJ        | .NET 9.0  | .NET 9.0  | 1000  | 303.288 μs |  3.2030 μs |  2.9961 μs |  1.80 |    0.02 |  10.7422 |      - |  183920 B |        2.09 |
| DeserializeNewtonsoft | .NET 9.0  | .NET 9.0  | 1000  | 554.208 μs | 10.3508 μs | 12.7117 μs |  3.30 |    0.08 | 175.7813 | 0.9766 | 2943920 B |       33.48 |
