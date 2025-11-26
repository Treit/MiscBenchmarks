# Calling the Count() overload that takes a predicate vs. calling .Where().Count()




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Count | Mean          | Error       | StdDev      | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |------ |--------------:|------------:|------------:|------:|--------:|-------:|----------:|------------:|
| **WhereDotCount**      | **10**    |     **36.007 ns** |   **0.4071 ns** |   **0.3808 ns** |  **6.75** |    **0.07** | **0.0029** |      **48 B** |          **NA** |
| CountWithPredicate | 10    |      5.334 ns |   0.0200 ns |   0.0188 ns |  1.00 |    0.00 |      - |         - |          NA |
|                    |       |               |             |             |       |         |        |           |             |
| **WhereDotCount**      | **10000** | **19,264.237 ns** | **137.6111 ns** | **128.7215 ns** |  **2.99** |    **0.03** |      **-** |      **48 B** |          **NA** |
| CountWithPredicate | 10000 |  6,435.015 ns |  48.8009 ns |  45.6484 ns |  1.00 |    0.01 |      - |         - |          NA |
