# Mistakenly using ToList when not necessary vs. doing the same work with pattern matching.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method              | Count  | Mean          | Error        | StdDev        | Ratio     | RatioSD  | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------------- |------- |--------------:|-------------:|--------------:|----------:|---------:|--------:|--------:|--------:|----------:|------------:|
| **WithPatternMatching** | **100**    |      **12.33 ns** |     **0.236 ns** |      **0.221 ns** |      **1.00** |     **0.00** |  **0.0025** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | 100    |     158.59 ns |     2.926 ns |      2.737 ns |     12.87 |     0.38 |  0.2072 |       - |       - |    2600 B |       81.25 |
|                     |        |               |              |               |           |          |         |         |         |           |             |
| **WithPatternMatching** | **100000** |      **12.32 ns** |     **0.188 ns** |      **0.167 ns** |      **1.00** |     **0.00** |  **0.0025** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | 100000 | 307,651.23 ns | 6,145.813 ns | 15,973.785 ns | 25,291.63 | 1,560.22 | 95.2148 | 95.2148 | 95.2148 | 2400862 B |   75,026.94 |
