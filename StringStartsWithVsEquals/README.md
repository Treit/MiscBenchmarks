# Checking if strings are the same using StartsWith vs. Equals.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count | StringLength | Mean     | Error   | StdDev  | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |------ |------------- |---------:|--------:|--------:|------:|--------:|----------:|------------:|
| **StartsWithOrdinalIgnoreCase**       | **100**   | **3**            | **165.1 ns** | **1.22 ns** | **1.14 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | 100   | 3            | 143.8 ns | 1.00 ns | 0.94 ns |  0.87 |    0.01 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | 100   | 3            | 319.9 ns | 3.74 ns | 3.32 ns |  1.94 |    0.02 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | 100   | 3            | 310.9 ns | 2.13 ns | 1.99 ns |  1.88 |    0.02 |         - |          NA |
|                                   |       |              |          |         |         |       |         |           |             |
| **StartsWithOrdinalIgnoreCase**       | **100**   | **100**          | **267.7 ns** | **1.96 ns** | **1.83 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | 100   | 100          | 264.6 ns | 2.16 ns | 1.92 ns |  0.99 |    0.01 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | 100   | 100          | 892.7 ns | 2.10 ns | 1.86 ns |  3.34 |    0.02 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | 100   | 100          | 888.4 ns | 2.33 ns | 2.18 ns |  3.32 |    0.02 |         - |          NA |
