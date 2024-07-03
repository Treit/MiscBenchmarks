# Traditional Regex vs. Source Generated Regex


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26249.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.5.24307.3
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Count  | Mean            | Error         | StdDev        | Median          | Gen0      | Allocated   |
|----------------------------- |------- |----------------:|--------------:|--------------:|----------------:|----------:|------------:|
| **FindTokenUsingRegex**          | **10**     |        **52.59 μs** |      **0.992 μs** |      **0.974 μs** |        **52.53 μs** |    **0.6104** |     **2.73 KB** |
| FindTokenUsingCompiledRegex  | 10     |        16.04 μs |      0.583 μs |      1.674 μs |        15.33 μs |    0.6409 |     2.73 KB |
| FindTokenUsingSourceGenRegex | 10     |        15.33 μs |      0.402 μs |      1.139 μs |        15.05 μs |    0.6409 |     2.73 KB |
| **FindTokenUsingRegex**          | **100000** | **1,102,185.25 μs** | **26,203.946 μs** | **72,173.278 μs** | **1,066,261.10 μs** | **6000.0000** | **27345.19 KB** |
| FindTokenUsingCompiledRegex  | 100000 |   185,190.69 μs | 11,301.220 μs | 32,059.681 μs |   169,916.10 μs | 6000.0000 | 27345.39 KB |
| FindTokenUsingSourceGenRegex | 100000 |   165,507.66 μs |  5,754.399 μs | 15,752.575 μs |   157,902.03 μs | 6333.3333 |  27345.3 KB |
