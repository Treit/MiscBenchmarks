# HashSet<T> vs. C5 HashSet<T>



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|               Method |   Count |           Mean |        Error |       StdDev | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 |   Allocated | Alloc Ratio |
|--------------------- |-------- |---------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|------------:|------------:|
|   **DedupeUsingHashSet** |     **100** |       **880.2 ns** |     **12.81 ns** |     **11.98 ns** |  **1.00** |    **0.00** |   **0.1287** |        **-** |        **-** |     **2.11 KB** |        **1.00** |
| DedupeUsingC5HashSet |     100 |     1,768.8 ns |      9.54 ns |      7.96 ns |  2.01 |    0.03 |   0.2136 |   0.0019 |        - |     3.49 KB |        1.66 |
|                      |         |                |              |              |       |         |          |          |          |             |             |
|   **DedupeUsingHashSet** | **1000000** | **6,630,779.2 ns** | **84,523.81 ns** | **74,928.15 ns** |  **1.00** |    **0.00** | **500.0000** | **500.0000** | **500.0000** | **18171.36 KB** |        **1.00** |
| DedupeUsingC5HashSet | 1000000 | 6,159,531.0 ns | 66,338.21 ns | 62,052.80 ns |  0.93 |    0.02 | 250.0000 | 250.0000 | 250.0000 |   8196.1 KB |        0.45 |
