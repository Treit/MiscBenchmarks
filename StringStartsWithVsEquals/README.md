# Checking if strings are the same using StartsWith vs. Equals.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26080.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                            | Count | StringLength | Mean       | Error    | StdDev    | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |------ |------------- |-----------:|---------:|----------:|-----------:|------:|--------:|----------:|------------:|
| **StartsWithOrdinalIgnoreCase**       | **100**   | **3**            |   **324.2 ns** |  **6.48 ns** |  **14.48 ns** |   **321.8 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | 100   | 3            |   268.4 ns |  4.76 ns |   9.73 ns |   264.5 ns |  0.83 |    0.05 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | 100   | 3            |   583.2 ns | 11.62 ns |  14.28 ns |   579.4 ns |  1.78 |    0.10 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | 100   | 3            |   585.8 ns | 20.88 ns |  56.09 ns |   567.7 ns |  1.80 |    0.17 |         - |          NA |
|                                   |       |              |            |          |           |            |       |         |           |             |
| **StartsWithOrdinalIgnoreCase**       | **100**   | **100**          |   **359.7 ns** |  **7.24 ns** |  **16.93 ns** |   **354.9 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualsOrdinalIgnoreCase           | 100   | 100          |   303.7 ns |  6.03 ns |  15.12 ns |   299.3 ns |  0.85 |    0.05 |         - |          NA |
| AsSpanEqualsOrdinalIgnoreCase     | 100   | 100          | 2,046.2 ns | 60.44 ns | 166.47 ns | 1,969.6 ns |  5.80 |    0.57 |         - |          NA |
| AsSpanStartsWithOrdinalIgnoreCase | 100   | 100          | 2,120.7 ns | 42.44 ns | 103.31 ns | 2,103.4 ns |  5.92 |    0.44 |         - |          NA |
