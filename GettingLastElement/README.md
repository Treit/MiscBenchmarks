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
| **LastElementViaArrayIndex**  | **1000**    | **0.0372 ns** | **0.0113 ns** | **0.0100 ns** | **0.0352 ns** |  **1.10** |    **0.52** |
| LastElementWithLinqLast   | 1000    | 1.1646 ns | 0.0149 ns | 0.0132 ns | 1.1673 ns | 34.33 |   13.30 |
| LastElementWithRangeIndex | 1000    | 0.0079 ns | 0.0063 ns | 0.0059 ns | 0.0061 ns |  0.23 |    0.20 |
|                           |         |           |           |           |           |       |         |
| **LastElementViaArrayIndex**  | **100000**  | **0.0334 ns** | **0.0073 ns** | **0.0068 ns** | **0.0321 ns** |  **1.04** |    **0.30** |
| LastElementWithLinqLast   | 100000  | 1.1800 ns | 0.0128 ns | 0.0120 ns | 1.1834 ns | 36.74 |    7.63 |
| LastElementWithRangeIndex | 100000  | 0.0032 ns | 0.0025 ns | 0.0021 ns | 0.0032 ns |  0.10 |    0.07 |
|                           |         |           |           |           |           |       |         |
| **LastElementViaArrayIndex**  | **1000000** | **0.0390 ns** | **0.0105 ns** | **0.0093 ns** | **0.0394 ns** |  **1.09** |    **0.50** |
| LastElementWithLinqLast   | 1000000 | 1.1792 ns | 0.0128 ns | 0.0107 ns | 1.1847 ns | 32.93 |   12.84 |
| LastElementWithRangeIndex | 1000000 | 0.0017 ns | 0.0022 ns | 0.0019 ns | 0.0010 ns |  0.05 |    0.06 |
