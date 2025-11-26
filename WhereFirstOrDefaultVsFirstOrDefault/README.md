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
| **WhereThenFirstOrDefault** | **100**     |       **128.1 ns** |      **1.51 ns** |      **1.41 ns** |  **1.00** |    **0.02** |
| FirstOrDefault          | 100     |       105.3 ns |      0.57 ns |      0.51 ns |  0.82 |    0.01 |
|                         |         |                |              |              |       |         |
| **WhereThenFirstOrDefault** | **1000000** | **1,974,016.1 ns** | **37,237.33 ns** | **29,072.46 ns** |  **1.00** |    **0.02** |
| FirstOrDefault          | 1000000 | 2,087,606.5 ns | 35,281.94 ns | 45,876.49 ns |  1.06 |    0.03 |
