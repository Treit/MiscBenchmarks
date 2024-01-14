# Converting list values


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|          Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |
|---------------- |------ |-------------:|-----------:|-----------:|------:|--------:|
|      **ConvertAll** |    **10** |     **24.71 ns** |   **0.227 ns** |   **0.189 ns** |  **1.00** |    **0.00** |
| SelectAndToList |    10 |     39.30 ns |   0.272 ns |   0.227 ns |  1.59 |    0.02 |
|                 |       |              |            |            |       |         |
|      **ConvertAll** | **10000** | **14,820.54 ns** |  **91.924 ns** |  **81.488 ns** |  **1.00** |    **0.00** |
| SelectAndToList | 10000 |  8,476.28 ns | 109.667 ns | 102.582 ns |  0.57 |    0.01 |
