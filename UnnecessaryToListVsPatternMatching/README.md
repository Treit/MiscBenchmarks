# Mistakenly using ToList when not necessary vs. doing the same work with pattern matching.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Count  | Mean          | Error        | StdDev       | Ratio     | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------------- |------- |--------------:|-------------:|-------------:|----------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **WithPatternMatching** | **100**    |      **10.38 ns** |     **0.077 ns** |     **0.069 ns** |      **1.00** |    **0.01** |  **0.0019** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | 100    |     192.80 ns |     2.903 ns |     2.715 ns |     18.58 |    0.28 |  0.1552 |       - |       - |    2600 B |       81.25 |
|                     |        |               |              |              |           |         |         |         |         |           |             |
| **WithPatternMatching** | **100000** |      **10.69 ns** |     **0.093 ns** |     **0.087 ns** |      **1.00** |    **0.01** |  **0.0019** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | 100000 | 373,683.94 ns | 6,861.021 ns | 6,417.803 ns | 34,973.50 |  642.37 | 77.1484 | 77.1484 | 77.1484 | 2400669 B |   75,020.91 |
