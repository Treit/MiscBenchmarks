# Regex parsing vs string.Split, as well as other techniques like using Span<T>.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                            Method |  Count |             Mean |           Error |          StdDev | Ratio | RatioSD |      Gen0 |  Allocated | Alloc Ratio |
|---------------------------------- |------- |-----------------:|----------------:|----------------:|------:|--------:|----------:|-----------:|------------:|
|               **FindTokenUsingSplit** |     **10** |       **2,227.0 ns** |        **13.69 ns** |        **11.43 ns** |  **1.00** |    **0.00** |    **0.2480** |     **4200 B** |        **1.00** |
|               FindTokenUsingRegex |     10 |      39,500.8 ns |       610.84 ns |       571.38 ns | 17.73 |    0.29 |    0.1221 |     2792 B |        0.66 |
|       FindTokenUsingCompiledRegex |     10 |      10,608.4 ns |        17.49 ns |        15.51 ns |  4.76 |    0.03 |    0.1526 |     2792 B |        0.66 |
|                FindTokenUsingSpan |     10 |         150.6 ns |         1.16 ns |         0.97 ns |  0.07 |    0.00 |         - |          - |        0.00 |
|            FindTokenUsingTokenize |     10 |         430.3 ns |         0.54 ns |         0.48 ns |  0.19 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach |     10 |         461.5 ns |         0.46 ns |         0.41 ns |  0.21 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
|               **FindTokenUsingSplit** |    **100** |      **23,016.0 ns** |       **108.71 ns** |        **96.37 ns** |  **1.00** |    **0.00** |    **2.7466** |    **45960 B** |        **1.00** |
|               FindTokenUsingRegex |    100 |     409,428.7 ns |     1,498.76 ns |     1,328.62 ns | 17.79 |    0.11 |    1.4648 |    27993 B |        0.61 |
|       FindTokenUsingCompiledRegex |    100 |     106,304.9 ns |       230.15 ns |       215.28 ns |  4.62 |    0.02 |    1.5869 |    27992 B |        0.61 |
|                FindTokenUsingSpan |    100 |       1,771.8 ns |        19.96 ns |        17.70 ns |  0.08 |    0.00 |         - |          - |        0.00 |
|            FindTokenUsingTokenize |    100 |       4,243.1 ns |        12.36 ns |        10.32 ns |  0.18 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach |    100 |       4,537.1 ns |        20.87 ns |        19.52 ns |  0.20 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
|               **FindTokenUsingSplit** |   **1000** |     **229,036.7 ns** |       **832.17 ns** |       **778.41 ns** |  **1.00** |    **0.00** |   **27.5879** |   **463560 B** |        **1.00** |
|               FindTokenUsingRegex |   1000 |   5,146,801.1 ns |    42,808.58 ns |    40,043.17 ns | 22.47 |    0.21 |   15.6250 |   280010 B |        0.60 |
|       FindTokenUsingCompiledRegex |   1000 |   1,129,532.7 ns |     4,899.91 ns |     4,343.64 ns |  4.93 |    0.02 |   15.6250 |   279997 B |        0.60 |
|                FindTokenUsingSpan |   1000 |      24,058.3 ns |       469.49 ns |       461.10 ns |  0.11 |    0.00 |         - |          - |        0.00 |
|            FindTokenUsingTokenize |   1000 |      40,000.1 ns |        53.49 ns |        47.41 ns |  0.17 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach |   1000 |      42,403.5 ns |        23.98 ns |        20.02 ns |  0.19 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
|               **FindTokenUsingSplit** | **100000** |  **23,716,859.6 ns** |   **145,737.99 ns** |   **129,192.93 ns** |  **1.00** |    **0.00** | **2750.0000** | **46400012 B** |        **1.00** |
|               FindTokenUsingRegex | 100000 | 768,213,392.3 ns | 3,249,777.18 ns | 2,713,711.13 ns | 32.40 |    0.22 | 1000.0000 | 28001184 B |        0.60 |
|       FindTokenUsingCompiledRegex | 100000 | 112,211,380.0 ns |   204,135.60 ns |   159,375.65 ns |  4.73 |    0.03 | 1600.0000 | 28000557 B |        0.60 |
|                FindTokenUsingSpan | 100000 |   3,600,008.5 ns |    12,444.37 ns |    11,031.61 ns |  0.15 |    0.00 |         - |          - |        0.00 |
|            FindTokenUsingTokenize | 100000 |   3,652,844.8 ns |     2,127.24 ns |     1,885.75 ns |  0.15 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 100000 |   3,940,674.4 ns |     7,334.01 ns |     6,124.23 ns |  0.17 |    0.00 |         - |          - |        0.00 |
