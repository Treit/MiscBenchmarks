# Checking if strings are the same using StartsWith vs. Equals.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count | StringLength | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |------ |------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| **StartsWithOrdinalIgnoreCase**       | **100**   | **3**            | **159.2 ns** |  **2.56 ns** |  **2.39 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | 100   | 3            | 143.9 ns |  1.27 ns |  1.13 ns |  0.90 |    0.01 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | 100   | 3            | 304.7 ns |  3.33 ns |  3.12 ns |  1.91 |    0.03 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | 100   | 3            | 314.5 ns |  2.44 ns |  2.29 ns |  1.98 |    0.03 |         - |          NA |
|                                   |       |              |          |          |          |       |         |           |             |
| **StartsWithOrdinalIgnoreCase**       | **100**   | **100**          | **266.6 ns** |  **2.06 ns** |  **1.93 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | 100   | 100          | 264.8 ns |  1.66 ns |  1.56 ns |  0.99 |    0.01 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | 100   | 100          | 854.5 ns |  3.34 ns |  2.96 ns |  3.21 |    0.02 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | 100   | 100          | 921.2 ns | 18.11 ns | 29.24 ns |  3.46 |    0.11 |         - |          NA |
