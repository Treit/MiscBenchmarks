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
| **WithPatternMatching** | **100**    |      **10.04 ns** |     **0.090 ns** |     **0.084 ns** |      **1.00** |    **0.01** |  **0.0019** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | 100    |     192.22 ns |     3.667 ns |     3.601 ns |     19.15 |    0.38 |  0.1552 |       - |       - |    2600 B |       81.25 |
|                     |        |               |              |              |           |         |         |         |         |           |             |
| **WithPatternMatching** | **100000** |      **10.10 ns** |     **0.111 ns** |     **0.104 ns** |      **1.00** |    **0.01** |  **0.0019** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | 100000 | 397,669.94 ns | 7,567.267 ns | 8,714.476 ns | 39,357.64 |  927.29 | 85.4492 | 85.4492 | 85.4492 | 2400751 B |   75,023.47 |
