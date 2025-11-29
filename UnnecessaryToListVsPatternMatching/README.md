# Mistakenly using ToList when not necessary vs. doing the same work with pattern matching.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | Count  | Mean           | Error         | StdDev        | Ratio     | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------------- |---------- |---------- |------- |---------------:|--------------:|--------------:|----------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **WithPatternMatching** | **.NET 10.0** | **.NET 10.0** | **100**    |       **9.958 ns** |     **0.0749 ns** |     **0.0664 ns** |      **1.00** |    **0.01** |  **0.0019** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | .NET 10.0 | .NET 10.0 | 100    |     186.648 ns |     1.8258 ns |     1.6185 ns |     18.74 |    0.20 |  0.1552 |       - |       - |    2600 B |       81.25 |
|                     |           |           |        |                |               |               |           |         |         |         |         |           |             |
| WithPatternMatching | .NET 9.0  | .NET 9.0  | 100    |       9.963 ns |     0.0904 ns |     0.0845 ns |      1.00 |    0.01 |  0.0019 |       - |       - |      32 B |        1.00 |
| WithMultipleToLists | .NET 9.0  | .NET 9.0  | 100    |     193.156 ns |     2.2295 ns |     2.0855 ns |     19.39 |    0.26 |  0.1552 |       - |       - |    2600 B |       81.25 |
|                     |           |           |        |                |               |               |           |         |         |         |         |           |             |
| **WithPatternMatching** | **.NET 10.0** | **.NET 10.0** | **100000** |      **10.006 ns** |     **0.1064 ns** |     **0.0995 ns** |      **1.00** |    **0.01** |  **0.0019** |       **-** |       **-** |      **32 B** |        **1.00** |
| WithMultipleToLists | .NET 10.0 | .NET 10.0 | 100000 | 359,636.084 ns | 7,128.5980 ns | 6,668.0950 ns | 35,944.01 |  730.88 | 81.0547 | 81.0547 | 81.0547 | 2400735 B |   75,022.97 |
|                     |           |           |        |                |               |               |           |         |         |         |         |           |             |
| WithPatternMatching | .NET 9.0  | .NET 9.0  | 100000 |       9.943 ns |     0.0458 ns |     0.0406 ns |      1.00 |    0.01 |  0.0019 |       - |       - |      32 B |        1.00 |
| WithMultipleToLists | .NET 9.0  | .NET 9.0  | 100000 | 356,823.854 ns | 6,284.8773 ns | 5,878.8781 ns | 35,887.98 |  589.85 | 77.1484 | 77.1484 | 77.1484 | 2400679 B |   75,021.22 |
