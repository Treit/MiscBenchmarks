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
| IntsToString                 | 10000 |  65.31 μs | 1.148 μs | 1.073 μs |  1.00 |    0.02 |
| IntsToStringUsingConvert     | 10000 |  65.48 μs | 0.933 μs | 0.827 μs |  1.00 |    0.02 |
| DoublesToString              | 10000 | 698.20 μs | 5.594 μs | 4.959 μs | 10.69 |    0.18 |
| DoublesToStringUsingConvert  | 10000 | 696.62 μs | 4.258 μs | 3.556 μs | 10.67 |    0.18 |
| DecimalsToString             | 10000 | 352.14 μs | 2.321 μs | 1.938 μs |  5.39 |    0.09 |
| DecimalsToStringUsingConvert | 10000 | 353.12 μs | 1.768 μs | 1.476 μs |  5.41 |    0.09 |
