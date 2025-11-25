# Array vs. Dictionary lookups by simple integer keys.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Iterations | Mean          | Error        | StdDev       | Allocated |
|---------------------- |----------- |--------------:|-------------:|-------------:|----------:|
| **LookupUsingArray**      | **10**         |      **18.22 μs** |     **0.103 μs** |     **0.096 μs** |         **-** |
| LookupUsingDictionary | 10         |      18.84 μs |     0.091 μs |     0.085 μs |         - |
| **LookupUsingArray**      | **100**        |     **182.10 μs** |     **0.694 μs** |     **0.649 μs** |         **-** |
| LookupUsingDictionary | 100        |     188.41 μs |     0.782 μs |     0.731 μs |         - |
| **LookupUsingArray**      | **1000**       |   **1,821.02 μs** |     **3.437 μs** |     **3.215 μs** |         **-** |
| LookupUsingDictionary | 1000       |   1,898.47 μs |     3.606 μs |     3.373 μs |         - |
| **LookupUsingArray**      | **10000**      |  **18,203.76 μs** |    **86.860 μs** |    **81.249 μs** |         **-** |
| LookupUsingDictionary | 10000      |  18,830.75 μs |   101.818 μs |    95.241 μs |         - |
| **LookupUsingArray**      | **100000**     | **182,080.20 μs** | **1,073.452 μs** | **1,004.108 μs** |         **-** |
| LookupUsingDictionary | 100000     | 189,531.92 μs | 1,198.354 μs | 1,120.941 μs |         - |
