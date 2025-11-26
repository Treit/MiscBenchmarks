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
| **CheckWithNewHashSet**         | **gibberish**            | **70.6883 ns** | **0.4796 ns** | **0.4005 ns** | **139.75** |    **3.33** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | gibberish            | 15.4321 ns | 0.1384 ns | 0.1295 ns |  30.51 |    0.75 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | gibberish            |  0.5061 ns | 0.0130 ns | 0.0122 ns |   1.00 |    0.03 |      - |         - |          NA |
| CheckWithCharListPattern    | gibberish            |  0.2602 ns | 0.0178 ns | 0.0166 ns |   0.51 |    0.03 |      - |         - |          NA |
| CheckWithSearchValues       | gibberish            | 13.0721 ns | 0.1206 ns | 0.1128 ns |  25.84 |    0.64 |      - |         - |          NA |
|                             |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle**               | **71.2046 ns** | **1.1755 ns** | **1.0996 ns** | **414.82** |   **32.74** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle               | 12.4103 ns | 0.0507 ns | 0.0450 ns |  72.30 |    5.61 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle               |  0.1727 ns | 0.0151 ns | 0.0141 ns |   1.01 |    0.11 |      - |         - |          NA |
| CheckWithCharListPattern    | needle               |  1.6234 ns | 0.0044 ns | 0.0039 ns |   9.46 |    0.73 |      - |         - |          NA |
| CheckWithSearchValues       | needle               | 11.4495 ns | 0.0369 ns | 0.0308 ns |  66.70 |    5.17 |      - |         - |          NA |
|                             |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystac**  | **79.1714 ns** | **0.6457 ns** | **0.5392 ns** | **150.14** |    **6.30** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystac  | 21.5480 ns | 0.1198 ns | 0.1121 ns |  40.86 |    1.71 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystac  |  0.5282 ns | 0.0238 ns | 0.0223 ns |   1.00 |    0.06 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystac  |  0.2753 ns | 0.0165 ns | 0.0147 ns |   0.52 |    0.03 |      - |         - |          NA |
| CheckWithSearchValues       | needle_in_a_haystac  | 20.8805 ns | 0.1211 ns | 0.1133 ns |  39.60 |    1.65 |      - |         - |          NA |
|                             |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystack** | **80.1022 ns** | **1.0197 ns** | **0.9538 ns** | **167.87** |    **7.57** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystack | 23.5237 ns | 0.1114 ns | 0.1042 ns |  49.30 |    2.16 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystack |  0.4781 ns | 0.0231 ns | 0.0216 ns |   1.00 |    0.06 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystack |  5.9303 ns | 0.0559 ns | 0.0523 ns |  12.43 |    0.55 |      - |         - |          NA |
| CheckWithSearchValues       | needle_in_a_haystack | 21.1597 ns | 0.1131 ns | 0.1003 ns |  44.34 |    1.94 |      - |         - |          NA |
