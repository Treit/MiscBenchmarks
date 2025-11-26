## Comparing strings and ints




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Count  | Mean            | Error         | StdDev       | Ratio | Gen0     | Allocated | Alloc Ratio |
|--------------------- |------- |----------------:|--------------:|-------------:|------:|---------:|----------:|------------:|
| **CompareUsingTryParse** | **10**     |        **69.97 ns** |      **0.453 ns** |     **0.424 ns** |  **1.00** |        **-** |         **-** |          **NA** |
| CompareUsingToString | 10     |        68.57 ns |      0.882 ns |     0.825 ns |  0.98 |   0.0191 |     320 B |          NA |
|                      |        |                 |               |              |       |          |           |             |
| **CompareUsingTryParse** | **100000** | **1,002,108.58 ns** | **10,555.656 ns** | **9,873.767 ns** |  **1.00** |        **-** |         **-** |          **NA** |
| CompareUsingToString | 100000 |   702,485.40 ns | 10,350.405 ns | 9,681.775 ns |  0.70 | 190.4297 | 3200000 B |          NA |
