# Converting list values



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Count | Mean         | Error      | StdDev     | Ratio | RatioSD |
|---------------- |------ |-------------:|-----------:|-----------:|------:|--------:|
| **ConvertAll**      | **10**    |     **34.76 ns** |   **0.497 ns** |   **0.465 ns** |  **1.00** |    **0.02** |
| SelectAndToList | 10    |     25.01 ns |   0.343 ns |   0.304 ns |  0.72 |    0.01 |
|                 |       |              |            |            |       |         |
| **ConvertAll**      | **10000** | **12,441.28 ns** | **125.216 ns** | **117.128 ns** |  **1.00** |    **0.01** |
| SelectAndToList | 10000 |  7,398.19 ns |  84.779 ns |  79.303 ns |  0.59 |    0.01 |
