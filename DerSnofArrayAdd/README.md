# Removing quotes from the start and end of a quoted string.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26231.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                  | Count  | Mean           | Error        | StdDev        | Median         | Ratio | RatioSD |
|------------------------ |------- |---------------:|-------------:|--------------:|---------------:|------:|--------:|
| **DeQuoteWithTrim**         | **100**    |     **1,775.7 ns** |     **34.21 ns** |      **46.82 ns** |     **1,773.3 ns** |  **1.00** |    **0.00** |
| DeQuoteWithSubstring    | 100    |       981.1 ns |     19.68 ns |      53.21 ns |       976.4 ns |  0.56 |    0.05 |
| DeQuoteWithRangePattern | 100    |       871.3 ns |     17.50 ns |      35.76 ns |       856.0 ns |  0.50 |    0.03 |
| DeQuoteWithSpan         | 100    |     1,090.2 ns |     20.73 ns |      23.87 ns |     1,087.9 ns |  0.62 |    0.02 |
|                         |        |                |              |               |                |       |         |
| **DeQuoteWithTrim**         | **100000** | **1,716,693.9 ns** | **50,577.06 ns** | **145,926.37 ns** | **1,652,111.3 ns** |  **1.00** |    **0.00** |
| DeQuoteWithSubstring    | 100000 | 1,063,951.7 ns | 20,979.85 ns |  50,266.38 ns | 1,047,963.7 ns |  0.61 |    0.06 |
| DeQuoteWithRangePattern | 100000 |   895,948.4 ns | 16,842.72 ns |  35,893.22 ns |   883,443.7 ns |  0.51 |    0.04 |
| DeQuoteWithSpan         | 100000 | 1,172,989.2 ns | 23,002.66 ns |  43,764.94 ns | 1,157,536.2 ns |  0.66 |    0.06 |
