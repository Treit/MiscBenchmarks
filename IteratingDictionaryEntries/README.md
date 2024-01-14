# Iterating dictionary entries.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                    Method |  Count |          Mean |      Error |     StdDev | Ratio | RatioSD |
|-------------------------- |------- |--------------:|-----------:|-----------:|------:|--------:|
| **IterateAndLookupUsingKeys** |     **10** |      **58.26 ns** |   **0.373 ns** |   **0.349 ns** |  **3.91** |    **0.04** |
| IterateUsingKeyValuePairs |     10 |      12.83 ns |   0.280 ns |   0.560 ns |  0.85 |    0.03 |
|        IterateUsingValues |     10 |      14.90 ns |   0.135 ns |   0.126 ns |  1.00 |    0.00 |
|                           |        |               |            |            |       |         |
| **IterateAndLookupUsingKeys** |   **1000** |   **5,308.88 ns** |   **2.377 ns** |   **1.856 ns** |  **4.26** |    **0.00** |
| IterateUsingKeyValuePairs |   1000 |   1,244.94 ns |   1.637 ns |   1.367 ns |  1.00 |    0.00 |
|        IterateUsingValues |   1000 |   1,245.57 ns |   1.144 ns |   0.893 ns |  1.00 |    0.00 |
|                           |        |               |            |            |       |         |
| **IterateAndLookupUsingKeys** | **100000** | **587,337.97 ns** | **340.338 ns** | **284.197 ns** |  **4.69** |    **0.01** |
| IterateUsingKeyValuePairs | 100000 | 156,265.80 ns | 180.994 ns | 160.446 ns |  1.25 |    0.00 |
|        IterateUsingValues | 100000 | 125,201.96 ns | 178.730 ns | 158.439 ns |  1.00 |    0.00 |
