# List vs. HashSet



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|           Method |  Count |       Mean |   Error |  StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------------- |------- |-----------:|--------:|--------:|------:|-------:|----------:|------------:|
|    **FindUsingList** |     **10** |   **371.7 ns** | **1.74 ns** | **1.54 ns** |  **1.00** | **0.0181** |     **304 B** |        **1.00** |
| FindUsingHashSet |     10 |   370.1 ns | 1.42 ns | 1.18 ns |  1.00 | 0.0181 |     304 B |        1.00 |
|                  |        |            |         |         |       |        |           |             |
|    **FindUsingList** |    **100** |   **373.5 ns** | **2.11 ns** | **1.76 ns** |  **1.00** | **0.0181** |     **304 B** |        **1.00** |
| FindUsingHashSet |    100 |   370.4 ns | 4.27 ns | 3.99 ns |  0.99 | 0.0181 |     304 B |        1.00 |
|                  |        |            |         |         |       |        |           |             |
|    **FindUsingList** | **100000** | **1,936.6 ns** | **7.14 ns** | **6.68 ns** |  **1.00** | **0.0153** |     **304 B** |        **1.00** |
| FindUsingHashSet | 100000 |   372.4 ns | 1.33 ns | 1.18 ns |  0.19 | 0.0181 |     304 B |        1.00 |
