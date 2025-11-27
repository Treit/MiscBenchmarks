# Counting how many chars in a string are digits





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count   | Mean     | Error     | StdDev    | Ratio | RatioSD |
|---------------------------- |---------- |---------- |-------- |---------:|----------:|----------:|------:|--------:|
| CountDigitsUsingIsDigit     | .NET 10.0 | .NET 10.0 | 1000000 | 2.639 ms | 0.0226 ms | 0.0212 ms |  1.00 |    0.01 |
| CountDigitsUsingSubtraction | .NET 10.0 | .NET 10.0 | 1000000 | 2.426 ms | 0.0156 ms | 0.0146 ms |  0.92 |    0.01 |
| CountDigitsUsingHashSet     | .NET 10.0 | .NET 10.0 | 1000000 | 9.734 ms | 0.0567 ms | 0.0531 ms |  3.69 |    0.03 |
|                             |           |           |         |          |           |           |       |         |
| CountDigitsUsingIsDigit     | .NET 9.0  | .NET 9.0  | 1000000 | 2.624 ms | 0.0223 ms | 0.0209 ms |  1.00 |    0.01 |
| CountDigitsUsingSubtraction | .NET 9.0  | .NET 9.0  | 1000000 | 2.429 ms | 0.0195 ms | 0.0182 ms |  0.93 |    0.01 |
| CountDigitsUsingHashSet     | .NET 9.0  | .NET 9.0  | 1000000 | 9.768 ms | 0.0683 ms | 0.0639 ms |  3.72 |    0.04 |
