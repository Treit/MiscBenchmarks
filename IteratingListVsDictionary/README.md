# Iterating a list vs. iterating a dictionary.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                         Method |  Count |           Mean |       Error |      StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |------- |---------------:|------------:|------------:|------:|--------:|----------:|------------:|
|                    **IterateList** |      **3** |       **2.077 ns** |   **0.0107 ns** |   **0.0095 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|          IterateDictionaryKeys |      3 |       4.654 ns |   0.0570 ns |   0.0533 ns |  2.24 |    0.03 |         - |          NA |
|        IterateDictionaryValues |      3 |       4.879 ns |   0.1107 ns |   0.1035 ns |  2.35 |    0.05 |         - |          NA |
| IterateDictionaryKeyValuePairs |      3 |       3.622 ns |   0.0933 ns |   0.0872 ns |  1.74 |    0.04 |         - |          NA |
|                                |        |                |             |             |       |         |           |             |
|                    **IterateList** |     **50** |      **32.655 ns** |   **0.1812 ns** |   **0.1606 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|          IterateDictionaryKeys |     50 |      62.195 ns |   0.0641 ns |   0.0535 ns |  1.90 |    0.01 |         - |          NA |
|        IterateDictionaryValues |     50 |      62.233 ns |   0.0805 ns |   0.0753 ns |  1.91 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs |     50 |      62.183 ns |   0.0725 ns |   0.0678 ns |  1.90 |    0.01 |         - |          NA |
|                                |        |                |             |             |       |         |           |             |
|                    **IterateList** |   **1000** |     **626.399 ns** |   **0.6632 ns** |   **0.5538 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|          IterateDictionaryKeys |   1000 |   1,245.643 ns |   0.7080 ns |   0.6276 ns |  1.99 |    0.00 |         - |          NA |
|        IterateDictionaryValues |   1000 |   1,245.219 ns |   0.5553 ns |   0.4637 ns |  1.99 |    0.00 |         - |          NA |
| IterateDictionaryKeyValuePairs |   1000 |   1,244.683 ns |   0.4760 ns |   0.3716 ns |  1.99 |    0.00 |         - |          NA |
|                                |        |                |             |             |       |         |           |             |
|                    **IterateList** | **100000** |  **62,294.753 ns** | **105.7814 ns** |  **98.9480 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|          IterateDictionaryKeys | 100000 | 156,240.422 ns | 184.1682 ns | 153.7888 ns |  2.51 |    0.01 |         - |          NA |
|        IterateDictionaryValues | 100000 | 156,522.876 ns | 266.9765 ns | 236.6677 ns |  2.51 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | 100000 | 156,377.640 ns | 156.5331 ns | 130.7122 ns |  2.51 |    0.00 |         - |          NA |
