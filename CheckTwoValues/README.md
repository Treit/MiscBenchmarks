# Checking if something is one of two values. Yes, the hash table check really was found in production code.





``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method |                Value |       Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------------------- |-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
|        **CheckWithSimpleIf** |            **gibberish** |  **0.4588 ns** | **0.0124 ns** | **0.0110 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern |            gibberish |  0.2769 ns | 0.0056 ns | 0.0053 ns |   0.60 |    0.02 |      - |         - |          NA |
|   CheckWithStaticHashSet |            gibberish |  9.8964 ns | 0.0471 ns | 0.0393 ns |  21.67 |    0.41 |      - |         - |          NA |
|      CheckWithNewHashSet |            gibberish | 61.4774 ns | 0.6727 ns | 0.6292 ns | 134.15 |    3.48 | 0.0105 |     176 B |          NA |
|                          |                      |            |           |           |        |         |        |           |             |
|        **CheckWithSimpleIf** |               **needle** |  **0.3960 ns** | **0.0134 ns** | **0.0119 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern |               needle |  1.7391 ns | 0.0184 ns | 0.0172 ns |   4.40 |    0.14 |      - |         - |          NA |
|   CheckWithStaticHashSet |               needle | 10.6005 ns | 0.0485 ns | 0.0430 ns |  26.79 |    0.77 |      - |         - |          NA |
|      CheckWithNewHashSet |               needle | 62.3975 ns | 0.5126 ns | 0.4795 ns | 157.73 |    4.92 | 0.0105 |     176 B |          NA |
|                          |                      |            |           |           |        |         |        |           |             |
|        **CheckWithSimpleIf** |  **needle_in_a_haystac** |  **0.4815 ns** | **0.0110 ns** | **0.0103 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern |  needle_in_a_haystac |  0.2744 ns | 0.0060 ns | 0.0054 ns |   0.57 |    0.01 |      - |         - |          NA |
|   CheckWithStaticHashSet |  needle_in_a_haystac | 13.3769 ns | 0.0218 ns | 0.0204 ns |  27.79 |    0.61 |      - |         - |          NA |
|      CheckWithNewHashSet |  needle_in_a_haystac | 64.9106 ns | 0.3347 ns | 0.2967 ns | 135.21 |    2.87 | 0.0105 |     176 B |          NA |
|                          |                      |            |           |           |        |         |        |           |             |
|        **CheckWithSimpleIf** | **needle_in_a_haystack** |  **1.2381 ns** | **0.0166 ns** | **0.0139 ns** |   **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| CheckWithCharListPattern | needle_in_a_haystack |  5.9314 ns | 0.0074 ns | 0.0061 ns |   4.79 |    0.06 |      - |         - |          NA |
|   CheckWithStaticHashSet | needle_in_a_haystack | 14.9253 ns | 0.0252 ns | 0.0224 ns |  12.06 |    0.13 |      - |         - |          NA |
|      CheckWithNewHashSet | needle_in_a_haystack | 64.6829 ns | 0.3124 ns | 0.2439 ns |  52.32 |    0.59 | 0.0105 |     176 B |          NA |
