# Removing quotes from the start and end of a quoted string.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count  | Mean         | Error        | StdDev       | Ratio | RatioSD |
|------------------------ |------- |-------------:|-------------:|-------------:|------:|--------:|
| **DeQuoteWithTrim**         | **100**    |     **878.9 ns** |     **17.28 ns** |     **19.21 ns** |  **1.00** |    **0.03** |
| DeQuoteWithSubstring    | 100    |     634.3 ns |     11.28 ns |     10.55 ns |  0.72 |    0.02 |
| DeQuoteWithRangePattern | 100    |     640.2 ns |     11.42 ns |     10.69 ns |  0.73 |    0.02 |
| DeQuoteWithSpan         | 100    |     775.5 ns |      6.04 ns |      5.35 ns |  0.88 |    0.02 |
|                         |        |              |              |              |       |         |
| **DeQuoteWithTrim**         | **100000** | **936,167.4 ns** | **11,473.10 ns** | **10,731.94 ns** |  **1.00** |    **0.02** |
| DeQuoteWithSubstring    | 100000 | 672,443.3 ns | 11,085.03 ns |  9,826.59 ns |  0.72 |    0.01 |
| DeQuoteWithRangePattern | 100000 | 696,701.1 ns | 12,223.47 ns | 11,433.84 ns |  0.74 |    0.01 |
| DeQuoteWithSpan         | 100000 | 785,526.6 ns |  7,997.84 ns |  6,678.55 ns |  0.84 |    0.01 |
