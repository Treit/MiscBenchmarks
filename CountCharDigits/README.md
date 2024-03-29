# Counting how many chars in a string are digits


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count   | Mean      | Error     | StdDev    | Ratio | RatioSD |
|---------------------------- |-------- |----------:|----------:|----------:|------:|--------:|
| CountDigitsUsingIsDigit     | 1000000 |  3.980 ms | 0.0556 ms | 0.0493 ms |  1.00 |    0.00 |
| CountDigitsUsingSubtraction | 1000000 |  3.516 ms | 0.0356 ms | 0.0316 ms |  0.88 |    0.01 |
| CountDigitsUsingHashSet     | 1000000 | 13.285 ms | 0.2649 ms | 0.4277 ms |  3.35 |    0.11 |
