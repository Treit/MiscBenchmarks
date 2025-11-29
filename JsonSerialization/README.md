# Serializing and deserializng JSON







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Job       | Runtime   | Count | Mean       | Error      | StdDev     | Ratio | RatioSD | Gen0     | Gen1   | Allocated  | Alloc Ratio |
|--------------------------------------------------- |---------- |---------- |------ |-----------:|-----------:|-----------:|------:|--------:|---------:|-------:|-----------:|------------:|
| **SerializeAndDeserializeSTJ**                         | **.NET 10.0** | **.NET 10.0** | **10**    |   **4.799 μs** |  **0.0541 μs** |  **0.0422 μs** |  **1.00** |    **0.01** |   **0.1526** |      **-** |     **2.5 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | .NET 10.0 | .NET 10.0 | 10    |   5.039 μs |  0.0332 μs |  0.0277 μs |  1.05 |    0.01 |   0.1526 |      - |     2.5 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | .NET 10.0 | .NET 10.0 | 10    |   5.327 μs |  0.0490 μs |  0.0435 μs |  1.11 |    0.01 |   0.1373 |      - |    2.27 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | .NET 10.0 | .NET 10.0 | 10    |   5.581 μs |  0.1086 μs |  0.0907 μs |  1.16 |    0.02 |   0.1526 |      - |     2.7 KB |        1.08 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | .NET 10.0 | .NET 10.0 | 10    |   5.521 μs |  0.0484 μs |  0.0429 μs |  1.15 |    0.01 |   0.1450 |      - |    2.46 KB |        0.98 |
| SerializeAndDeserializeNewtonsoft                  | .NET 10.0 | .NET 10.0 | 10    |   8.513 μs |  0.0891 μs |  0.0744 μs |  1.77 |    0.02 |   2.5787 | 0.0153 |   42.34 KB |       16.93 |
|                                                    |           |           |       |            |            |            |       |         |          |        |            |             |
| SerializeAndDeserializeSTJ                         | .NET 9.0  | .NET 9.0  | 10    |   5.093 μs |  0.0561 μs |  0.0497 μs |  1.00 |    0.01 |   0.1526 |      - |     2.5 KB |        1.00 |
| SerializeAndDeserializeSTJCachedOptions            | .NET 9.0  | .NET 9.0  | 10    |   5.130 μs |  0.0812 μs |  0.0902 μs |  1.01 |    0.02 |   0.1526 |      - |     2.5 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | .NET 9.0  | .NET 9.0  | 10    |   5.290 μs |  0.0413 μs |  0.0345 μs |  1.04 |    0.01 |   0.1373 |      - |    2.27 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | .NET 9.0  | .NET 9.0  | 10    |   5.854 μs |  0.0859 μs |  0.0761 μs |  1.15 |    0.02 |   0.1526 |      - |     2.7 KB |        1.08 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | .NET 9.0  | .NET 9.0  | 10    |   5.450 μs |  0.0481 μs |  0.0426 μs |  1.07 |    0.01 |   0.1450 | 0.0076 |    2.46 KB |        0.98 |
| SerializeAndDeserializeNewtonsoft                  | .NET 9.0  | .NET 9.0  | 10    |   8.575 μs |  0.0799 μs |  0.0709 μs |  1.68 |    0.02 |   2.5787 | 0.0153 |   42.34 KB |       16.94 |
|                                                    |           |           |       |            |            |            |       |         |          |        |            |             |
| **SerializeAndDeserializeSTJ**                         | **.NET 10.0** | **.NET 10.0** | **1000**  | **521.550 μs** |  **6.1818 μs** |  **5.7825 μs** |  **1.00** |    **0.02** |  **15.6250** |      **-** |  **265.48 KB** |        **1.00** |
| SerializeAndDeserializeSTJCachedOptions            | .NET 10.0 | .NET 10.0 | 1000  | 527.137 μs |  4.1836 μs |  3.4935 μs |  1.01 |    0.01 |  15.6250 |      - |  265.48 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | .NET 10.0 | .NET 10.0 | 1000  | 507.385 μs |  6.1294 μs |  5.7334 μs |  0.97 |    0.01 |  14.6484 |      - |  242.05 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | .NET 10.0 | .NET 10.0 | 1000  | 532.128 μs | 10.4449 μs | 13.9436 μs |  1.02 |    0.03 |  15.6250 |      - |  265.86 KB |        1.00 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | .NET 10.0 | .NET 10.0 | 1000  | 511.368 μs |  5.0219 μs |  4.6975 μs |  0.98 |    0.01 |  14.6484 |      - |  242.24 KB |        0.91 |
| SerializeAndDeserializeNewtonsoft                  | .NET 10.0 | .NET 10.0 | 1000  | 879.869 μs | 13.1312 μs | 10.9652 μs |  1.69 |    0.03 | 259.7656 | 0.9766 | 4249.84 KB |       16.01 |
|                                                    |           |           |       |            |            |            |       |         |          |        |            |             |
| SerializeAndDeserializeSTJ                         | .NET 9.0  | .NET 9.0  | 1000  | 523.260 μs |  3.3550 μs |  2.8015 μs |  1.00 |    0.01 |  15.6250 |      - |  265.53 KB |        1.00 |
| SerializeAndDeserializeSTJCachedOptions            | .NET 9.0  | .NET 9.0  | 1000  | 508.932 μs |  6.1175 μs |  5.7223 μs |  0.97 |    0.01 |  15.6250 |      - |  265.48 KB |        1.00 |
| SerializeAndDeserializeSTJSourceGen                | .NET 9.0  | .NET 9.0  | 1000  | 533.946 μs |  4.5757 μs |  4.2801 μs |  1.02 |    0.01 |  14.6484 |      - |  242.05 KB |        0.91 |
| SerializeAndDeserializeSTJCaseInsensitive          | .NET 9.0  | .NET 9.0  | 1000  | 513.457 μs | 10.2334 μs | 13.3064 μs |  0.98 |    0.03 |  15.6250 |      - |  265.78 KB |        1.00 |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen | .NET 9.0  | .NET 9.0  | 1000  | 510.541 μs |  8.0864 μs |  7.5640 μs |  0.98 |    0.01 |  14.6484 |      - |  242.24 KB |        0.91 |
| SerializeAndDeserializeNewtonsoft                  | .NET 9.0  | .NET 9.0  | 1000  | 868.869 μs | 11.3646 μs | 10.6304 μs |  1.66 |    0.02 | 259.7656 | 0.9766 | 4249.84 KB |       16.01 |
