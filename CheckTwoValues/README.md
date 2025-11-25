# Checking if something is one of two values. Yes, the hash table check really was found in production code.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Value                | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |--------------------- |-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| **CheckWithNewHashSet**         | **gibberish**            | **69.5894 ns** | **0.7675 ns** | **0.7179 ns** | **135.05** |    **5.77** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | gibberish            | 14.7327 ns | 0.1743 ns | 0.1630 ns |  28.59 |    1.23 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | gibberish            |  0.5162 ns | 0.0240 ns | 0.0225 ns |   1.00 |    0.06 |      - |         - |          NA |
| CheckWithCharListPattern    | gibberish            |  0.2578 ns | 0.0150 ns | 0.0133 ns |   0.50 |    0.03 |      - |         - |          NA |
| CheckWithSearchValues       | gibberish            | 13.0733 ns | 0.0349 ns | 0.0309 ns |  25.37 |    1.06 |      - |         - |          NA |
|                             |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle**               | **71.2918 ns** | **0.6938 ns** | **0.6490 ns** | **399.32** |   **33.24** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle               | 12.4283 ns | 0.0910 ns | 0.0760 ns |  69.61 |    5.78 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle               |  0.1797 ns | 0.0159 ns | 0.0148 ns |   1.01 |    0.12 |      - |         - |          NA |
| CheckWithCharListPattern    | needle               |  1.6316 ns | 0.0144 ns | 0.0128 ns |   9.14 |    0.76 |      - |         - |          NA |
| CheckWithSearchValues       | needle               | 11.4908 ns | 0.0535 ns | 0.0447 ns |  64.36 |    5.33 |      - |         - |          NA |
|                             |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystac**  | **79.7835 ns** | **0.5494 ns** | **0.4870 ns** | **151.04** |    **5.55** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystac  | 21.3334 ns | 0.1516 ns | 0.1418 ns |  40.39 |    1.49 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystac  |  0.5289 ns | 0.0223 ns | 0.0198 ns |   1.00 |    0.05 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystac  |  0.2683 ns | 0.0243 ns | 0.0227 ns |   0.51 |    0.05 |      - |         - |          NA |
| CheckWithSearchValues       | needle_in_a_haystac  | 20.8435 ns | 0.1302 ns | 0.1218 ns |  39.46 |    1.45 |      - |         - |          NA |
|                             |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystack** | **81.9705 ns** | **0.7665 ns** | **0.7170 ns** | **169.99** |    **9.02** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystack | 23.4603 ns | 0.1510 ns | 0.1338 ns |  48.65 |    2.56 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystack |  0.4835 ns | 0.0277 ns | 0.0259 ns |   1.00 |    0.07 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystack |  5.9546 ns | 0.0749 ns | 0.0701 ns |  12.35 |    0.66 |      - |         - |          NA |
| CheckWithSearchValues       | needle_in_a_haystack | 20.1473 ns | 0.2755 ns | 0.2577 ns |  41.78 |    2.25 |      - |         - |          NA |
