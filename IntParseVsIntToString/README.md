## Comparing strings and ints



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Count  | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|--------------------- |------- |--------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **CompareUsingTryParse** | **10**     |      **69.95 ns** |     **0.546 ns** |     **0.511 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CompareUsingToString | 10     |      66.20 ns |     1.341 ns |     1.189 ns |  0.95 |    0.02 |   0.0191 |     320 B |          NA |
|                      |        |               |              |              |       |         |          |           |             |
| **CompareUsingTryParse** | **100000** | **999,280.18 ns** | **7,474.383 ns** | **6,991.542 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CompareUsingToString | 100000 | 670,126.99 ns | 8,636.031 ns | 8,078.149 ns |  0.67 |    0.01 | 190.4297 | 3200000 B |          NA |
