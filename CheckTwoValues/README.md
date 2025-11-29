# Checking if something is one of two values. Yes, the hash table check really was found in production code.










```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Value                | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |--------------------- |-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| **CheckWithNewHashSet**         | **.NET 10.0** | **.NET 10.0** | **gibberish**            | **71.5918 ns** | **1.2551 ns** | **1.1740 ns** | **133.73** |    **5.52** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | .NET 10.0 | .NET 10.0 | gibberish            | 35.4144 ns | 1.0888 ns | 3.2103 ns |  66.15 |    6.48 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 10.0 | .NET 10.0 | gibberish            |  0.5361 ns | 0.0251 ns | 0.0209 ns |   1.00 |    0.05 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 10.0 | .NET 10.0 | gibberish            |  0.2712 ns | 0.0143 ns | 0.0134 ns |   0.51 |    0.03 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 10.0 | .NET 10.0 | gibberish            | 13.1471 ns | 0.1981 ns | 0.1853 ns |  24.56 |    0.99 |      - |         - |          NA |
|                             |           |           |                      |            |           |           |        |         |        |           |             |
| CheckWithNewHashSet         | .NET 9.0  | .NET 9.0  | gibberish            | 71.8818 ns | 1.2841 ns | 1.2012 ns | 141.59 |    5.86 | 0.0105 |     176 B |          NA |
| CheckWithStaticHashSet      | .NET 9.0  | .NET 9.0  | gibberish            | 14.7169 ns | 0.1301 ns | 0.1217 ns |  28.99 |    1.13 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 9.0  | .NET 9.0  | gibberish            |  0.5084 ns | 0.0213 ns | 0.0200 ns |   1.00 |    0.05 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 9.0  | .NET 9.0  | gibberish            |  0.2866 ns | 0.0229 ns | 0.0214 ns |   0.56 |    0.05 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 9.0  | .NET 9.0  | gibberish            | 13.3617 ns | 0.1408 ns | 0.1317 ns |  26.32 |    1.03 |      - |         - |          NA |
|                             |           |           |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **.NET 10.0** | **.NET 10.0** | **needle**               | **77.3662 ns** | **0.8672 ns** | **0.8112 ns** | **480.93** |   **65.46** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | .NET 10.0 | .NET 10.0 | needle               | 12.7725 ns | 0.0855 ns | 0.0758 ns |  79.40 |   10.79 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 10.0 | .NET 10.0 | needle               |  0.1639 ns | 0.0249 ns | 0.0233 ns |   1.02 |    0.20 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 10.0 | .NET 10.0 | needle               |  1.6386 ns | 0.0347 ns | 0.0308 ns |  10.19 |    1.40 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 10.0 | .NET 10.0 | needle               | 11.4804 ns | 0.0923 ns | 0.0818 ns |  71.36 |    9.70 |      - |         - |          NA |
|                             |           |           |                      |            |           |           |        |         |        |           |             |
| CheckWithNewHashSet         | .NET 9.0  | .NET 9.0  | needle               | 70.7156 ns | 0.8760 ns | 0.8194 ns | 290.51 |   18.71 | 0.0105 |     176 B |          NA |
| CheckWithStaticHashSet      | .NET 9.0  | .NET 9.0  | needle               | 12.6249 ns | 0.0552 ns | 0.0490 ns |  51.86 |    3.30 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 9.0  | .NET 9.0  | needle               |  0.2444 ns | 0.0168 ns | 0.0158 ns |   1.00 |    0.09 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 9.0  | .NET 9.0  | needle               |  1.6756 ns | 0.0246 ns | 0.0230 ns |   6.88 |    0.45 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 9.0  | .NET 9.0  | needle               | 11.5959 ns | 0.1075 ns | 0.0953 ns |  47.64 |    3.05 |      - |         - |          NA |
|                             |           |           |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **.NET 10.0** | **.NET 10.0** | **needle_in_a_haystac**  | **80.0819 ns** | **0.3961 ns** | **0.3511 ns** | **157.38** |    **4.97** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | .NET 10.0 | .NET 10.0 | needle_in_a_haystac  | 21.3808 ns | 0.1593 ns | 0.1490 ns |  42.02 |    1.35 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 10.0 | .NET 10.0 | needle_in_a_haystac  |  0.5093 ns | 0.0185 ns | 0.0164 ns |   1.00 |    0.04 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 10.0 | .NET 10.0 | needle_in_a_haystac  |  0.2745 ns | 0.0210 ns | 0.0196 ns |   0.54 |    0.04 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 10.0 | .NET 10.0 | needle_in_a_haystac  | 20.9289 ns | 0.0648 ns | 0.0606 ns |  41.13 |    1.29 |      - |         - |          NA |
|                             |           |           |                      |            |           |           |        |         |        |           |             |
| CheckWithNewHashSet         | .NET 9.0  | .NET 9.0  | needle_in_a_haystac  | 79.8532 ns | 1.0382 ns | 0.9712 ns | 148.25 |    6.32 | 0.0105 |     176 B |          NA |
| CheckWithStaticHashSet      | .NET 9.0  | .NET 9.0  | needle_in_a_haystac  | 21.3992 ns | 0.1406 ns | 0.1315 ns |  39.73 |    1.65 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 9.0  | .NET 9.0  | needle_in_a_haystac  |  0.5395 ns | 0.0246 ns | 0.0230 ns |   1.00 |    0.06 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 9.0  | .NET 9.0  | needle_in_a_haystac  |  0.2734 ns | 0.0209 ns | 0.0195 ns |   0.51 |    0.04 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 9.0  | .NET 9.0  | needle_in_a_haystac  | 21.3034 ns | 0.1128 ns | 0.1056 ns |  39.55 |    1.63 |      - |         - |          NA |
|                             |           |           |                      |            |           |           |        |         |        |           |             |
| **CheckWithNewHashSet**         | **.NET 10.0** | **.NET 10.0** | **needle_in_a_haystack** | **80.7881 ns** | **1.2621 ns** | **1.1806 ns** | **171.96** |    **7.34** | **0.0105** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | .NET 10.0 | .NET 10.0 | needle_in_a_haystack | 23.5614 ns | 0.0891 ns | 0.0790 ns |  50.15 |    2.03 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 10.0 | .NET 10.0 | needle_in_a_haystack |  0.4706 ns | 0.0218 ns | 0.0194 ns |   1.00 |    0.06 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 10.0 | .NET 10.0 | needle_in_a_haystack |  5.9411 ns | 0.0742 ns | 0.0694 ns |  12.65 |    0.53 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 10.0 | .NET 10.0 | needle_in_a_haystack | 20.3491 ns | 0.1508 ns | 0.1411 ns |  43.31 |    1.77 |      - |         - |          NA |
|                             |           |           |                      |            |           |           |        |         |        |           |             |
| CheckWithNewHashSet         | .NET 9.0  | .NET 9.0  | needle_in_a_haystack | 80.0383 ns | 0.5015 ns | 0.4691 ns | 164.02 |    6.02 | 0.0105 |     176 B |          NA |
| CheckWithStaticHashSet      | .NET 9.0  | .NET 9.0  | needle_in_a_haystack | 23.5740 ns | 0.0819 ns | 0.0726 ns |  48.31 |    1.76 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | .NET 9.0  | .NET 9.0  | needle_in_a_haystack |  0.4886 ns | 0.0195 ns | 0.0183 ns |   1.00 |    0.05 |      - |         - |          NA |
| CheckWithCharListPattern    | .NET 9.0  | .NET 9.0  | needle_in_a_haystack |  5.9697 ns | 0.0932 ns | 0.0872 ns |  12.23 |    0.48 |      - |         - |          NA |
| CheckWithSearchValues       | .NET 9.0  | .NET 9.0  | needle_in_a_haystack | 20.0981 ns | 0.1461 ns | 0.1295 ns |  41.19 |    1.52 |      - |         - |          NA |
