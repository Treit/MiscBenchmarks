## object.ToString vs. Convert.ToString




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Count | Mean      | Error    | StdDev   | Ratio | RatioSD |
|----------------------------- |------ |----------:|---------:|---------:|------:|--------:|
| IntsToString                 | 10000 |  63.75 μs | 0.933 μs | 0.873 μs |  1.00 |    0.02 |
| IntsToStringUsingConvert     | 10000 |  76.76 μs | 0.813 μs | 0.761 μs |  1.20 |    0.02 |
| DoublesToString              | 10000 | 703.05 μs | 3.956 μs | 3.507 μs | 11.03 |    0.16 |
| DoublesToStringUsingConvert  | 10000 | 706.63 μs | 8.321 μs | 7.783 μs | 11.09 |    0.19 |
| DecimalsToString             | 10000 | 352.05 μs | 3.759 μs | 3.333 μs |  5.52 |    0.09 |
| DecimalsToStringUsingConvert | 10000 | 353.92 μs | 3.332 μs | 3.117 μs |  5.55 |    0.09 |
