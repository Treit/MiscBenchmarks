# Searching a list using Where().FirstOrDefault() vs. just FirstOrDefault()



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count   | Mean           | Error        | StdDev       | Ratio | RatioSD |
|------------------------ |-------- |---------------:|-------------:|-------------:|------:|--------:|
| **WhereThenFirstOrDefault** | **100**     |       **123.4 ns** |      **1.38 ns** |      **1.16 ns** |  **1.00** |    **0.01** |
| FirstOrDefault          | 100     |       134.3 ns |      1.15 ns |      1.02 ns |  1.09 |    0.01 |
|                         |         |                |              |              |       |         |
| **WhereThenFirstOrDefault** | **1000000** | **1,943,900.1 ns** | **32,621.86 ns** | **28,918.43 ns** |  **1.00** |    **0.02** |
| FirstOrDefault          | 1000000 | 1,873,250.7 ns | 19,744.76 ns | 17,503.22 ns |  0.96 |    0.02 |
