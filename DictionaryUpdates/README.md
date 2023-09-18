# Updating an existing dictionary entry.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25951.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                             Method | Count |           Mean |        Error |       StdDev | Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
|----------------------------------- |------ |---------------:|-------------:|-------------:|------:|--------:|--------:|----------:|------------:|
|           **IncrementUsingDictionary** |    **10** |       **452.1 ns** |      **8.69 ns** |      **8.13 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| IncrementUsingConcurrentDictionary |    10 |       828.6 ns |      6.47 ns |      5.05 ns |  1.84 |    0.03 |       - |         - |          NA |
|                                    |       |                |              |              |       |         |         |           |             |
|           **IncrementUsingDictionary** | **10000** |   **748,989.8 ns** |  **8,683.68 ns** |  **7,697.86 ns** |  **1.00** |    **0.00** | **73.2422** |  **319681 B** |        **1.00** |
| IncrementUsingConcurrentDictionary | 10000 | 1,239,282.7 ns | 24,509.28 ns | 35,925.39 ns |  1.66 |    0.05 | 72.2656 |  319681 B |        1.00 |
