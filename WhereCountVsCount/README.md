# Calling the Count() overload that takes a predicate vs. calling .Where().Count()


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27909.1000)
Unknown processor
.NET SDK 9.0.302
  [Host]     : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method             | Count | Mean        | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **WhereDotCount**      | **10**    |    **31.29 ns** |   **0.632 ns** |   **1.414 ns** |  **2.96** |    **0.19** | **0.0111** |      **48 B** |          **NA** |
| CountWithPredicate | 10    |    10.72 ns |   0.248 ns |   0.371 ns |  1.00 |    0.00 |      - |         - |          NA |
|                    |       |             |            |            |       |         |        |           |             |
| **WhereDotCount**      | **10000** | **6,117.96 ns** | **103.471 ns** |  **96.787 ns** |  **1.05** |    **0.03** | **0.0076** |      **48 B** |          **NA** |
| CountWithPredicate | 10000 | 5,814.47 ns | 113.386 ns | 111.361 ns |  1.00 |    0.00 |      - |         - |          NA |
