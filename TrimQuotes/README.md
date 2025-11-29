# Removing quotes from the start and end of a quoted string.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count  | Mean         | Error        | StdDev       | Ratio | RatioSD |
|------------------------ |---------- |---------- |------- |-------------:|-------------:|-------------:|------:|--------:|
| **DeQuoteWithTrim**         | **.NET 10.0** | **.NET 10.0** | **100**    |     **917.1 ns** |     **11.09 ns** |     **10.37 ns** |  **1.00** |    **0.02** |
| DeQuoteWithSubstring    | .NET 10.0 | .NET 10.0 | 100    |     602.4 ns |      6.77 ns |      6.33 ns |  0.66 |    0.01 |
| DeQuoteWithRangePattern | .NET 10.0 | .NET 10.0 | 100    |     620.7 ns |     11.43 ns |     10.69 ns |  0.68 |    0.01 |
| DeQuoteWithSpan         | .NET 10.0 | .NET 10.0 | 100    |     756.2 ns |      5.46 ns |      4.84 ns |  0.82 |    0.01 |
|                         |           |           |        |              |              |              |       |         |
| DeQuoteWithTrim         | .NET 9.0  | .NET 9.0  | 100    |     918.4 ns |      7.70 ns |      7.21 ns |  1.00 |    0.01 |
| DeQuoteWithSubstring    | .NET 9.0  | .NET 9.0  | 100    |     614.1 ns |      6.95 ns |      6.50 ns |  0.67 |    0.01 |
| DeQuoteWithRangePattern | .NET 9.0  | .NET 9.0  | 100    |     620.3 ns |      5.25 ns |      4.91 ns |  0.68 |    0.01 |
| DeQuoteWithSpan         | .NET 9.0  | .NET 9.0  | 100    |     760.2 ns |     13.27 ns |     12.41 ns |  0.83 |    0.01 |
|                         |           |           |        |              |              |              |       |         |
| **DeQuoteWithTrim**         | **.NET 10.0** | **.NET 10.0** | **100000** | **870,293.1 ns** | **11,037.57 ns** | **10,324.55 ns** |  **1.00** |    **0.02** |
| DeQuoteWithSubstring    | .NET 10.0 | .NET 10.0 | 100000 | 642,717.0 ns |  7,394.65 ns |  6,916.96 ns |  0.74 |    0.01 |
| DeQuoteWithRangePattern | .NET 10.0 | .NET 10.0 | 100000 | 654,115.2 ns |  4,277.47 ns |  4,001.14 ns |  0.75 |    0.01 |
| DeQuoteWithSpan         | .NET 10.0 | .NET 10.0 | 100000 | 768,421.4 ns | 10,578.84 ns |  9,895.45 ns |  0.88 |    0.01 |
|                         |           |           |        |              |              |              |       |         |
| DeQuoteWithTrim         | .NET 9.0  | .NET 9.0  | 100000 | 930,757.3 ns | 13,806.65 ns | 14,178.42 ns |  1.00 |    0.02 |
| DeQuoteWithSubstring    | .NET 9.0  | .NET 9.0  | 100000 | 644,232.2 ns | 12,070.61 ns | 11,290.86 ns |  0.69 |    0.02 |
| DeQuoteWithRangePattern | .NET 9.0  | .NET 9.0  | 100000 | 671,002.2 ns |  8,769.75 ns |  8,203.23 ns |  0.72 |    0.01 |
| DeQuoteWithSpan         | .NET 9.0  | .NET 9.0  | 100000 | 768,089.8 ns |  6,649.59 ns |  5,894.69 ns |  0.83 |    0.01 |
