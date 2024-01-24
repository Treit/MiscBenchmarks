# Array vs. Dictionary lookups by simple integer keys.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                Method | Iterations |          Mean |      Error |     StdDev | Allocated |
|---------------------- |----------- |--------------:|-----------:|-----------:|----------:|
|      **LookupUsingArray** |         **10** |      **18.15 μs** |   **0.049 μs** |   **0.046 μs** |         **-** |
| LookupUsingDictionary |         10 |      19.53 μs |   0.041 μs |   0.036 μs |         - |
|      **LookupUsingArray** |        **100** |     **181.09 μs** |   **0.093 μs** |   **0.087 μs** |         **-** |
| LookupUsingDictionary |        100 |     195.27 μs |   0.354 μs |   0.331 μs |         - |
|      **LookupUsingArray** |       **1000** |   **1,810.53 μs** |   **1.597 μs** |   **1.416 μs** |         **-** |
| LookupUsingDictionary |       1000 |   1,949.98 μs |   1.752 μs |   1.553 μs |         - |
|      **LookupUsingArray** |      **10000** |  **18,104.29 μs** |  **10.782 μs** |   **9.004 μs** |         **-** |
| LookupUsingDictionary |      10000 |  19,522.37 μs |  19.306 μs |  18.059 μs |         - |
|      **LookupUsingArray** |     **100000** | **181,054.62 μs** | **171.718 μs** | **160.625 μs** |         **-** |
| LookupUsingDictionary |     100000 | 195,161.50 μs | 285.076 μs | 252.712 μs |         - |
