## object.ToString vs. Convert.ToString

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25305.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                       Method | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |
|----------------------------- |------ |-----------:|---------:|----------:|-----------:|------:|--------:|
|                 IntsToString | 10000 |   128.2 μs |  2.56 μs |   6.95 μs |   127.2 μs |  1.00 |    0.00 |
|     IntsToStringUsingConvert | 10000 |   139.4 μs |  6.04 μs |  17.34 μs |   133.5 μs |  1.09 |    0.16 |
|              DoublesToString | 10000 | 1,360.1 μs | 28.81 μs |  82.18 μs | 1,348.3 μs | 10.63 |    0.81 |
|  DoublesToStringUsingConvert | 10000 | 1,362.0 μs | 34.45 μs |  97.72 μs | 1,320.3 μs | 10.68 |    0.93 |
|             DecimalsToString | 10000 |   634.9 μs | 23.89 μs |  68.93 μs |   617.4 μs |  4.90 |    0.58 |
| DecimalsToStringUsingConvert | 10000 |   837.8 μs | 34.91 μs | 102.92 μs |   817.2 μs |  6.64 |    0.91 |
