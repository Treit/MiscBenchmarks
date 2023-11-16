# Checking if something is one of two values. Yes, the hash table check really was found in production code.




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25997.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|                   Method |                Value |       Mean |     Error |    StdDev |     Median |  Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------------------- |-----------:|----------:|----------:|-----------:|-------:|--------:|-------:|----------:|------------:|
|        **CheckWithSimpleIf** |            **gibberish** |  **0.6532 ns** | **0.0340 ns** | **0.0266 ns** |  **0.6518 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern |            gibberish |  0.3046 ns | 0.0169 ns | 0.0158 ns |  0.3062 ns |   0.47 |    0.03 |      - |         - |          NA |
|   CheckWithStaticHashSet |            gibberish | 10.4957 ns | 0.2209 ns | 0.1845 ns | 10.5383 ns |  16.08 |    0.85 |      - |         - |          NA |
|      CheckWithNewHashSet |            gibberish | 76.9391 ns | 1.5074 ns | 1.4100 ns | 76.1646 ns | 118.36 |    5.09 | 0.0408 |     176 B |          NA |
|                          |                      |            |           |           |            |        |         |        |           |             |
|        **CheckWithSimpleIf** |               **needle** |  **0.9976 ns** | **0.0548 ns** | **0.0631 ns** |  **0.9908 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern |               needle |  2.2072 ns | 0.0755 ns | 0.0669 ns |  2.2091 ns |   2.20 |    0.19 |      - |         - |          NA |
|   CheckWithStaticHashSet |               needle | 12.1817 ns | 0.2225 ns | 0.1972 ns | 12.1696 ns |  12.14 |    0.80 |      - |         - |          NA |
|      CheckWithNewHashSet |               needle | 85.1311 ns | 1.7377 ns | 4.1967 ns | 83.5813 ns |  87.12 |    5.98 | 0.0408 |     176 B |          NA |
|                          |                      |            |           |           |            |        |         |        |           |             |
|        **CheckWithSimpleIf** |  **needle_in_a_haystac** |  **0.5814 ns** | **0.0285 ns** | **0.0317 ns** |  **0.5795 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern |  needle_in_a_haystac |  0.4117 ns | 0.0419 ns | 0.0574 ns |  0.4086 ns |   0.73 |    0.12 |      - |         - |          NA |
|   CheckWithStaticHashSet |  needle_in_a_haystac | 15.1826 ns | 0.3367 ns | 0.5039 ns | 14.9684 ns |  26.46 |    1.27 |      - |         - |          NA |
|      CheckWithNewHashSet |  needle_in_a_haystac | 87.1848 ns | 1.7446 ns | 3.4027 ns | 86.7198 ns | 152.66 |    9.14 | 0.0408 |     176 B |          NA |
|                          |                      |            |           |           |            |        |         |        |           |             |
|        **CheckWithSimpleIf** | **needle_in_a_haystack** |  **0.9087 ns** | **0.0261 ns** | **0.0231 ns** |  **0.9111 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern | needle_in_a_haystack |  7.8383 ns | 0.1887 ns | 0.1938 ns |  7.8256 ns |   8.60 |    0.28 |      - |         - |          NA |
|   CheckWithStaticHashSet | needle_in_a_haystack | 17.7719 ns | 0.2791 ns | 0.2611 ns | 17.6873 ns |  19.58 |    0.57 |      - |         - |          NA |
|      CheckWithNewHashSet | needle_in_a_haystack | 85.6614 ns | 1.1698 ns | 1.0370 ns | 85.6810 ns |  94.33 |    2.87 | 0.0408 |     176 B |          NA |
