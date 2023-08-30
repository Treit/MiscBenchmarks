## Comparing strings and ints

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25941.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|               Method |  Count |           Mean |        Error |       StdDev | Ratio | RatioSD |     Gen0 | Allocated |  Alloc Ratio |
|--------------------- |------- |---------------:|-------------:|-------------:|------:|--------:|---------:|----------:|-------------:|
| **CompareUsingTryParse** |     **10** |       **136.9 ns** |      **2.27 ns** |      **2.01 ns** |  **1.00** |    **0.00** |        **-** |         **-** |           **NA** |
| CompareUsingToString |     10 |       156.0 ns |      2.84 ns |      2.65 ns |  1.14 |    0.03 |   0.0741 |     320 B |           NA |
|                      |        |                |              |              |       |         |          |           |              |
| **CompareUsingTryParse** | **100000** | **1,525,328.9 ns** | **19,631.78 ns** | **18,363.58 ns** |  **1.00** |    **0.00** |        **-** |       **1 B** |         **1.00** |
| CompareUsingToString | 100000 | 1,609,681.1 ns | 32,094.43 ns | 55,361.32 ns |  1.09 |    0.03 | 740.2344 | 3200001 B | 3,200,001.00 |
