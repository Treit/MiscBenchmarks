# Serializing and deserializng JSON





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1   | Allocated  | Alloc Ratio |
|--------------------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|---------:|-------:|-----------:|------------:|
| **SerializeAndDeserializeSTJ**                         | **10**    |   **4.863 μs** | **0.0297 μs** | **0.0248 μs** |  **1.00** |    **0.01** |   **0.1526** |      **-** |     **2.5 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | 10    |   5.066 μs | 0.0373 μs | 0.0312 μs |  1.04 |    0.01 |   0.1526 |      - |     2.5 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | 10    |   5.461 μs | 0.0317 μs | 0.0248 μs |  1.12 |    0.01 |   0.1373 |      - |    2.27 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | 10    |   5.529 μs | 0.1077 μs | 0.1240 μs |  1.14 |    0.03 |   0.1526 |      - |     2.7 KB |        1.08 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | 10    |   5.374 μs | 0.0404 μs | 0.0378 μs |  1.10 |    0.01 |   0.1450 |      - |    2.46 KB |        0.98 |
| SerializeAndDeserializeNewtonsoft                  | 10    |   8.344 μs | 0.1131 μs | 0.1058 μs |  1.72 |    0.02 |   2.5787 | 0.0153 |   42.34 KB |       16.94 |
|                                                    |       |            |           |           |       |         |          |        |            |             |
| **SerializeAndDeserializeSTJ**                         | **1000**  | **491.742 μs** | **1.6550 μs** | **1.4671 μs** |  **1.00** |    **0.00** |  **16.1133** |      **-** |  **265.47 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | 1000  | 526.558 μs | 3.7891 μs | 3.5443 μs |  1.07 |    0.01 |  15.6250 |      - |  265.47 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | 1000  | 511.696 μs | 4.1461 μs | 3.4622 μs |  1.04 |    0.01 |  14.6484 |      - |  242.03 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | 1000  | 482.232 μs | 9.0502 μs | 8.0228 μs |  0.98 |    0.02 |  15.6250 |      - |  265.68 KB |        1.00 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | 1000  | 513.472 μs | 6.7137 μs | 6.2800 μs |  1.04 |    0.01 |  14.6484 |      - |  242.22 KB |        0.91 |
| SerializeAndDeserializeNewtonsoft                  | 1000  | 892.861 μs | 8.4621 μs | 7.9154 μs |  1.82 |    0.02 | 259.7656 | 0.9766 | 4249.84 KB |       16.01 |
