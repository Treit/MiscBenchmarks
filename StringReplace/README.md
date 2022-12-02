# String replace - does the StringComparison parameter matter?

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25252
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100
  [Host]     : .NET Core 6.0.11 (CoreCLR 6.0.1122.52304, CoreFX 6.0.1122.52304), X64 RyuJIT
  DefaultJob : .NET Core 6.0.11 (CoreCLR 6.0.1122.52304, CoreFX 6.0.1122.52304), X64 RyuJIT


```
|                                   Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |
|----------------------------------------- |------ |---------:|----------:|----------:|------:|--------:|
|                ReplaceNoStringComparison | 10000 | 1.053 ms | 0.0210 ms | 0.0405 ms |  1.00 |    0.00 |
|           ReplaceStringComparisonOrdinal | 10000 | 1.131 ms | 0.0226 ms | 0.0603 ms |  1.10 |    0.07 |
| ReplaceStringComparisonOrdinalIgnoreCase | 10000 | 2.775 ms | 0.0488 ms | 0.0855 ms |  2.65 |    0.16 |
