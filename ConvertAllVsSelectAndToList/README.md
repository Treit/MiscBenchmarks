# Converting list values




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Count | Mean         | Error     | StdDev    | Ratio | RatioSD |
|---------------- |------ |-------------:|----------:|----------:|------:|--------:|
| **ConvertAll**      | **10**    |     **32.67 ns** |  **0.490 ns** |  **0.458 ns** |  **1.00** |    **0.02** |
| SelectAndToList | 10    |     24.38 ns |  0.121 ns |  0.095 ns |  0.75 |    0.01 |
|                 |       |              |           |           |       |         |
| **ConvertAll**      | **10000** | **12,218.47 ns** | **98.077 ns** | **91.741 ns** |  **1.00** |    **0.01** |
| SelectAndToList | 10000 |  7,200.33 ns | 50.258 ns | 39.238 ns |  0.59 |    0.01 |
