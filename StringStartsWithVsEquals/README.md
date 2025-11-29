# Checking if strings are the same using StartsWith vs. Equals.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count | StringLength | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |---------- |---------- |------ |------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| **StartsWithOrdinalIgnoreCase**       | **.NET 10.0** | **.NET 10.0** | **100**   | **3**            | **164.2 ns** |  **0.57 ns** |  **0.51 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | .NET 10.0 | .NET 10.0 | 100   | 3            | 142.7 ns |  0.17 ns |  0.13 ns |  0.87 |    0.00 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | .NET 10.0 | .NET 10.0 | 100   | 3            | 302.2 ns |  1.53 ns |  1.35 ns |  1.84 |    0.01 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | .NET 10.0 | .NET 10.0 | 100   | 3            | 297.3 ns |  1.36 ns |  1.27 ns |  1.81 |    0.01 |         - |          NA |
|                                   |           |           |       |              |          |          |          |       |         |           |             |
| StartsWithOrdinalIgnoreCase       | .NET 9.0  | .NET 9.0  | 100   | 3            | 156.0 ns |  0.09 ns |  0.08 ns |  1.00 |    0.00 |         - |          NA |
| EqualsOrdinalIgnoreCase           | .NET 9.0  | .NET 9.0  | 100   | 3            | 143.4 ns |  0.18 ns |  0.14 ns |  0.92 |    0.00 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | .NET 9.0  | .NET 9.0  | 100   | 3            | 319.8 ns |  4.85 ns |  4.30 ns |  2.05 |    0.03 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | .NET 9.0  | .NET 9.0  | 100   | 3            | 326.6 ns |  0.64 ns |  0.50 ns |  2.09 |    0.00 |         - |          NA |
|                                   |           |           |       |              |          |          |          |       |         |           |             |
| **StartsWithOrdinalIgnoreCase**       | **.NET 10.0** | **.NET 10.0** | **100**   | **100**          | **265.1 ns** |  **0.62 ns** |  **0.55 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | .NET 10.0 | .NET 10.0 | 100   | 100          | 262.8 ns |  0.52 ns |  0.46 ns |  0.99 |    0.00 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | .NET 10.0 | .NET 10.0 | 100   | 100          | 893.1 ns |  1.13 ns |  1.00 ns |  3.37 |    0.01 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | .NET 10.0 | .NET 10.0 | 100   | 100          | 924.6 ns | 18.18 ns | 26.65 ns |  3.49 |    0.10 |         - |          NA |
|                                   |           |           |       |              |          |          |          |       |         |           |             |
| StartsWithOrdinalIgnoreCase       | .NET 9.0  | .NET 9.0  | 100   | 100          | 265.1 ns |  0.75 ns |  0.70 ns |  1.00 |    0.00 |         - |          NA |
| EqualsOrdinalIgnoreCase           | .NET 9.0  | .NET 9.0  | 100   | 100          | 265.5 ns |  3.29 ns |  3.08 ns |  1.00 |    0.01 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | .NET 9.0  | .NET 9.0  | 100   | 100          | 894.5 ns |  3.92 ns |  3.47 ns |  3.37 |    0.02 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | .NET 9.0  | .NET 9.0  | 100   | 100          | 880.6 ns |  3.87 ns |  3.62 ns |  3.32 |    0.02 |         - |          NA |
