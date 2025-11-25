# Removing quotes from the start and end of a quoted string.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count  | Mean         | Error       | StdDev      | Ratio | RatioSD |
|------------------------ |------- |-------------:|------------:|------------:|------:|--------:|
| **DeQuoteWithTrim**         | **100**    |     **860.0 ns** |    **12.91 ns** |    **12.08 ns** |  **1.00** |    **0.02** |
| DeQuoteWithSubstring    | 100    |     621.6 ns |    10.19 ns |     9.53 ns |  0.72 |    0.01 |
| DeQuoteWithRangePattern | 100    |     624.8 ns |     9.11 ns |     8.52 ns |  0.73 |    0.01 |
| DeQuoteWithSpan         | 100    |     762.8 ns |     7.83 ns |     6.94 ns |  0.89 |    0.01 |
|                         |        |              |             |             |       |         |
| **DeQuoteWithTrim**         | **100000** | **868,172.4 ns** | **7,061.42 ns** | **5,896.61 ns** |  **1.00** |    **0.01** |
| DeQuoteWithSubstring    | 100000 | 653,380.0 ns | 7,920.67 ns | 7,021.47 ns |  0.75 |    0.01 |
| DeQuoteWithRangePattern | 100000 | 669,609.4 ns | 6,836.53 ns | 6,060.41 ns |  0.77 |    0.01 |
| DeQuoteWithSpan         | 100000 | 765,290.5 ns | 7,480.51 ns | 6,246.57 ns |  0.88 |    0.01 |
