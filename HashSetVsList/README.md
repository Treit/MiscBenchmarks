# List vs. HashSet


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26002.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|           Method |  Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------- |------- |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|----------:|------------:|
|    **FindUsingList** |     **10** |   **371.0 ns** |  **7.41 ns** | **11.32 ns** |   **370.6 ns** |  **1.00** |    **0.00** | **0.0701** |     **304 B** |        **1.00** |
| FindUsingHashSet |     10 |   400.3 ns |  7.33 ns | 17.70 ns |   396.1 ns |  1.08 |    0.06 | 0.0701 |     304 B |        1.00 |
|                  |        |            |          |          |            |       |         |        |           |             |
|    **FindUsingList** |    **100** |   **381.0 ns** |  **7.60 ns** | **15.53 ns** |   **374.6 ns** |  **1.00** |    **0.00** | **0.0701** |     **304 B** |        **1.00** |
| FindUsingHashSet |    100 |   399.3 ns |  7.97 ns | 12.41 ns |   398.6 ns |  1.04 |    0.06 | 0.0701 |     304 B |        1.00 |
|                  |        |            |          |          |            |       |         |        |           |             |
|    **FindUsingList** | **100000** | **3,439.3 ns** | **67.16 ns** | **74.65 ns** | **3,408.3 ns** |  **1.00** |    **0.00** | **0.0687** |     **304 B** |        **1.00** |
| FindUsingHashSet | 100000 |   401.6 ns |  8.05 ns | 16.27 ns |   397.5 ns |  0.12 |    0.01 | 0.0701 |     304 B |        1.00 |
