# Checking if something is one of two values. Yes, the hash table check really was found in production code.






```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27754.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Value                | Mean       | Error     | StdDev    | Median     | Ratio   | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |--------------------- |-----------:|----------:|----------:|-----------:|--------:|--------:|-------:|----------:|------------:|
| **CheckWithNewHashSet**         | **gibberish**            | **82.0623 ns** | **1.6412 ns** | **2.2465 ns** | **81.6307 ns** |   **93.09** |    **8.71** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | gibberish            | 11.0726 ns | 0.2556 ns | 0.4801 ns | 10.9413 ns |   12.79 |    1.37 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | gibberish            |  0.8750 ns | 0.0519 ns | 0.0777 ns |  0.8584 ns |    1.00 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | gibberish            |  0.0580 ns | 0.0318 ns | 0.0816 ns |  0.0192 ns |    0.05 |    0.06 |      - |         - |          NA |
|                             |                      |            |           |           |            |         |         |        |           |             |
| **CheckWithNewHashSet**         | **needle**               | **85.1042 ns** | **1.6760 ns** | **4.3561 ns** | **84.0271 ns** |  **184.79** |   **38.16** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle               | 13.0004 ns | 0.2828 ns | 0.7199 ns | 12.7989 ns |   28.18 |    6.02 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle               |  0.4827 ns | 0.0442 ns | 0.1140 ns |  0.4511 ns |    1.00 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | needle               |  3.5680 ns | 0.0716 ns | 0.0634 ns |  3.5653 ns |    8.66 |    1.54 |      - |         - |          NA |
|                             |                      |            |           |           |            |         |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystac**  | **86.0382 ns** | **1.3698 ns** | **1.1438 ns** | **86.0972 ns** | **113.529** |    **9.97** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystac  | 16.0744 ns | 0.3255 ns | 0.3749 ns | 16.0100 ns |  21.797 |    1.91 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystac  |  0.7402 ns | 0.0444 ns | 0.0691 ns |  0.7147 ns |   1.000 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystac  |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |   0.000 |    0.00 |      - |         - |          NA |
|                             |                      |            |           |           |            |         |         |        |           |             |
| **CheckWithNewHashSet**         | **needle_in_a_haystack** | **87.3754 ns** | **1.5759 ns** | **1.6862 ns** | **86.9515 ns** |   **91.20** |    **5.10** | **0.0408** |     **176 B** |          **NA** |
| CheckWithStaticHashSet      | needle_in_a_haystack | 17.2700 ns | 0.4005 ns | 1.1492 ns | 16.9190 ns |   18.78 |    2.10 |      - |         - |          NA |
| CheckWithSimpleEqualityTest | needle_in_a_haystack |  0.9609 ns | 0.0569 ns | 0.0584 ns |  0.9494 ns |    1.00 |    0.00 |      - |         - |          NA |
| CheckWithCharListPattern    | needle_in_a_haystack | 11.2410 ns | 0.2101 ns | 0.1640 ns | 11.2854 ns |   11.68 |    0.74 |      - |         - |          NA |
