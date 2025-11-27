## object.ToString vs. Convert.ToString





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Job       | Runtime   | Count | Mean      | Error    | StdDev   | Ratio | RatioSD |
|----------------------------- |---------- |---------- |------ |----------:|---------:|---------:|------:|--------:|
| IntsToString                 | .NET 10.0 | .NET 10.0 | 10000 |  63.34 μs | 1.212 μs | 1.133 μs |  1.00 |    0.02 |
| IntsToStringUsingConvert     | .NET 10.0 | .NET 10.0 | 10000 |  62.91 μs | 0.895 μs | 0.837 μs |  0.99 |    0.02 |
| DoublesToString              | .NET 10.0 | .NET 10.0 | 10000 | 699.19 μs | 4.957 μs | 4.395 μs | 11.04 |    0.20 |
| DoublesToStringUsingConvert  | .NET 10.0 | .NET 10.0 | 10000 | 709.01 μs | 4.841 μs | 4.291 μs | 11.20 |    0.20 |
| DecimalsToString             | .NET 10.0 | .NET 10.0 | 10000 | 355.36 μs | 2.305 μs | 2.156 μs |  5.61 |    0.10 |
| DecimalsToStringUsingConvert | .NET 10.0 | .NET 10.0 | 10000 | 353.53 μs | 3.890 μs | 3.639 μs |  5.58 |    0.11 |
|                              |           |           |       |           |          |          |       |         |
| IntsToString                 | .NET 9.0  | .NET 9.0  | 10000 |  64.28 μs | 1.207 μs | 1.070 μs |  1.00 |    0.02 |
| IntsToStringUsingConvert     | .NET 9.0  | .NET 9.0  | 10000 |  63.16 μs | 1.055 μs | 0.987 μs |  0.98 |    0.02 |
| DoublesToString              | .NET 9.0  | .NET 9.0  | 10000 | 708.37 μs | 4.667 μs | 4.365 μs | 11.02 |    0.19 |
| DoublesToStringUsingConvert  | .NET 9.0  | .NET 9.0  | 10000 | 704.27 μs | 6.334 μs | 5.924 μs | 10.96 |    0.20 |
| DecimalsToString             | .NET 9.0  | .NET 9.0  | 10000 | 351.81 μs | 3.620 μs | 3.387 μs |  5.47 |    0.10 |
| DecimalsToStringUsingConvert | .NET 9.0  | .NET 9.0  | 10000 | 356.19 μs | 2.804 μs | 2.623 μs |  5.54 |    0.10 |
