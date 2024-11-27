# Checking if something is one of two values. Yes, the hash table check really was found in production code.







```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27758.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Value                | Mean       | Error     | StdDev    | Median     | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |--------------------- |-----------:|----------:|----------:|-----------:|-------:|--------:|-------:|----------:|------------:|
| **CheckWithNewHashSet**         | **gibberish**            | **89.5225 ns** | **1.8373 ns** | **4.5070 ns** | **88.5506 ns** | **168.96** |   **16.10** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | gibberish            | 13.3259 ns | 0.2622 ns | 0.2190 ns | 13.2809 ns |  24.09 |    2.05 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | gibberish            |  0.5522 ns | 0.0452 ns | 0.0464 ns |  0.5463 ns |   1.00 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | gibberish            |  0.0175 ns | 0.0235 ns | 0.0242 ns |  0.0138 ns |   0.03 |    0.04 |      - |         - |          NA |
| CheckWithSearchValues       | gibberish            | 13.7353 ns | 0.3064 ns | 0.4586 ns | 13.5652 ns |  24.92 |    2.23 |      - |         - |          NA |
|                             |                      |            |           |           |            |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle**               | **87.7790 ns** | **0.8906 ns** | **0.7895 ns** | **87.8739 ns** | **252.39** |   **25.71** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle               | 14.5515 ns | 0.3178 ns | 0.4242 ns | 14.5624 ns |  41.97 |    4.42 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle               |  0.3516 ns | 0.0381 ns | 0.0357 ns |  0.3564 ns |   1.00 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | needle               |  3.5701 ns | 0.1054 ns | 0.1035 ns |  3.5836 ns |  10.27 |    1.16 |      - |         - |          NA |
| CheckWithSearchValues       | needle               | 14.5021 ns | 0.3219 ns | 0.8134 ns | 14.2096 ns |  42.75 |    3.55 |      - |         - |          NA |
|                             |                      |            |           |           |            |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystac**  | **92.0440 ns** | **1.8353 ns** | **1.6270 ns** | **91.6128 ns** | **153.02** |   **32.97** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystac  | 20.6174 ns | 0.4434 ns | 0.9057 ns | 20.3610 ns |  34.12 |    5.84 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystac  |  0.6172 ns | 0.0479 ns | 0.1072 ns |  0.5786 ns |   1.00 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystac  |  0.0179 ns | 0.0199 ns | 0.0204 ns |  0.0160 ns |   0.03 |    0.04 |      - |         - |          NA |
| CheckWithSearchValues       | needle_in_a_haystac  | 21.0373 ns | 0.4340 ns | 0.9618 ns | 20.7957 ns |  34.94 |    5.84 |      - |         - |          NA |
|                             |                      |            |           |           |            |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystack** | **98.0424 ns** | **1.4986 ns** | **1.4018 ns** | **98.2660 ns** |  **59.58** |    **4.10** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystack | 22.9928 ns | 0.8260 ns | 2.3298 ns | 21.8386 ns |  20.30 |    3.71 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystack |  1.1588 ns | 0.1018 ns | 0.3001 ns |  1.0083 ns |   1.00 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystack | 11.2555 ns | 0.2553 ns | 0.2507 ns | 11.2233 ns |   6.84 |    0.50 |      - |         - |          NA |
| CheckWithSearchValues       | needle_in_a_haystack | 21.9668 ns | 0.3221 ns | 0.2855 ns | 22.0060 ns |  13.33 |    0.87 |      - |         - |          NA |
