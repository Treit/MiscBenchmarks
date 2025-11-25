# Getting last element



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count   | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD |
|-------------------------- |-------- |----------:|----------:|----------:|----------:|------:|--------:|
| **LastElementViaArrayIndex**  | **1000**    | **0.0275 ns** | **0.0059 ns** | **0.0053 ns** | **0.0274 ns** |  **1.04** |    **0.29** |
| LastElementWithLinqLast   | 1000    | 1.1739 ns | 0.0122 ns | 0.0114 ns | 1.1791 ns | 44.35 |    9.24 |
| LastElementWithRangeIndex | 1000    | 0.0058 ns | 0.0055 ns | 0.0051 ns | 0.0039 ns |  0.22 |    0.20 |
|                           |         |           |           |           |           |       |         |
| **LastElementViaArrayIndex**  | **100000**  | **0.0309 ns** | **0.0073 ns** | **0.0065 ns** | **0.0310 ns** |  **1.04** |    **0.30** |
| LastElementWithLinqLast   | 100000  | 1.1641 ns | 0.0084 ns | 0.0074 ns | 1.1668 ns | 39.20 |    8.03 |
| LastElementWithRangeIndex | 100000  | 0.0032 ns | 0.0026 ns | 0.0023 ns | 0.0030 ns |  0.11 |    0.08 |
|                           |         |           |           |           |           |       |         |
| **LastElementViaArrayIndex**  | **1000000** | **0.0368 ns** | **0.0099 ns** | **0.0092 ns** | **0.0374 ns** |  **1.08** |    **0.43** |
| LastElementWithLinqLast   | 1000000 | 1.1663 ns | 0.0111 ns | 0.0093 ns | 1.1709 ns | 34.06 |   10.58 |
| LastElementWithRangeIndex | 1000000 | 0.0067 ns | 0.0061 ns | 0.0057 ns | 0.0045 ns |  0.20 |    0.18 |
