# Serializing and deserializng JSON






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Count | Mean       | Error      | StdDev     | Ratio | RatioSD | Gen0     | Gen1   | Allocated  | Alloc Ratio |
|--------------------------------------------------- |------ |-----------:|-----------:|-----------:|------:|--------:|---------:|-------:|-----------:|------------:|
| **SerializeAndDeserializeSTJ**                         | **10**    |   **5.019 μs** |  **0.0498 μs** |  **0.0466 μs** |  **1.00** |    **0.01** |   **0.1526** |      **-** |     **2.5 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | 10    |   5.023 μs |  0.0400 μs |  0.0355 μs |  1.00 |    0.01 |   0.1526 |      - |     2.5 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | 10    |   4.925 μs |  0.0574 μs |  0.0509 μs |  0.98 |    0.01 |   0.1373 |      - |    2.27 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | 10    |   5.396 μs |  0.1077 μs |  0.1322 μs |  1.08 |    0.03 |   0.1526 |      - |     2.7 KB |        1.08 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | 10    |   5.521 μs |  0.0604 μs |  0.0504 μs |  1.10 |    0.01 |   0.1450 |      - |    2.46 KB |        0.98 |
| SerializeAndDeserializeNewtonsoft                  | 10    |   9.034 μs |  0.0959 μs |  0.0897 μs |  1.80 |    0.02 |   2.5787 | 0.0153 |   42.34 KB |       16.94 |
|                                                    |       |            |            |            |       |         |          |        |            |             |
| **SerializeAndDeserializeSTJ**                         | **1000**  | **499.364 μs** |  **5.5501 μs** |  **5.1916 μs** |  **1.00** |    **0.01** |  **15.6250** |      **-** |  **265.47 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | 1000  | 498.330 μs |  5.0326 μs |  4.7075 μs |  1.00 |    0.01 |  15.6250 |      - |  265.47 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | 1000  | 512.229 μs |  8.5994 μs |  8.0439 μs |  1.03 |    0.02 |  14.6484 |      - |  242.03 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | 1000  | 520.901 μs |  9.0308 μs |  8.4474 μs |  1.04 |    0.02 |  15.6250 |      - |  265.72 KB |        1.00 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | 1000  | 499.578 μs |  4.6303 μs |  4.3312 μs |  1.00 |    0.01 |  14.6484 |      - |  242.22 KB |        0.91 |
| SerializeAndDeserializeNewtonsoft                  | 1000  | 896.279 μs | 12.1077 μs | 11.3255 μs |  1.80 |    0.03 | 259.7656 | 0.9766 | 4249.84 KB |       16.01 |
