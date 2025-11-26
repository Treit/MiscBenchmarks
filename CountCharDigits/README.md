# Counting how many chars in a string are digits




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count   | Mean     | Error     | StdDev    | Ratio | RatioSD |
|---------------------------- |-------- |---------:|----------:|----------:|------:|--------:|
| CountDigitsUsingIsDigit     | 1000000 | 2.640 ms | 0.0196 ms | 0.0183 ms |  1.00 |    0.01 |
| CountDigitsUsingSubtraction | 1000000 | 2.428 ms | 0.0123 ms | 0.0115 ms |  0.92 |    0.01 |
| CountDigitsUsingHashSet     | 1000000 | 9.755 ms | 0.0619 ms | 0.0579 ms |  3.70 |    0.03 |
