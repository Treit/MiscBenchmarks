## object.ToString vs. Convert.ToString


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                       Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |
|----------------------------- |------ |------------:|---------:|---------:|------:|--------:|
|                 IntsToString | 10000 |    69.97 μs | 0.853 μs | 0.756 μs |  1.00 |    0.00 |
|     IntsToStringUsingConvert | 10000 |    68.69 μs | 0.467 μs | 0.437 μs |  0.98 |    0.01 |
|              DoublesToString | 10000 | 1,098.80 μs | 1.372 μs | 1.071 μs | 15.69 |    0.18 |
|  DoublesToStringUsingConvert | 10000 | 1,107.45 μs | 3.403 μs | 3.017 μs | 15.83 |    0.19 |
|             DecimalsToString | 10000 |   472.31 μs | 1.557 μs | 1.381 μs |  6.75 |    0.08 |
| DecimalsToStringUsingConvert | 10000 |   472.34 μs | 0.821 μs | 0.727 μs |  6.75 |    0.07 |
