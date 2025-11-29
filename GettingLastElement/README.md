# Getting last element





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count   | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD |
|-------------------------- |---------- |---------- |-------- |----------:|----------:|----------:|----------:|------:|--------:|
| **LastElementViaArrayIndex**  | **.NET 10.0** | **.NET 10.0** | **1000**    | **0.0340 ns** | **0.0086 ns** | **0.0071 ns** | **0.0357 ns** |  **1.05** |    **0.34** |
| LastElementWithLinqLast   | .NET 10.0 | .NET 10.0 | 1000    | 1.1955 ns | 0.0214 ns | 0.0200 ns | 1.1936 ns | 36.95 |    9.24 |
| LastElementWithRangeIndex | .NET 10.0 | .NET 10.0 | 1000    | 0.0089 ns | 0.0076 ns | 0.0064 ns | 0.0091 ns |  0.28 |    0.21 |
|                           |           |           |         |           |           |           |           |       |         |
| LastElementViaArrayIndex  | .NET 9.0  | .NET 9.0  | 1000    | 0.0594 ns | 0.0097 ns | 0.0081 ns | 0.0614 ns |  1.02 |    0.22 |
| LastElementWithLinqLast   | .NET 9.0  | .NET 9.0  | 1000    | 1.1959 ns | 0.0283 ns | 0.0265 ns | 1.1908 ns | 20.58 |    3.59 |
| LastElementWithRangeIndex | .NET 9.0  | .NET 9.0  | 1000    | 0.0129 ns | 0.0081 ns | 0.0071 ns | 0.0123 ns |  0.22 |    0.13 |
|                           |           |           |         |           |           |           |           |       |         |
| **LastElementViaArrayIndex**  | **.NET 10.0** | **.NET 10.0** | **100000**  | **0.0426 ns** | **0.0109 ns** | **0.0097 ns** | **0.0393 ns** |  **1.04** |    **0.30** |
| LastElementWithLinqLast   | .NET 10.0 | .NET 10.0 | 100000  | 1.1865 ns | 0.0152 ns | 0.0142 ns | 1.1894 ns | 29.04 |    5.47 |
| LastElementWithRangeIndex | .NET 10.0 | .NET 10.0 | 100000  | 0.0041 ns | 0.0024 ns | 0.0021 ns | 0.0046 ns |  0.10 |    0.05 |
|                           |           |           |         |           |           |           |           |       |         |
| LastElementViaArrayIndex  | .NET 9.0  | .NET 9.0  | 100000  | 0.0403 ns | 0.0107 ns | 0.0089 ns | 0.0414 ns |  1.06 |    0.37 |
| LastElementWithLinqLast   | .NET 9.0  | .NET 9.0  | 100000  | 1.1704 ns | 0.0191 ns | 0.0179 ns | 1.1713 ns | 30.71 |    8.34 |
| LastElementWithRangeIndex | .NET 9.0  | .NET 9.0  | 100000  | 0.0060 ns | 0.0050 ns | 0.0042 ns | 0.0052 ns |  0.16 |    0.12 |
|                           |           |           |         |           |           |           |           |       |         |
| **LastElementViaArrayIndex**  | **.NET 10.0** | **.NET 10.0** | **1000000** | **0.0585 ns** | **0.0136 ns** | **0.0128 ns** | **0.0572 ns** |  **1.05** |    **0.32** |
| LastElementWithLinqLast   | .NET 10.0 | .NET 10.0 | 1000000 | 1.1754 ns | 0.0164 ns | 0.0145 ns | 1.1819 ns | 21.03 |    4.62 |
| LastElementWithRangeIndex | .NET 10.0 | .NET 10.0 | 1000000 | 0.0037 ns | 0.0036 ns | 0.0032 ns | 0.0028 ns |  0.07 |    0.06 |
|                           |           |           |         |           |           |           |           |       |         |
| LastElementViaArrayIndex  | .NET 9.0  | .NET 9.0  | 1000000 | 0.0343 ns | 0.0074 ns | 0.0069 ns | 0.0363 ns |  1.04 |    0.30 |
| LastElementWithLinqLast   | .NET 9.0  | .NET 9.0  | 1000000 | 1.1794 ns | 0.0167 ns | 0.0140 ns | 1.1852 ns | 35.75 |    7.29 |
| LastElementWithRangeIndex | .NET 9.0  | .NET 9.0  | 1000000 | 0.0057 ns | 0.0056 ns | 0.0046 ns | 0.0052 ns |  0.17 |    0.14 |
