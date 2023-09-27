# Is it even?

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25961.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|          Method |  Count |             Mean |          Error |         StdDev |      Gen0 | Allocated |
|---------------- |------- |-----------------:|---------------:|---------------:|----------:|----------:|
|  **IsEvenUsingMod** |     **10** |         **9.054 ns** |      **0.0650 ns** |      **0.0576 ns** |         **-** |         **-** |
| IsEvenlyxerexyl |     10 |       212.778 ns |      3.8652 ns |      7.5387 ns |    0.1037 |     448 B |
|  **IsEvenUsingMod** | **100000** |   **406,512.054 ns** |  **8,081.9505 ns** | **10,508.8186 ns** |         **-** |         **-** |
| IsEvenlyxerexyl | 100000 | 3,125,572.215 ns | 61,299.9478 ns | 93,611.4946 ns | 1023.4375 | 4427778 B |
