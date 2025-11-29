# Converting list values





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Job       | Runtime   | Count | Mean         | Error      | StdDev     | Ratio | RatioSD |
|---------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|------:|--------:|
| **ConvertAll**      | **.NET 10.0** | **.NET 10.0** | **10**    |     **37.55 ns** |   **0.417 ns** |   **0.370 ns** |  **1.00** |    **0.01** |
| SelectAndToList | .NET 10.0 | .NET 10.0 | 10    |     27.42 ns |   0.414 ns |   0.367 ns |  0.73 |    0.01 |
|                 |           |           |       |              |            |            |       |         |
| ConvertAll      | .NET 9.0  | .NET 9.0  | 10    |     33.01 ns |   0.382 ns |   0.357 ns |  1.00 |    0.01 |
| SelectAndToList | .NET 9.0  | .NET 9.0  | 10    |     27.12 ns |   0.330 ns |   0.309 ns |  0.82 |    0.01 |
|                 |           |           |       |              |            |            |       |         |
| **ConvertAll**      | **.NET 10.0** | **.NET 10.0** | **10000** | **12,203.14 ns** | **181.755 ns** | **170.014 ns** |  **1.00** |    **0.02** |
| SelectAndToList | .NET 10.0 | .NET 10.0 | 10000 |  7,214.88 ns |  91.027 ns |  76.012 ns |  0.59 |    0.01 |
|                 |           |           |       |              |            |            |       |         |
| ConvertAll      | .NET 9.0  | .NET 9.0  | 10000 | 12,275.45 ns | 193.041 ns | 180.571 ns |  1.00 |    0.02 |
| SelectAndToList | .NET 9.0  | .NET 9.0  | 10000 |  7,067.97 ns |  89.821 ns |  84.019 ns |  0.58 |    0.01 |
