# Calling the Count() overload that takes a predicate vs. calling .Where().Count()





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Job       | Runtime   | Count | Mean          | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **WhereDotCount**      | **.NET 10.0** | **.NET 10.0** | **10**    |     **35.475 ns** |  **0.3282 ns** |  **0.3070 ns** |  **6.40** |    **0.05** | **0.0029** |      **48 B** |          **NA** |
| CountWithPredicate | .NET 10.0 | .NET 10.0 | 10    |      5.544 ns |  0.0090 ns |  0.0075 ns |  1.00 |    0.00 |      - |         - |          NA |
|                    |           |           |       |               |            |            |       |         |        |           |             |
| WhereDotCount      | .NET 9.0  | .NET 9.0  | 10    |     35.160 ns |  0.2354 ns |  0.2202 ns |  6.33 |    0.04 | 0.0029 |      48 B |          NA |
| CountWithPredicate | .NET 9.0  | .NET 9.0  | 10    |      5.550 ns |  0.0227 ns |  0.0190 ns |  1.00 |    0.00 |      - |         - |          NA |
|                    |           |           |       |               |            |            |       |         |        |           |             |
| **WhereDotCount**      | **.NET 10.0** | **.NET 10.0** | **10000** | **22,263.800 ns** | **55.7095 ns** | **49.3850 ns** |  **3.52** |    **0.01** |      **-** |      **48 B** |          **NA** |
| CountWithPredicate | .NET 10.0 | .NET 10.0 | 10000 |  6,326.272 ns | 10.8403 ns |  9.0522 ns |  1.00 |    0.00 |      - |         - |          NA |
|                    |           |           |       |               |            |            |       |         |        |           |             |
| WhereDotCount      | .NET 9.0  | .NET 9.0  | 10000 | 19,197.654 ns | 52.0039 ns | 46.1001 ns |  3.03 |    0.01 |      - |      48 B |          NA |
| CountWithPredicate | .NET 9.0  | .NET 9.0  | 10000 |  6,343.558 ns | 13.3357 ns | 11.8217 ns |  1.00 |    0.00 |      - |         - |          NA |
