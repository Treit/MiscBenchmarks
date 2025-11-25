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
| **WhereDotCount**      | **10**    |     **35.262 ns** |   **0.4247 ns** |   **0.3972 ns** |  **6.31** |    **0.07** | **0.0029** |      **48 B** |          **NA** |
| CountWithPredicate | 10    |      5.590 ns |   0.0160 ns |   0.0134 ns |  1.00 |    0.00 |      - |         - |          NA |
|                    |       |               |             |             |       |         |        |           |             |
| **WhereDotCount**      | **10000** | **22,330.229 ns** | **141.0275 ns** | **131.9172 ns** |  **3.49** |    **0.03** |      **-** |      **48 B** |          **NA** |
| CountWithPredicate | 10000 |  6,401.794 ns |  38.3455 ns |  35.8684 ns |  1.00 |    0.01 |      - |         - |          NA |
